namespace GameMath
{
    using System;

    /// <summary>
    ///   Common math operations on double-precision floating point numbers.
    /// </summary>
    [CLSCompliant(true)]
    public static class MathD
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the two passed numbers are equal, with respect
        ///   to possible loss of precision caused by rounding values.
        /// </summary>
        /// <param name="d">
        ///   First number to compare.
        /// </param>
        /// <param name="e">
        ///   Second number to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both numbers are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool Equals(double d, double e)
        {
            return Math.Abs(d - e) < double.Epsilon;
        }

        /// <summary>
        ///   Linearly interpolates between the two passed values.
        /// </summary>
        /// <param name="f">
        ///   First value to interpolate.
        /// </param>
        /// <param name="g">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="f" />, 1 returns <paramref name="g" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two passed values.
        /// </returns>
        public static double Lerp(double f, double g, double l)
        {
            if (l <= 0.0f)
            {
                return f;
            }

            if (l >= 1.0f)
            {
                return g;
            }

            return f + (l * (g - f));
        }

        #endregion
    }
}