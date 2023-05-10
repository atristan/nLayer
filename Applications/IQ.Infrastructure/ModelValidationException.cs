//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

#region Includes

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace IQ.Infrastructure
{
    /// <summary>
    /// Base class for validation exceptions thrown from a model.
    /// </summary>
    public class ModelValidationException :
        Exception
    {
        #region Properties

        /// <summary>
        /// Gets a collection of validation errors for the entity that failed validation.
        /// </summary>
        public IEnumerable<ValidationResult> Errors { get; } = new List<ValidationResult>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of ModelValidationException in the system.
        /// </summary>
        public ModelValidationException() { }

        /// <summary>
        /// Initializes a new instance of ModelValidationException in the system.
        /// </summary>
        /// <param name="message">The error message for this exception.</param>
        public ModelValidationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of ModelValidationException in the system.
        /// </summary>
        /// <param name="message">The error message for this exception.</param>
        /// <param name="innerException">The inner exception that is wrapped in this exception.</param>
        public ModelValidationException(string message, Exception innerEx) :base(message, innerEx) { }

        /// <summary>
        /// Initializes a new instance of ModelValidationException in the system.
        /// </summary>
        /// <param name="message">The error message for this exception.</param>
        /// <param name="innerException">The inner exception that is wrapped in this exception.</param>
        /// <param name="errors">A collection of validation errors.</param>
        public ModelValidationException(string message, Exception innerEx, IEnumerable<ValidationResult> errors) : 
            base(message, innerEx)
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of ModelValidationException in the system.
        /// </summary>
        /// <param name="message">The error message for this exception.</param>
        /// <param name="errors">A collection of validation errors.</param>
        public ModelValidationException(string message, IEnumerable<ValidationResult> errors) :
            base(message)
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of ModelValidationException in the system.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public ModelValidationException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {

        }

        #endregion
    }
}
