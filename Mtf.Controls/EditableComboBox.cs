using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(EditableComboBox), "Resources.EditableComboBox.png")]
    public partial class EditableComboBox : ComboBox
    {
        private int editedItemIndex = Constants.NotFound;
        private string editedItemText = String.Empty;

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (editedItemIndex == SelectedIndex)
            {
                return;
            }

            if (editedItemIndex > Constants.NotFound)
            {
                Items[editedItemIndex] = editedItemText;
            }

            if (SelectedIndex > Constants.NotFound)
            {
                editedItemIndex = SelectedIndex;
                editedItemText = Items[editedItemIndex].ToString();
            }
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (editedItemIndex > Constants.NotFound)
            {
                Items[editedItemIndex] = editedItemText;
            }

            base.OnLeave(e);
        }

        protected override void OnTextUpdate(EventArgs e)
        {
            if (editedItemIndex > Constants.NotFound)
            {
                editedItemText = Text;
            }

            base.OnTextUpdate(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Enter) && (editedItemIndex > Constants.NotFound))
            {
                Items[editedItemIndex] = editedItemText;
            }

            base.OnKeyDown(e);
        }
    }
}
