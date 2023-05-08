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
    /// A helper class to store objects like a DataContext in the current HttpContext items collection.
    /// </summary>
    /// <typeparam name="T">The type of object to store.</typeparam>
    public class HttpStorageContainer<T> :
        IDataContextStorageContainer<T> where T : class
    {
        #region Fields
        
        private readonly IHttpContextAccessor _contextAccessor;
        private const string DataContextKey = "DataContext";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of HttpStorageContainer.
        /// </summary>
        /// <param name="contextAccessor"></param>
        public HttpStorageContainer(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        #endregion

        #region IDataContextStorageContainer Members

        /// <summary>
        /// Returns an object from the container when it exists, otherwise null.
        /// </summary>
        /// <returns>The object from the container when it exists, otherwise null.</returns>
        public T? GetDataContext()
        {
            T? objectContext = null;
            var context = _contextAccessor.HttpContext;

            if (context.Items.TryGetValue(DataContextKey, out var item))
                objectContext = (T)item;

            return objectContext;
        }

        /// <summary>
        /// Stores the object in the current http context.
        /// </summary>
        /// <param name="objectContext">The object to store.</param>
        public void Store(T objectContext)
        {
            var context = _contextAccessor.HttpContext;

            if (context.Items.ContainsKey(DataContextKey))
                context.Items[DataContextKey] = objectContext;
            else
                context.Items.Add(DataContextKey, objectContext);
        }

        /// <summary>
        /// Clears the object from the container.
        /// </summary>
        public void Clear()
        {
            var context = _contextAccessor.HttpContext;

            if(context.Items.ContainsKey(DataContextKey))
                context.Items[DataContextKey] = null;
        }

        #endregion


    }
}
