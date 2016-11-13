using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watson.VisualRecognition.SDK.Models.Classify
{
    /// <summary>
    /// Base Class for a Classify Call
    /// </summary>
    public abstract class VisualRecognitionClassifyRequestBase
    {
        private double? _threshold;

        /// <summary>
        /// List of the classifier IDs used to classify the images. "Default" is the classifier_id of the built-in classifier.
        /// </summary>
        public string[] Classifiers { get; set; } = { };

        /// <summary>
        /// A list with the value(s) "IBM" and/or "me" to specify which classifiers to run.
        /// </summary>
        public string[] Owners { get; set; } = { };

        /// <summary>
        /// A floating value that specifies the minimum score a class must have to be displayed in the response. Setting the threshold to 0.0 will return all values, regardless of their classification score.
        /// </summary>
        public double? Threshold
        {
            get
            {
                return _threshold;
            }
            set
            {
                if (value.HasValue && (value < 0 || value > 1))
                {
                    throw new ArgumentException("The threshold must be between 0 and 1.");
                }
                _threshold = value;
            }
        }

    }
}
