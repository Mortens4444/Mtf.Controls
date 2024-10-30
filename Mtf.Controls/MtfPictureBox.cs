using Mtf.Controls.Extensions;
using Mtf.Controls.Models;
using Mtf.Controls.Services;
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
        private readonly List<string> controlNames;
        private readonly List<LocationAndSize> controlLocationsAndSizes;

        public MtfPictureBox()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            UpdateStyles();
            OriginalSize = Size;
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

                var scaleX = (double)ImageLocationAndSize.Size.Width / OriginalSize.Width;
                var scaleY = (double)ImageLocationAndSize.Size.Height / OriginalSize.Height;

                for (var i = 0; i < Controls.Count; i++)
                {
                    Controls[i].Location = new Point((int)Math.Round((scaleX * controlLocationsAndSizes[i].Location.X) + ImageLocationAndSize.Location.X), (int)Math.Round((scaleY * controlLocationsAndSizes[i].Location.Y) + ImageLocationAndSize.Location.Y));
                    Controls[i].Size = new Size((int)Math.Round(scaleX * controlLocationsAndSizes[i].Size.Width), (int)Math.Round(scaleY * controlLocationsAndSizes[i].Size.Height));
                }
            }
            catch (ObjectDisposedException) { }
        }

        protected override void OnResize(EventArgs e)
        {
            RelocateControls();
            base.OnResize(e);
        }

        public LocationAndSize ImageLocationAndSize
        {
            get
            {
                try
                {
                    if (Image == null)
                    {
                        return null;
                    }

                    switch (SizeMode)
                    {
                        case PictureBoxSizeMode.AutoSize:
                            return new LocationAndSize(0, 0, Image.Width, Image.Height);
                        case PictureBoxSizeMode.CenterImage:
                            return new LocationAndSize((Size.Width - Image.Width) / 2, (Size.Height - Image.Height) / 2, Image.Width, Image.Height);
                        case PictureBoxSizeMode.Normal:
                            return new LocationAndSize(0, 0, Image.Width, Image.Height);
                        case PictureBoxSizeMode.StretchImage:
                            return new LocationAndSize(0, 0, Size.Width, Size.Height);
                        case PictureBoxSizeMode.Zoom:
                            var aspect_ratio = (double)Image.Width / Image.Height;
                            var aspect_ratio_2 = (double)Size.Width / Size.Height;
                            if (aspect_ratio_2 == aspect_ratio)
                            {
                                return new LocationAndSize(0, 0, Size.Width, Size.Height);
                            }
                            else if (aspect_ratio_2 < aspect_ratio)
                            {
                                var height = (int)Math.Round(Size.Width / aspect_ratio);
                                var half_pad = (Size.Height - height) / 2;
                                return new LocationAndSize(0, half_pad, Size.Width, height);
                            }
                            else
                            {
                                var width = (int)Math.Round(Size.Height * aspect_ratio);
                                var half_pad = (Size.Width - width) / 2;
                                return new LocationAndSize(half_pad, 0, width, Size.Height);
                            }
                        default:
                            return null;
                    }
                }
                catch (ObjectDisposedException)
                {
                    return null;
                }
            }
        }

        public void SetImage(Image image)
        {
            _ = this.ExecuteThreadSafely(() => Image = image);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (pe == null)
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
            catch (ObjectDisposedException) { }
        }
    }
}
