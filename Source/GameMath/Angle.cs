namespace GameMath
{
    using System;

    /// <summary>
    ///   Common math operations on angles in radians.
    /// </summary>
    [CLSCompliant(true)]
    public static class Angle
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Inverse of the cos function.
        ///   Returns the angle whose cosine is the specified number, in radians.
        /// </summary>
        /// <param name="x">Number to get the acos of.</param>
        /// <returns>Angle whose cosine is the specified number.</returns>
        public static float Acos(float x)
        {
            return (float)Math.Acos(x);
        }

        /// <summary>
        ///   Inverse of the sin function.
        ///   Returns the angle whose sine is the specified number, in radians.
        /// </summary>
        /// <param name="x">Number to get the asin of.</param>
        /// <returns>Angle whose sine is the specified number.</returns>
        public static float Asin(float x)
        {
            return (float)Math.Asin(x);
        }

        /// <summary>
        ///   Inverse of the tan function.
        ///   Returns the angle whose tangent is the specified number, in radians.
        /// </summary>
        /// <param name="x">Number to get the atan of.</param>
        /// <returns>Angle whose tangent is the specified number.</returns>
        public static float Atan(float x)
        {
            return (float)Math.Atan(x);
        }

        /// <summary>
        ///   Returns the angle whose tangent is the quotient of two specified numbers, in radians.
        /// </summary>
        /// <param name="y">Dividend.</param>
        /// <param name="x">Divisor.</param>
        /// <returns>Angle whose tangent is the quotient of two specified numbers.</returns>
        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        /// <summary>
        ///   Returns the cosine of the specified angle in radians.
        /// </summary>
        /// <param name="x">Angle to get the cosine of.</param>
        /// <returns>Cosine of the specified angle.</returns>
        public static float Cos(float x)
        {
            return (float)Math.Cos(x);
        }

        /// <summary>
        ///   Returns the hyperbolic cosine of the specified angle in radians.
        /// </summary>
        /// <param name="x">Angle to get the hyperbolic cosine of.</param>
        /// <returns>Hyperbolic cosine of the specified angle.</returns>
        public static float Cosh(float x)
        {
            return (float)Math.Cosh(x);
        }

        /// <summary>
        ///   Converts the specified angle in degrees to radians.
        /// </summary>
        /// <param name="degrees">
        ///   Degrees to convert to radians.
        /// </param>
        /// <returns>
        ///   Passed angle in radians.
        /// </returns>
        public static float DegreesToRadians(float degrees)
        {
            return degrees * (Constants.Pi / 180.0f);
        }

        /// <summary>
        ///   Converts the specified angle in radians to degrees.
        /// </summary>
        /// <param name="degrees">
        ///   Radians to convert to degrees.
        /// </param>
        /// <returns>
        ///   Passed angle in degrees.
        /// </returns>
        public static float RadiansToDegrees(float degrees)
        {
            return degrees * (180.0f / Constants.Pi);
        }

        /// <summary>
        ///   Returns the sine of the specified angle in radians.
        /// </summary>
        /// <param name="x">Angle to get the sine of.</param>
        /// <returns>Sine of the specified angle.</returns>
        public static float Sin(float x)
        {
            return (float)Math.Sin(x);
        }

        /// <summary>
        ///   Returns the hyperbolic sine of the specified angle in radians.
        /// </summary>
        /// <param name="x">Angle to get the hyperbolic sine of.</param>
        /// <returns>Hyperbolic sine of the specified angle.</returns>
        public static float Sinh(float x)
        {
            return (float)Math.Sinh(x);
        }

        /// <summary>
        ///   Returns the tangent of the specified angle in radians.
        /// </summary>
        /// <param name="x">Angle to get the tangent of.</param>
        /// <returns>Tangent of the specified angle.</returns>
        public static float Tan(float x)
        {
            return (float)Math.Tan(x);
        }

        /// <summary>
        ///   Returns the hyperbolic tangent of the specified angle in radians.
        /// </summary>
        /// <param name="x">Angle to get the hyperbolic tangent of.</param>
        /// <returns>Hyperbolic tangent of the specified angle.</returns>
        public static float Tanh(float x)
        {
            return (float)Math.Tanh(x);
        }

        #endregion
    }
}