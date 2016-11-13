using System.IO;
using Watson.VisualRecognition.SDK.Models.Base;

namespace Watson.VisualRecognition.SDK.Models.Classify
{
    /// <summary>
    /// Model for a classify call by file
    /// </summary>
    public class VisualRecognitionClassifyRequestFile : VisualRecognitionClassifyRequestBase
    {

        /// <param name="file">Stream for the file to classify</param>
        /// <param name="fileName">Filename of the file</param>
        public VisualRecognitionClassifyRequestFile(Stream file, string fileName)
        {
            File = new VisualRecognitionFile(file, fileName);
        }

        /// <summary>
        /// Model for the file to classify
        /// </summary>
        public VisualRecognitionFile File { get; set; }

    }
}
