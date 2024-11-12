using Mtf.Controls.Enums;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Mtf.Controls.Services
{
    public class FileBrowserViewComparer : IComparer
    {
        private readonly OrderStrategy orderStrategy;
        private readonly bool ascendingOrder;

        public FileBrowserViewComparer(OrderStrategy orderStrategy, bool ascendingOrder)
        {
            this.orderStrategy = orderStrategy;
            this.ascendingOrder = ascendingOrder;
        }

        public int Compare(object x, object y)
        {
            var comparisonResult = 0;

            if (x is ListViewItem itemX && y is ListViewItem itemY)
            {
                switch (orderStrategy)
                {
                    case OrderStrategy.Name:
                        comparisonResult = String.Compare(itemX.Text, itemY.Text, StringComparison.OrdinalIgnoreCase);
                        break;
                    case OrderStrategy.Type:
                        comparisonResult = String.Compare(itemX.SubItems[1].Text, itemY.SubItems[1].Text, StringComparison.OrdinalIgnoreCase);
                        break;
                    case OrderStrategy.Size:
                        var sizeX = FileSizeConverter.FromReadableForm(itemX.SubItems[2].Text);
                        var sizeY = FileSizeConverter.FromReadableForm(itemY.SubItems[2].Text);
                        comparisonResult = sizeX.CompareTo(sizeY);
                        break;
                    default:
                        break;
                }
            }

            return ascendingOrder ? comparisonResult : -comparisonResult;
        }
    }
}
