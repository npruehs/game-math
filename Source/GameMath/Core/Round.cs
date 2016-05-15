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
        /// <param name="x">
        ///   Number to ceil.
        /// </param>
        /// <returns>
        ///   Smallest integer that is greater than or equal to the specified number.
        /// </returns>
        public static int Ceil(double x)
        {
            return (int)Math.Ceiling(x);
        }

        /// <summary>
        ///   Returns the largest integer less than or equal to the specified number.
        /// </summary>
        /// <param name="x">
        ///   Number to floor.
        /// </param>
        /// <returns>
        ///   Largest integer less than or equal to the specified number.
        /// </returns>
        public static int Floor(double x)
        {
            return (int)Math.Floor(x);
        }

        /// <summary>
        ///   Rounds the specified number to the nearest integer.
        /// </summary>
        /// <param name="x">
        ///   Number to round.
        /// </param>
        /// <returns>
        ///   Integer nearest to the specified number.
        /// </returns>
        public static int Nearest(double x)
        {
            return (int)Math.Round(x);
        }

        /// <summary>
        ///   Returns the integral part of the specified number.
        /// </summary>
        /// <param name="x">
        ///   Number to truncate.
        /// </param>
        /// <returns>
        ///   Integral part of the specified number
        /// </returns>
        public static int Truncate(double x)
        {
            return (int)Math.Truncate(x);
        }

        #endregion
    }
}