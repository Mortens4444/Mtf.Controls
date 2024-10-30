using System;
using System.Windows.Forms;

namespace Mtf.Controls.Extensions
{
    public static class ControlExtensions
    {
        public static void ExecuteThreadSafely(this Control control, Action action)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            try
            {
                if (!control.InvokeRequired)
                {
                    action();
                }
                else
                {
                    control.Invoke(action);
                }
            }
            catch (ObjectDisposedException) { }
        }

        public static T ExecuteThreadSafely<T>(this Control control, Func<T> func, T fallback = default)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            try
            {
                return !control.InvokeRequired ? func() : (T)control.Invoke(func);
            }
            catch (ObjectDisposedException)
            {
                return fallback;
            }
        }
    }
}
