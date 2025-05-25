using Mtf.Controls.Models;
using Mtf.Controls.Services;
using Mtf.MessageBoxes;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MtfPictureBox), "Resources.MtfPictureBox.png")]
    public class MtfPictureBox : PictureBox
    {
        private bool first = true;
        private bool isResizing;
        private DateTime lastResizeTime = DateTime.UtcNow;
        private DateTime lastPaintTime = DateTime.UtcNow;
        private DateTime lastBackgroundPaintTime = DateTime.UtcNow;

        private readonly List<string> controlNames;
        private readonly List<LocationAndSize> controlLocationsAndSizes;

        public MtfPictureBox()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            UpdateStyles();
            controlNames = new List<string>();
            controlLocationsAndSizes = new List<LocationAndSize>();
            RepositioningAndResizingControlsOnResize = false;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Automatically repositions and resizes all contained controls when this control is resized.")]
        public bool RepositioningAndResizingControlsOnResize { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Defines the initial dimensions of the control.")]
        public Size OriginalSize { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Debounce interval in milliseconds of the control's resize event.")]
        public int ResizeDebounceIntervalInMs { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Show errors in control's resize event.")]
        public bool ShowResizeErrors { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Debounce interval in milliseconds of the control's paint event.")]
        public int PaintDebounceIntervalInMs { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Show errors in control's paint event.")]
        public bool ShowPaintErrors { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Debounce interval in milliseconds of the control's background paint event.")]
        public int BackgroundPaintDebounceIntervalInMs { get; set; }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e == null || e.Control == null)
            {
                return;
            }

            controlNames.Add(e.Control.Name);
            controlLocationsAndSizes.Add(new LocationAndSize(e.Control.Location, e.Control.Size));
            base.OnControlAdded(e);
            RelocateControls();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (e == null || e.Control == null)
            {
                return;
            }

            controlLocationsAndSizes.RemoveAt(controlNames.IndexOf(e.Control.Name));
            _ = controlNames.Remove(e.Control.Name);
            base.OnControlRemoved(e);
            RelocateControls();
        }

        public void RefreshLocation(Control control)
        {
            if (control == null)
            {
                return;
            }

            var controlIndex = controlNames.IndexOf(control.Name);
            if (controlIndex != Constants.NotFound)
            {
                controlLocationsAndSizes[controlIndex].Location = control.Location;
            }
        }

        public void RefreshSize(Control control)
        {
            if (control == null)
            {
                return;
            }

            var controlIndex = controlNames.IndexOf(control.Name);
            if (controlIndex != Constants.NotFound)
            {
                controlLocationsAndSizes[controlIndex].Size = control.Size;
            }
        }

        public new void Invalidate()
        {
            this.ExecuteThreadSafely(() =>
            {
                RelocateControls();
                base.Invalidate();
            });
        }

        private void RelocateControls()
        {
            try
            {
                if (!RepositioningAndResizingControlsOnResize)
                {
                    return;
                }

                if ((Image == null) || (ImageLocationAndSize == null))
                {
                    return;
                }
                if (first)
                {
                    OriginalSize = ImageLocationAndSize.Size;
                    first = false;
                }

                RelocateControls(this, OriginalSize, controlLocationsAndSizes);
            }
            catch (ObjectDisposedException) { }
        }

        public static void RelocateControls(Control control, Size originalSize, List<LocationAndSize> controlLocationsAndSizes)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }
            if (controlLocationsAndSizes == null)
            {
                throw new ArgumentNullException(nameof(controlLocationsAndSizes));
            }

#if NET452 || NET462
            var imageAndSizeMode = GetImageAndSizeMode(control);
            var image = imageAndSizeMode.Item1;
            var sizeMode = imageAndSizeMode.Item2;
#else
            var (image, sizeMode) = GetImageAndSizeMode(control);
#endif
            var imageLocationAndSize = GetImageLocationAndSize(image, control.Size, sizeMode);
            var scaleX = (double)imageLocationAndSize.Size.Width / originalSize.Width;
            var scaleY = (double)imageLocationAndSize.Size.Height / originalSize.Height;

            for (var i = 0; i < control.Controls.Count; i++)
            {
                control.Controls[i].Location = new Point(
                    (int)Math.Round((scaleX * controlLocationsAndSizes[i].Location.X) + imageLocationAndSize.Location.X),
                    (int)Math.Round((scaleY * controlLocationsAndSizes[i].Location.Y) + imageLocationAndSize.Location.Y)
                );
                control.Controls[i].Size = new Size(
                    (int)Math.Round(scaleX * controlLocationsAndSizes[i].Size.Width),
                    (int)Math.Round(scaleY * controlLocationsAndSizes[i].Size.Height)
                );
            }
        }

#if NET452 || NET462
        private static Tuple<Image, PictureBoxSizeMode> GetImageAndSizeMode(Control control)
#else
        private static (Image, PictureBoxSizeMode) GetImageAndSizeMode(Control control)
#endif
        {
            if (control is PictureBox pictureBox)
            {
#if NET452 || NET462
                return new Tuple<Image, PictureBoxSizeMode>(pictureBox.Image, pictureBox.SizeMode);
#else
                return (pictureBox.Image, pictureBox.SizeMode);
#endif
            }

#if NET452 || NET462
            return new Tuple<Image, PictureBoxSizeMode>(control.BackgroundImage, GetPictureBoxSizeMode(control.BackgroundImageLayout));
#else
            return (control.BackgroundImage, GetPictureBoxSizeMode(control.BackgroundImageLayout));
#endif
        }

        private static PictureBoxSizeMode GetPictureBoxSizeMode(ImageLayout layout)
        {
            switch (layout)
            {
                case ImageLayout.None: return PictureBoxSizeMode.Normal;
                case ImageLayout.Stretch: return PictureBoxSizeMode.StretchImage;
                case ImageLayout.Zoom: return PictureBoxSizeMode.Zoom;
                case ImageLayout.Center: return PictureBoxSizeMode.CenterImage;
                default: throw new NotImplementedException();
            };
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;
            const int WM_PAINT = 0x000F;

            switch (m.Msg)
            {
                case WM_ENTERSIZEMOVE:
                    isResizing = true;
                    break;
                case WM_EXITSIZEMOVE:
                    isResizing = false;
                    Invalidate();
                    break;
                case WM_PAINT:
                    if (isResizing)
                    {
                        return;
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        protected override void OnResize(EventArgs e)
        {
            if ((DateTime.UtcNow - lastResizeTime).TotalMilliseconds < ResizeDebounceIntervalInMs)
            {
                return;
            }

            try
            {
                base.OnResize(e);
                RelocateControls();
            }
            catch (Exception ex)
            {
                if (ShowResizeErrors)
                {
                    ErrorBox.Show(ex);
                }
            }
            finally
            {
                lastResizeTime = DateTime.UtcNow;
            }
        }

        public LocationAndSize ImageLocationAndSize
        {
            get
            {
                return GetImageLocationAndSize(Image, Size, SizeMode);
            }
        }

        public static LocationAndSize GetImageLocationAndSize(Image image, Size size, PictureBoxSizeMode sizeMode)
        {
            try
            {
                if (image == null)
                {
                    return null;
                }

                switch (sizeMode)
                {
                    case PictureBoxSizeMode.AutoSize:
                        return new LocationAndSize(0, 0, image.Width, image.Height);
                    case PictureBoxSizeMode.CenterImage:
                        return new LocationAndSize((size.Width - image.Width) / 2, (size.Height - image.Height) / 2, image.Width, image.Height);
                    case PictureBoxSizeMode.Normal:
                        return new LocationAndSize(0, 0, image.Width, image.Height);
                    case PictureBoxSizeMode.StretchImage:
                        return new LocationAndSize(0, 0, size.Width, size.Height);
                    case PictureBoxSizeMode.Zoom:
                        var aspectRatio = (double)image.Width / image.Height;
                        var aspectRatio2 = (double)size.Width / size.Height;
                        if (aspectRatio2 == aspectRatio)
                        {
                            return new LocationAndSize(0, 0, size.Width, size.Height);
                        }
                        else if (aspectRatio2 < aspectRatio)
                        {
                            var height = (int)Math.Round(size.Width / aspectRatio);
                            var halfPad = (size.Height - height) / 2;
                            return new LocationAndSize(0, halfPad, size.Width, height);
                        }
                        else
                        {
                            var width = (int)Math.Round(size.Height * aspectRatio);
                            var halfPad = (size.Width - width) / 2;
                            return new LocationAndSize(halfPad, 0, width, size.Height);
                        }
                    default:
                        return new LocationAndSize(0, 0, 0, 0);
                }
            }
            catch (ObjectDisposedException)
            {
                return new LocationAndSize(0, 0, 0, 0);
            }
        }

        public void SetImage(Image image)
        {
            _ = this.ExecuteThreadSafely(() => Image = image);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if ((DateTime.UtcNow - lastBackgroundPaintTime).TotalMilliseconds < BackgroundPaintDebounceIntervalInMs)
            {
                return;
            }
            try
            {
                base.OnPaintBackground(pevent);
            }
            finally
            {
                lastBackgroundPaintTime = DateTime.UtcNow;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            try
            {
                if (isResizing || pe == null || pe.ClipRectangle.Width <= 0 || pe.ClipRectangle.Height <= 0)
                {
                    return;
                }
                if ((DateTime.UtcNow - lastPaintTime).TotalMilliseconds < PaintDebounceIntervalInMs)
                {
                    return;
                }

                try
                {
                    var g = pe.Graphics;
                    using (var backgroundBrush = new SolidBrush(BackColor))
                    {
                        g.FillRectangle(backgroundBrush, pe.ClipRectangle);
                        if (Image != null)
                        {
                            if (Enabled)
                            {
                                base.OnPaint(pe);
                            }
                            else
                            {
                                switch (SizeMode)
                                {
                                    case PictureBoxSizeMode.AutoSize:
                                        ControlPaint.DrawImageDisabled(g, Image, 0, 0, Color.Transparent);
                                        Size = Image.Size;
                                        break;
                                    case PictureBoxSizeMode.CenterImage:
                                        ControlPaint.DrawImageDisabled(g, Image, Convert.ToInt32((Width - Image.Width) / 2.0), Convert.ToInt32((Height - Image.Height) / 2.0), Color.Transparent);
                                        break;
                                    case PictureBoxSizeMode.Normal:
                                        ControlPaint.DrawImageDisabled(g, Image, 0, 0, Color.Transparent);
                                        break;
                                    case PictureBoxSizeMode.StretchImage:
                                        using (var image = ImageTransformer.StretchImage(Image, Size))
                                        {
                                            ControlPaint.DrawImageDisabled(g, image, 0, 0, Color.Transparent);
                                        }
                                        break;
                                    case PictureBoxSizeMode.Zoom:
                                        using (var zoomedImage = ImageTransformer.ZoomImage(Image, Size))
                                        {
                                            ControlPaint.DrawImageDisabled(g, zoomedImage, Convert.ToInt32((Width - zoomedImage.Width) / 2.0), Convert.ToInt32((Height - zoomedImage.Height) / 2.0), Color.Transparent);
                                        }
                                        break;
                                    default:
                                        throw new NotImplementedException();
                                }
                            }
                        }
                        else
                        {
                            base.OnPaint(pe);
                        }
                    }
                }
                finally
                {
                    lastPaintTime = DateTime.UtcNow;
                }
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                if (ShowPaintErrors)
                {
                    ErrorBox.Show(ex);
                }
            }
        }
    }
}
