//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

namespace IQ.Infrastructure.Interfaces
{
    /// <summary>
    /// Represents a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits the changes to the underlying data store.
        /// </summary>
        /// <param name="resetOnCommit">When <c>true</c>, all the previously retrieved objects should be cleared from the underlying model or cache.</param>
        void Commit(bool resetOnCommit);

        /// <summary>
        /// Undoes all the changes to the entities in the model.
        /// </summary>
        void Undo();
    }
}
