using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Infrastructure
{
    /// <summary>
    /// Base class for value objects in the domain.
    /// </summary>
    /// <typeparam name="T">The type for the value object.</typeparam>
    public abstract class ValueObject<T> :
        IEquatable<T>, IValidatableObject where T : ValueObject<T>
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool CheckValue(PropertyInfo propertyInfo, T other)
        {
            var left = propertyInfo.GetValue(this, null);
            var right = propertyInfo.GetValue(other, null);

            if (left == null && right == null) return false;

            return left is T ? ReferenceEquals(left, right) : left.Equals(right);
        }

        #endregion

        #region Opertaor Overloads

        /// <summary>
        /// Override the equality comparer.
        /// </summary>
        /// <param name="left">The left side to compare.</param>
        /// <param name="right">The right side to compare.</param>
        /// <returns>True when the two objects are equal; false otherwise.</returns>
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (Equals(left, null))
            {
                return (Equals(right, null)) ? true : false;
            }
            return left.Equals(right);
        }

        /// <summary>
        /// Override the not equals comparer.
        /// </summary>
        /// <param name="left">The left side to compare.</param>
        /// <param name="right">The right side to compare.</param>
        /// <returns>True when the two objects are not equal; false otherwise.</returns>
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }

        #endregion

        #region IEquatable Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the current object is equal to the <paramref name="other"/>, otherwise <c>false</c>.</returns>
        public bool Equals(T? other)
        {
            if((object)other == null) return false;

            if(ReferenceEquals(this, other)) return true;

            var publicProperties = GetType().GetProperties();

            if (publicProperties.Any()) return publicProperties.All(p => CheckValue(p, other));

            return true;
        }

        public override bool Equals(object obj)
        {
            if((object)obj == null) return false;

            if(ReferenceEquals(this, obj)) return true;

            var item = obj as ValueObject<T>;

            if((object)item != null) return Equals((T)item);

            return false;
        }

        /// <summary>
        /// Servers as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object"/>.</returns>
        public override int GetHashCode()
        {
            var hashCode = 31;
            var changeMultiplier = false;
            var idx = 1;

            var publicProperties = this.GetType().GetProperties();

            if (publicProperties.Any())
            {
                foreach (var publicProperty in publicProperties)
                {
                    object value = publicProperty.GetValue(this, null);

                    if (value != null)
                    {
                        hashCode = hashCode * ((changeMultiplier) ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        hashCode = hashCode ^ (idx * 13);   // only for support {"a",null, null,"a"} <> {null, "a","a",null}
                    }
                }
            }
            return hashCode;
        }

        #endregion

        #region IValidatableObject Members

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <param name="validationContext">Describes the context in which validation checks are performed.</param>
        /// <returns>An IEnumerable of ValidationResult; the IEnumerable is empty when the object is in a valid state.</returns>
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        /// <summary>
        /// Determines whether this object is valid or not.
        /// </summary>
        /// <returns>An IEnumerable of ValidationResult; the IEnumerable is empty when the object is in a valid state.</returns>
        public IEnumerable<ValidationResult> Validate()
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, context, errors, true);
            return errors;
        }

        #endregion
    }
}
