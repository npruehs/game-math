namespace GameMath
{
    using System;

    /// <summary>
    ///   Common math operations on double-precision floating point numbers.
    /// </summary>
    /// <seealso cref="MathF"/>
    /// <seealso cref="MathI"/>
    /// <seealso cref="MathUtils"/>
    [CLSCompliant(true)]
    public static class MathD
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the two passed numbers are equal, with respect
        ///   to possible loss of precision caused by rounding values.
        /// </summary>
        /// <param name="x">
        ///   First number to compare.
        /// </param>
        /// <param name="y">
        ///   Second number to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both numbers are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool Equals(double x, double y)
        {
            return Math.Abs(x - y) < double.Epsilon;
        }

        /// <summary>
        ///   Linearly interpolates between the two passed values.
        /// </summary>
        /// <param name="x">
        ///   First value to interpolate.
        /// </param>
        /// <param name="y">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="x" />, 1 returns <paramref name="y" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two passed values.
        /// </returns>
        public static double Lerp(double x, double y, double l)
        {
            if (l <= 0.0f)
            {
                return x;
            }

            if (l >= 1.0f)
            {
                return y;
            }

            return x + (l * (y - x));
        }

        #endregion
    }
}