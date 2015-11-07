namespace GameMath
{
    using System;

    /// <summary>
    ///   Math utility methods, independent of a specific type.
    /// </summary>
    [CLSCompliant(true)]
    public static class MathUtils
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Clamps the passed value to the specified bounds.
        /// </summary>
        /// <typeparam name="T">
        ///   Type of the value to clamp.
        /// </typeparam>
        /// <param name="value">
        ///   Value to clamp.
        /// </param>
        /// <param name="min">
        ///   Lower bound.
        /// </param>
        /// <param name="max">
        ///   Upper bound.
        /// </param>
        /// <returns>
        ///   Clamped value.
        /// </returns>
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
            {
                return min;
            }

            return value.CompareTo(max) > 0 ? max : value;
        }

        /// <summary>
        ///   Checks whether the passed value is within the specified bounds.
        /// </summary>
        /// <typeparam name="T">Type of the values to compare.</typeparam>
        /// <param name="value">Value to check.</param>
        /// <param name="min">Minimum allowed value.</param>
        /// <param name="max">Maximum allowed value.</param>
        /// <returns>
        ///   <c>true</c>, if <paramref name="value" /> falls within the specified range, and
        ///   <c>false</c>, otherwise.
        /// </returns>
        public static bool IsWithinBounds<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        /// <summary>
        ///   Returns the larger of two values.
        /// </summary>
        /// <typeparam name="T">Type of the values to compare.</typeparam>
        /// <param name="a">First value to compare.</param>
        /// <param name="b">Second value to compare.</param>
        /// <returns>Larger of both values.</returns>
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }

        /// <summary>
        ///   Returns the smaller of two values.
        /// </summary>
        /// <typeparam name="T">Type of the values to compare.</typeparam>
        /// <param name="a">First value to compare.</param>
        /// <param name="b">Second value to compare.</param>
        /// <returns>Smaller of both values.</returns>
        public static T Min<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) < 0 ? a : b;
        }

        #endregion
    }
}