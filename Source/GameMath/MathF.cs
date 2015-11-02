namespace GameMath
{
    using System;

    public class MathF
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the two passed numbers are equal, with respect
        ///   to possible loss of precision caused by rounding values.
        /// </summary>
        /// <param name="f">
        ///   First number to compare.
        /// </param>
        /// <param name="g">
        ///   Second number to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both numbers are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool Equals(float f, float g)
        {
            return Math.Abs(f - g) < float.Epsilon;
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
        public static float Lerp(float f, float g, float l)
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

        /// <summary>
        ///   Returns the square root of the specified number.
        /// </summary>
        /// <param name="f">
        ///   Number to get the square root of.
        /// </param>
        /// <returns>
        ///   Square root of the specified number
        /// </returns>
        public static float Sqrt(float f)
        {
            return (float)Math.Sqrt(f);
        }

        #endregion
    }
}