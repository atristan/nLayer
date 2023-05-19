//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Infrastructure.DataContextStorage;
using IQ.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

#endregion

namespace TnT.AIQ.Infrastructure
{
    /// <summary>
    /// A helper class to create application platform specific storage containers.
    /// </summary>
    /// <typeparam name="T">The type of container to create.</typeparam>
    public static class DataContextStorageFactory<T> where T : class
    {
        #region Fields

        private static IDataContextStorageContainer<T> _container;

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new container that uses HttpContext.Items or Thread.Items.
        /// </summary>
        /// <param name="contextAccessor"></param>
        /// <returns></returns>
        public static IDataContextStorageContainer<T> CreateStorageContainer(IHttpContextAccessor? contextAccessor = null)
        {
            if (_container == null)
            {
                if (contextAccessor.HttpContext == null)
                    _container = new ThreadStorageContainer<T>();
                else
                    _container = new HttpStorageContainer<T>(contextAccessor);
            }

            return _container;
        }

        #endregion
    }
}
