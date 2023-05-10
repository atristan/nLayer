//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

#region Includes

// .NET Libraries
using System.ComponentModel.DataAnnotations;

#endregion

namespace IQ.Infrastructure
{
    /// <summary>
    /// Serves as the base class for all entities in the system.
    /// </summary>
    /// <typeparam name="T">The type of the unique identifier for the entity.</typeparam>
    public abstract class DomainEntity<T> :
        IValidatableObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique id of the entity in the underlying data store.
        /// </summary>
        public T Idx { get; set; }

        #endregion

        #region Overrides

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>True</c> if the specified object is equal to the current object, otherwise <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is DomainEntity<T> item)) return false;

            if (ReferenceEquals(this, item)) return true;

            if (item.IsTransient() || IsTransient()) return false;

            return item.Idx.Equals(Idx);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
                return
                    Idx.GetHashCode() ^
                    31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return base.GetHashCode();
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The left instance to compare.</param>
        /// <param name="right">The right instance to compare.</param>
        /// <returns><c>true</c> when the objects are the same, <c>false</c> otherwise.</returns>
        public static bool operator == (DomainEntity<T> left, DomainEntity<T> right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        /// <summary>
        /// Determines whether the object is valid or not.
        /// </summary>
        /// <param name="left">The left instance to compare.</param>
        /// <param name="right">The right instance to compare.</param>
        /// <returns><c>true</c> when the objects are the same, <c>false</c> otherwise.</returns>
        public static bool operator !=(DomainEntity<T> left, DomainEntity<T> right)
        {
            return !(left == right);
        }


        #endregion

        #region Methods

        /// <summary>
        /// Checks if the current domain entity has an identity.
        /// </summary>
        /// <returns><c>True</c> if the domain entity is transient (i.e. has no identity yet), otherwise <c>false</c>.</returns>
        public bool IsTransient()
        {
            return Idx.Equals(default(T));
        }

        #endregion

        #region IValidatableObject Members

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <returns>An IEnumerable of ValidationResult when the object is in an invalid state, otherwise the IEnumerable is empty.</returns>
        public IEnumerable<ValidationResult> Validate()
        {
            var validationErrors = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, context, validationErrors, true);
            return validationErrors;
        }

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <param name="validationContext">Describes the context in which a validation check is performed.</param>
        /// <returns>An IEnumerable of ValidationResult; empty when the obect is in a valid state.</returns>
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        #endregion


    }
}
