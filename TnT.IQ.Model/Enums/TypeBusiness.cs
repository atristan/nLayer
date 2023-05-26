namespace TnT.IQ.Model.Enums
{
    /// <summary>
    /// DEtermines the type of business entity.
    /// </summary>
    public enum TypeBusiness
    {
        /// <summary>
        /// Indicates an unidentified business type.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates business is a sole proprietorship.
        /// </summary>
        SoleProprietor = 1,

        /// <summary>
        /// Indicates business is a limited liability structure.
        /// </summary>
        LimitedLiability = 2,

        /// <summary>
        /// Indicates business is a corporation of some sort.
        /// </summary>
        Corporation = 3,

        /// <summary>
        /// Indicates business is non-profit of some sort (i.e. foundation, school, etc).
        /// </summary>
        NonProfit = 4,


    }
}
