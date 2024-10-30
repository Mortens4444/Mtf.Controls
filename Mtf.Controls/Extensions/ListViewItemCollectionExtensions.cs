using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.ListView;

namespace Mtf.Controls.Extensions
{
    public static class ListViewItemCollectionExtensions
    {
        public static void ExportContent(this ListViewItemCollection listViewItemCollection, string filePath)
        {
            if (listViewItemCollection == null)
            {
                return;
            }

            var rootElement = new XElement($"{nameof(MtfListView)}_Content");
            foreach (ListViewItem item in listViewItemCollection)
            {
                var itemElement = new XElement("Item");

                for (var j = 0; j < item.SubItems.Count; j++)
                {
                    var subItemElement = new XElement($"SubItem{j}", item.SubItems[j].Text);
                    itemElement.Add(subItemElement);
                }

                rootElement.Add(itemElement);
            }

            var xmlDocument = new XDocument(rootElement);
            xmlDocument.Save(filePath);
        }
    }
}
