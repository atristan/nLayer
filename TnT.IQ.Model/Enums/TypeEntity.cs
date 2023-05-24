namespace TnT.IQ.Model
{
    /// <summary>
    /// Determines the type of entity.
    /// </summary>
    public enum TypeEntity
    {
        /// <summary>
        /// Indicates an unidentified type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates entity is human.
        /// </summary>
        Human = 1,

        /// <summary>
        /// Indicates entity is a business.
        /// </summary>
        Business = 2,

        /// <summary>
        /// Indicates entity is a non-profit.
        /// </summary>
        NonProfit = 3,
    }
}
