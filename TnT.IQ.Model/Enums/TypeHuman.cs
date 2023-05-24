namespace TnT.IQ.Model.Enums
{
    /// <summary>
    /// Determines the type of human entity.
    /// </summary>
    public enum TypeHuman
    {
        /// <summary>
        /// Indicates human type is not identified.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates human type is family.
        /// </summary>
        Family = 1,

        /// <summary>
        /// Indicates human type is a friend.
        /// </summary>
        Friend = 2,

        /// <summary>
        /// Indicates human type is an enemy.
        /// </summary>
        Enemy = 3,

        /// <summary>
        /// Indicates human type is co-worker or co-professional.
        /// </summary>
        Colleague = 4,

        /// <summary>
        /// Indicates human type is not really known but not well known.
        /// </summary>
        Acquaintance = 5,
    }
}
