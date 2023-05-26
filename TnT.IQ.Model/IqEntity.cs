using System.ComponentModel.DataAnnotations;
using IQ.Infrastructure;
using TnT.IQ.Model.Interfaces;

namespace TnT.IQ.Model
{
    public class IqEntity
        : DomainEntity<Guid>, IDateTracking
    {
        #region Properties

        /// <summary>
        /// Gets or sets entity's first, or primary name.
        /// </summary>
        [Required]
        public string PrimaryName { get; set; }

        /// <summary>
        /// Gets or sets the entity's middle, or secondary name.
        /// </summary>
        public string SecondaryName { get; set; }

        /// <summary>
        /// Gets or sets the entity's last, or tertiary name.
        /// </summary>
        public string TertiaryName { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Validates the object instance as well as the dependencies between properties and also calls Validate on child collections.
        /// </summary>
        /// <param name="validationContext">The current validation context.</param>
        /// <returns>A IEnumerable of ValidationResult that is empty when object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDateTracking

        /// <summary>
        /// Gets or sets the date and time the object was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was modified.
        /// </summary>
        public DateTime Modified { get; set; }

        #endregion
        
    }
}
