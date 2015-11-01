// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathF.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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