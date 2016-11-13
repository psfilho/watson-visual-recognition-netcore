using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Watson.VisualRecognition.SDK.Models.Classifier
{
    /// <summary>
    /// Base Class for a Classifier Update or Create Call
    /// </summary>
    public abstract class VisualRecognitionClassifierManageBase
    {

        /// <summary>
        /// List of Positive Examples
        /// </summary>
        public List<VisualRecognitionClassifierPositiveClass> PositiveExamples { get; set; } = new List<VisualRecognitionClassifierPositiveClass>();

        /// <summary>
        /// Negative examples
        /// </summary>
        public VisualRecognitionClassifierNegativeClass NegativeExample { get; set; }

    }

    /// <summary>
    /// Model for a Classifier Create Call
    /// </summary>
    public class VisualRecognitionClassifierCreate : VisualRecognitionClassifierManageBase
    {
        private string _name;

        /// <summary>
        ///  The name of the new classifier. Cannot contain spaces or special characters.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (!Regex.IsMatch(value, "^[A-Z0-9a-z]{1,100}$"))
                    throw new ArgumentException("The class name must have only letters and numbers and be between 1 and 100 characters.");
                _name = value;
            }
        }

        /// <param name="name"> The name of the new classifier. Cannot contain spaces or special characters.</param>
        public VisualRecognitionClassifierCreate(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// Model for a Classifier Update Call
    /// </summary>
    public class VisualRecognitionClassifierUpdate : VisualRecognitionClassifierManageBase
    {
        /// <summary>
        ///  The ID of the classifier that you want to update.
        /// </summary>
        public string ClassifierId { get; set; }

        /// <param name="classifierId">The ID of the classifier that you want to update.</param>
        public VisualRecognitionClassifierUpdate(string classifierId)
        {
            ClassifierId = classifierId;
        }

    }

}
