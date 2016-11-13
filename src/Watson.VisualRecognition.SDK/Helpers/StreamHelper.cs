using System.IO;

namespace Watson.VisualRecognition.SDK.Helpers
{
    internal static class StreamHelper
    {
        public static byte[] ReadFully(this Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                var array= ms.ToArray();
                return array;
            }
        }
    }
}
