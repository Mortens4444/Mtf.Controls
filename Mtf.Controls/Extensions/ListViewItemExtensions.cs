using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mtf.Controls.Extensions
{
    public static class ListViewItemExtensions
    {
        public static string ToString(this ListViewItem item)
        {
            return ConvertToString(item);
        }

        public static string ConvertToString(this ListViewItem item)
        {
            if (item == null)
            {
                return String.Empty;
            }

            var toString = new StringBuilder(item.Text);
            for (var i = 1; i < item.SubItems.Count; i++)
            {
                _ = toString.AppendFormat(CultureInfo.InvariantCulture, $"\t{item.SubItems[i].Text}");
            }

            return toString.ToString();
        }

        public static ReadOnlyCollection<string> ToArrayList(this ListViewItem item)
        {
            return new ReadOnlyCollection<string>(ToEnumerable(item).ToList());
        }

        public static string ToStringInPreferedFormat(this ListViewItem item)
        {
            return String.Join("\t", ToEnumerable(item));
        }

        private static IEnumerable<string> ToEnumerable(ListViewItem item)
        {
            return item?.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text);
        }
    }
}
