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
        ///   Returns the angle between the specified vectors in radians.
        /// </summary>
        /// <remarks>
        ///   See http://www.euclideanspace.com/maths/algebra/vectors/angleBetween/index.htm for details.
        /// </remarks>
        /// <param name="v">First vector.</param>
        /// <param name="w">Second vector.</param>
        /// <returns>Angle between the specified vectors in radians.</returns>
        public static float Between(Vector2F v, Vector2F w)
        {
            return Atan2(w.Y, w.X) - Atan2(v.Y, v.X);
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
            return degrees * Constant.DegreesToRadians;
        }

        /// <summary>
        ///   Shortest difference between the specified angles in radians.
        ///   Think of this as "how do get from angle y to x".
        ///   Example: Delta(3/2 Pi, 0) will return -1/2 Pi.
        /// </summary>
        /// <remarks>
        ///   See http://stackoverflow.com/questions/1878907/the-smallest-difference-between-2-angles
        ///   for details.
        /// </remarks>
        /// <param name="x">First angle.</param>
        /// <param name="y">Second angle.</param>
        /// <returns>Shortest difference between the specified angles.</returns>
        public static float Delta(float x, float y)
        {
            // x - y gives you the difference in angle, but it may be out of the desired bounds.
            // Think of this angle defining x point on the unit circle. The coordinates of that point are (cos(x - y), sin(x - y)).
            // Atan2 returns the angle for that point (which is equivalent to x - y) except its range is [-PI, PI].
            return Atan2(Sin(x - y), Cos(x - y));
        }

        /// <summary>
        ///   Returns the angle between the specified vector and the x-axis.
        ///   Example: FromVector(0.5, 0.5) will return DegreesToRadians(45).
        /// </summary>
        /// <remarks>
        ///   See http://stackoverflow.com/questions/6247153/angle-from-2d-unit-vector for details.
        /// </remarks>
        /// <param name="v">Vector to get the angle of.</param>
        /// <returns>Angle between the specified vector and the x-axis.</returns>
        public static float FromVector(Vector2F v)
        {
            var normalized = v.Normalize();
            return Atan2(normalized.Y, normalized.X);
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
            return degrees * Constant.RadiansToDegrees;
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