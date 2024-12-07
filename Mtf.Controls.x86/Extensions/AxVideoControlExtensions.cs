using AxVIDEOCONTROL4Lib;
using Mtf.Controls.x86.Services;
using Mtf.MessageBoxes;
using System;
using System.Threading.Tasks;

namespace Mtf.Controls.x86.Extensions
{
    public static class AxVideoControlExtensions
    {
        public static AxVideoPicture Recreate(this AxVideoPicture control)
        {
            var newControl = ShallowCopyHelper.ShallowCopy(control);
            if (control != null)
            {
                try
                {
                    Task.Run(() =>
                    {
                        if (control.InvokeRequired)
                        {
                            control.Invoke((Action)(() => control.Disconnect()));
                        }
                        else
                        {
                            control.Disconnect();
                        }
                    }).ContinueWith((t) =>
                    {
                        if (control.InvokeRequired)
                        {
                            control.Invoke((Action)(() => control.Dispose()));
                        }
                        else
                        {
                            control.Dispose();
                        }
                    });
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            return ShallowCopyHelper.ShallowCopy(newControl);
        }

        public static AxVideoServer RecreateFrom(this AxVideoServer control, AxVideoServer originalControl)
        {
            var newControl = ShallowCopyHelper.ShallowCopy(originalControl);
            if (control != null)
            {
                try
                {
                    Task.Run(() => control.Disconnect()).ContinueWith((t) => control.Dispose());
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            return ShallowCopyHelper.ShallowCopy(newControl);
        }
    }
}
