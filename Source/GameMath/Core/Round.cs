namespace GameMath
{
    using System;

    /// <summary>
    ///   Common rounding operations.
    /// </summary>
    [CLSCompliant(true)]
    public static class Round
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Returns the smallest integer greater than or equal to the specified number.
        /// </summary>
        /// <param name="d">
        ///   Number to ceil.
        /// </param>
        /// <returns>
        ///   Smallest integer that is greater than or equal to the specified number.
        /// </returns>
        public static int Ceil(double d)
        {
            return (int)Math.Ceiling(d);
        }

        /// <summary>
        ///   Returns the largest integer less than or equal to the specified number.
        /// </summary>
        /// <param name="d">
        ///   Number to floor.
        /// </param>
        /// <returns>
        ///   Largest integer less than or equal to the specified number.
        /// </returns>
        public static int Floor(double d)
        {
            return (int)Math.Floor(d);
        }

        /// <summary>
        ///   Rounds the specified number to the nearest integer.
        /// </summary>
        /// <param name="d">
        ///   Number to round.
        /// </param>
        /// <returns>
        ///   Integer nearest to the specified number.
        /// </returns>
        public static int Nearest(double d)
        {
            return (int)Math.Round(d);
        }

        /// <summary>
        ///   Returns the integral part of the specified number.
        /// </summary>
        /// <param name="d">
        ///   Number to truncate.
        /// </param>
        /// <returns>
        ///   Integral part of the specified number
        /// </returns>
        public static int Truncate(double d)
        {
            return (int)Math.Truncate(d);
        }

        #endregion
    }
}