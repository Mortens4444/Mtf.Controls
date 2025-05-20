using Mtf.Windows.Forms.Extensions;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mtf.Controls
{
    public class MtfListViewItem : ListViewItem
    {
        [Description("Indicates that the item checkboxes are readonly or not.")]
        public bool ReadonlyCheckboxes { get; set; }

        public override string ToString()
        {
            return this.ConvertToString();
        }
    }
}
