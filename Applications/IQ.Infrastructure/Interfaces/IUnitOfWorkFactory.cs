//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

namespace IQ.Infrastructure.Interfaces
{
    /// <summary>
    /// Creates a new instance of a unit of work.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates a new instance of a unit of work.
        /// </summary>
        IUnitOfWork Create();

        /// <summary>
        /// Creates a new instance of a unit of work.
        /// </summary>
        /// <param name="forceNew">When <c>true</c>, clears out any existing, in-memory data storage/cache first.</param>
        IUnitOfWork Create(bool forceNew);
    }
}
