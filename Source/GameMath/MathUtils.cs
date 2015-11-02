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
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
            {
                return min;
            }

            return value.CompareTo(max) > 0 ? max : value;
        }

        #endregion
    }
}