//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

namespace IQ.Infrastructure.Interfaces
{
    /// <summary>
    /// Defines methods to create, store, and create objects from a storage container.
    /// </summary>
    /// <typeparam name="T">The type of data context storage container.</typeparam>
    public interface IDataContextStorageContainer<T>
    {
        /// <summary>
        /// Returns an object form the container when it exists, otherwise null.
        /// </summary>
        /// <returns>The object from the container when it exists, otherwise null.</returns>
        T? GetDataContext();

        /// <summary>
        /// Stores the object in the HttpContext.Current.Items.
        /// </summary>
        /// <param name="objectContext">The context to store.</param>
        void Store(T objectContext);

        /// <summary>
        /// Clears the object from the container.
        /// </summary>
        void Clear();


    }
}
