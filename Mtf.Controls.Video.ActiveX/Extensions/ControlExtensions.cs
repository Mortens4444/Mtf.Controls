using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video.ActiveX.Extensions
{
    public static class ControlExtensions
    {
        public static Task InvokeAsync(this Control control, Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            if (control.IsDisposed)
            {
                tcs.SetCanceled();
                return tcs.Task;
            }

            control.BeginInvoke(new MethodInvoker(() =>
            {
                try
                {
                    if (!control.IsDisposed)
                    {
                        action();
                        tcs.SetResult(null);
                    }
                    else
                    {
                        tcs.SetCanceled();
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }));
            return tcs.Task;
        }
    }
}
