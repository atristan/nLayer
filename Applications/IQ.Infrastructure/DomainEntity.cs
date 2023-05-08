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
    public abstract class DomainEntity<T> :
        IValidatableObject
    {
        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
