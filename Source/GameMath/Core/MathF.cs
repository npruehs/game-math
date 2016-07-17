namespace GameMath
{
    using System;

    /// <summary>
    ///   Common math operations on single-precision floating point numbers.
    /// </summary>
    /// <seealso cref="MathD"/>
    /// <seealso cref="MathI"/>
    /// <seealso cref="MathUtils"/>
    [CLSCompliant(true)]
    public static class MathF
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
        public static bool Equals(float x, float y)
        {
            return Math.Abs(x - y) < float.Epsilon;
        }

        /// <summary>
        ///   Raises e to the specified power.
        /// </summary>
        /// <param name="x">Power to raise e to.</param>
        /// <returns>e raised to the specified power.</returns>
        public static float Exp(float x)
        {
            return (float)Math.Exp(x);
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
        [Obsolete("Use Interpolation.Lerp instead.")]
        public static float Lerp(float x, float y, float l)
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

        /// <summary>
        ///   Returns the natural (base e) logarithm of the specified number.
        /// </summary>
        /// <param name="x">Number of get the natural logarithm of.</param>
        /// <returns>Natural logarithm of the specified number.</returns>
        public static float Log(float x)
        {
            return (float)Math.Log(x);
        }

        /// <summary>
        ///   Returns the base 10 logarithm of the specified number.
        /// </summary>
        /// <param name="x">Number to get the base 10 logarithm of.</param>
        /// <returns>Base 10 logarithm of the specified number.</returns>
        public static float Log10(float x)
        {
            return (float)Math.Log10(x);
        }

        /// <summary>
        ///   Returns the passed number raised to the specified power.
        /// </summary>
        /// <param name="x">Number to compute the power of.</param>
        /// <param name="y">Exponent.</param>
        /// <returns>Passed number raised to the specified power.</returns>
        public static float Pow(float x, float y)
        {
            return (float)Math.Pow(x, y);
        }

        /// <summary>
        ///   Returns the square root of the specified number.
        /// </summary>
        /// <param name="x">
        ///   Number to get the square root of.
        /// </param>
        /// <returns>
        ///   Square root of the specified number
        /// </returns>
        public static float Sqrt(float x)
        {
            return (float)Math.Sqrt(x);
        }

        #endregion
    }
}