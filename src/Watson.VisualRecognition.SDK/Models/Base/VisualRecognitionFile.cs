using System.IO;

namespace Watson.VisualRecognition.SDK.Models.Base
{
    public class VisualRecognitionFile
    {

        public VisualRecognitionFile(Stream stream, string name)
        {
            Stream = stream;
            Name = name;
        }

        public Stream Stream { get; private set; }

        public string Name { get; private set; }

    }
}
