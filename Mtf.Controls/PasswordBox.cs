using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(PasswordBox), "Resources.PasswordBox.png")]

    public class PasswordBox : TextBox
    {
        private volatile int disposed;
        private SecureString password = new SecureString();
        private static readonly Random random = new Random();

        public PasswordBox() : base()
        {
            PasswordChar = '*';
            UseSystemPasswordChar = false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            base.OnKeyPress(e);

            if (!Char.IsControl(e.KeyChar))
            {
                var index = SelectionStart < 0 ? 0 : (SelectionStart > password.Length ? password.Length : SelectionStart);

                try
                {
                    if (SelectionLength > 0)
                    {
                        for (int i = 0; i < SelectionLength && password.Length > 0; i++)
                        {
                            password.RemoveAt(index);
                        }
                    }

                    password.InsertAt(index, e.KeyChar);

                    e.Handled = true;
                    UpdateMaskedText();
                    SelectionStart = index + 1;
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (String.IsNullOrEmpty(Text))
            {
                password.Clear();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            base.OnKeyDown(e);
            try
            {
                if (e.KeyCode == Keys.Back && SelectionStart > 0)
                {
                    password.RemoveAt(SelectionStart - 1);
                    e.Handled = true;
                    UpdateMaskedText();
                    SelectionStart--;
                }
                else if (e.KeyCode == Keys.Delete && SelectionStart < password.Length)
                {
                    password.RemoveAt(SelectionStart);
                    e.Handled = true;
                    UpdateMaskedText();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void UpdateMaskedText()
        {
            if (ShowRealPasswordLength)
            {
                base.Text = new string(PasswordChar, password.Length);
            }
            else
            {
                //var randomLength = RandomProvider.GetSecureRandomByte();
                var randomLength = random.Next(password.Length, password.Length + 10);
                base.Text = new string(PasswordChar, randomLength);
            }

            SelectionStart = Math.Min(SelectionStart, Text.Length);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Displays real password length or a randomized masked length.")]
        public bool ShowRealPasswordLength { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Gets or sets the secure password.")]

        public string Password
        {
            get
            {
                if (password == null)
                {
                    return String.Empty;
                }

                var unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    password = new SecureString();
                    Text = String.Empty;
                }
                else
                {
                    var secureString = new SecureString();
                    foreach (var ch in value)
                    {
                        secureString.AppendChar(ch);
                    }
                    password = secureString;
                    UpdateMaskedText();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) != 0)
            {
                return;
            }

            if (disposing)
            {
                password.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PASTE = 0x0302;

            if (m.Msg == WM_PASTE)
            {
                var clipboardText = Clipboard.GetText();
                if (!String.IsNullOrEmpty(clipboardText))
                {
                    var index = SelectionStart < 0 ? 0 : (SelectionStart > password.Length ? password.Length : SelectionStart);

                    foreach (var ch in clipboardText)
                    {
                        password.InsertAt(index++, ch);
                    }

                    UpdateMaskedText();
                    SelectionStart = index;
                }

                return;
            }

            base.WndProc(ref m);
        }
    }
}
