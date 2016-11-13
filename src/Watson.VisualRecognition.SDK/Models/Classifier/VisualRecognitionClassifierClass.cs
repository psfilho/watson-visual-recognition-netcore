using System;
using System.IO;
using System.Text.RegularExpressions;
using Watson.VisualRecognition.SDK.Models.Base;

namespace Watson.VisualRecognition.SDK.Models.Classifier
{
    public abstract class VisualRecognitionClassifierClass
    {

        /// <summary>
        /// A compressed (.zip) file of images 
        /// </summary>
        public VisualRecognitionFile ZipFile { get; set; }

    }


    /// <summary>
    /// A compressed (.zip) file of images that depict the visual subject for a class within the new classifier. Must contain a minimum of 10 images.
    /// </summary>
    public class VisualRecognitionClassifierPositiveClass : VisualRecognitionClassifierClass
    {

        public VisualRecognitionClassifierPositiveClass(string className, Stream file, string fileName)
        {
            ZipFile = new VisualRecognitionFile(file, fileName);
            ClassName = className;
        }


        private string _className;
        /// <summary>
        /// Name of the class
        /// </summary>
        /// 
        public string ClassName
        {
            get { return _className; }
            set
            {
                if (!Regex.IsMatch(value, "^[A-Z0-9a-z]{1,100}$"))
                    throw new ArgumentException("The class name must have only letters and numbers and be between 1 and 100 characters.");
                _className = value;
            }
        }

    }

    /// <summary>
    /// A compressed (.zip) file of images that do not depict the visual subject of any of the classes of the new classifier. Must contain a minimum of 10 images.
    /// </summary>
    public class VisualRecognitionClassifierNegativeClass : VisualRecognitionClassifierClass
    {

        public VisualRecognitionClassifierNegativeClass(Stream file, string fileName)
        {
            ZipFile = new VisualRecognitionFile(file, fileName);
        }

    }

}
