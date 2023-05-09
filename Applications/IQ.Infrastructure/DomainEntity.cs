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
            if(obj == null || !(obj is DomainEntity<T>)) return false;

            if(ReferenceEquals(this, obj)) return true;

            var item = obj as DomainEntity<T>;

            if(item.IsTransient() || IsTransient()) return false;

            return item.Idx.Equals(Idx);
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
