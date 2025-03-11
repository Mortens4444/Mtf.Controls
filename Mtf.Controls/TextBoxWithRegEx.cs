using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TextBoxWithRegEx), "Resources.TextBoxWithRegEx.png")]
    public class TextBoxWithRegEx : TextBox
    {
        public static string IPv4RegEx = @"\b((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\b";
        public static string IPv6RegEx = @"\b(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|::|([0-9a-fA-F]{1,4}:){1,7}:|::[0-9a-fA-F]{1,4}(:[0-9a-fA-F]{1,4}){1,7})\b";
        public static string EmailRegEx = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
        public static string WebsiteRegEx = @"\b(https?:\/\/)?(www\.)?[a-zA-Z0-9._-]+\.[a-zA-Z]{2,}(\.[a-zA-Z]{2,})?(\/[^\s]*)?\b";
        public static string TelephoneRegEx = @"\b\+?[0-9]{1,4}[-.\s]?(\(?[0-9]{1,5}\)?)?[-.\s]?[0-9]{1,4}[-.\s]?[0-9]{1,4}[-.\s]?[0-9]{1,9}\b";
        public static string NameRegEx = @"\b[A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+([-'\s][A-ZÁÉÍÓÖŐÚÜŰ]?[a-záéíóöőúüű]+)*\b";
        public static string NumberRegEx = @"\b-?\d+(\.\d+)?\b";
        public static string LicensePlateRegEx = @"\b[A-Z]{3}-\d{3,4}\b";

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Regular expression to check the provided text.")]
        public string RegularExpression { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text property is valid data.")]
        public bool IsValid { get; private set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The error provider will be appear on the left side of the textbox.")]
        public bool DisplayErrorOnLeft { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("You will see this error, when the text not matches with the regular expression.")]
        public string ErrorMessage { get; set; } = "The given text does not match the regex.";

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color of the acceptance.")]
        public Color AcceptColor { get; set; } = Color.LightGreen;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color of the rejection.")]
        public Color RejectionColor { get; set; } = Color.IndianRed;

        private readonly ErrorProvider errorProvider = new ErrorProvider();

        protected override void OnTextChanged(EventArgs e)
        {
            if (!String.IsNullOrEmpty(RegularExpression))
            {
                var match = new Regex(RegularExpression).Match(Text);
                IsValid = match.Success && (match.Length == Text.Length);

                errorProvider.RightToLeft = DisplayErrorOnLeft;
                if (IsValid)
                {
                    errorProvider.Clear();
                }
                else
                {
                    errorProvider.SetError(this, ErrorMessage);
                }

                BackColor = IsValid ? AcceptColor : RejectionColor;
            }

            base.OnTextChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                errorProvider.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
