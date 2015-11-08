namespace GameMath
{
    using System;

    /// <summary>
    ///   Common math operations on integer numbers.
    /// </summary>
    [CLSCompliant(true)]
    public static class MathI
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Gets the k-th bit of the passed <see cref="int" /> value.
        /// </summary>
        /// <param name="i">
        ///   Value to get the k-th bit of.
        /// </param>
        /// <param name="k">
        ///   Bit to get.
        /// </param>
        /// <returns>
        ///   0 or 1.
        /// </returns>
        public static int GetBit(int i, int k)
        {
            return (i >> k) & 1;
        }

        #endregion
    }
}