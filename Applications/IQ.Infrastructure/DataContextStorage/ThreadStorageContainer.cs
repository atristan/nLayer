//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

#region Includes

// .NET Libraries
using System.Collections;

// IQ Libraries
using IQ.Infrastructure.Interfaces;

#endregion


namespace IQ.Infrastructure.DataContextStorage
{
    /// <summary>
    /// A helper class to store objects like a DataContext in a static HashTable indexed by the name of the thread (guid).
    /// </summary>
    /// <typeparam name="T">The type of data context storage container.</typeparam>
    public class ThreadStorageContainer<T> :
        IDataContextStorageContainer<T> where T : class
    {
        #region Fields

        public static readonly Hashtable _storedContexts = new();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the HashTable that is storing the data contexts.
        /// </summary>
        public static Hashtable StoredContexts => _storedContexts;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the thread name.
        /// </summary>
        /// <returns>Returns thread name as a guid to be searchable in the storage context hashtable.</returns>
        private static string GetThreadName()
        {
            if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
                Thread.CurrentThread.Name = Guid.NewGuid().ToString();
            return Thread.CurrentThread.Name;
        }

        #endregion

        #region IDataContextStorageContainer Members

        /// <summary>
        /// Clears the object from the container.
        /// </summary>
        public void Clear()
        {
            StoredContexts[GetThreadName()] = null;
        }

        /// <summary>
        /// Returns an object from the container when it exits, otherwise null.
        /// </summary>
        /// <returns>The object from the container when it exists, otherwise null.</returns>
        public T? GetDataContext()
        {
            T? context = null;

            if (StoredContexts.Contains(GetThreadName()))
                context = (T)StoredContexts[GetThreadName()];

            return context;
        }

        /// <summary>
        /// Stores the object in the hashtable indexed by the thread's name.
        /// </summary>
        /// <param name="objectContext">The object to store.</param>
        public void Store(T objectContext)
        {
            if(StoredContexts.Contains(GetThreadName()))
                StoredContexts[GetThreadName()] = objectContext;
            else
                StoredContexts.Add(GetThreadName(), objectContext);
        }

        #endregion
        
    }
}
