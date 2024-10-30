using System.Drawing;
using System.IO;
using System.Reflection;


namespace Mtf.Controls.Services
{
    public static class ResourceHelper
    {
        public static Image GetEmbeddedResourceByName(Assembly assembly, string resourceName)
        {
            using (var stream = assembly?.GetManifestResourceStream(resourceName))
            {
                return stream == null ? throw new FileNotFoundException($"Resource '{resourceName}' not found.") : Image.FromStream(stream);
            }
        }
    }
}
