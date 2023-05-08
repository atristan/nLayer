using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Infrastructure.Interfaces
{
    public interface IDataContextStorageFactory<T> where T : class
    {
        IDataContextStorageContainer<T> CreateStorageContainer();
    }
}
