//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

#region Includes

// IQ Libraries
using IQ.Infrastructure.Interfaces;

// Microsoft Libraries
using Microsoft.AspNetCore.Http;

#endregion

namespace IQ.Infrastructure.DataContextStorage
{
    /// <summary>
    /// A helper class to create application platform specific storage containers.
    /// </summary>
    /// <typeparam name="T">The type to create a container for.</typeparam>
    public class DataContextStorageFactory<T> :
        IDataContextStorageFactory<T> where T : class
    {
        #region Fields

        private static IDataContextStorageContainer<T> _container;
        private readonly IHttpContextAccessor _contextAccessor;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of DataContextStorageFactory in the system.
        /// </summary>
        /// <param name="contextAccessor"></param>
        public DataContextStorageFactory(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new container that uses either the current http context (when _contextAccessor is not null) or a new thread container.
        /// </summary>
        /// <returns></returns>
        public IDataContextStorageContainer<T> CreateStorageContainer()
        {
            if (_container != null) return _container;

            if (_contextAccessor.HttpContext == null)
                _container = new ThreadStorageContainer<T>();
            else
                _container = new HttpStorageContainer<T>(_contextAccessor);

            return _container;
        }

        #endregion
    }
}
