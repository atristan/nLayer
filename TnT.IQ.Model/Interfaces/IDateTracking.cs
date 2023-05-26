namespace TnT.IQ.Model.Interfaces
{
    /// <summary>
    /// Defines an interface for objects that need to keep track of creation and modification dates.
    /// </summary>
    public interface IDateTracking
    {
        /// <summary>
        /// Gets or sets the date and time the object was created.
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was modified.
        /// </summary>
        DateTime Modified { get; set; }
    }
}
