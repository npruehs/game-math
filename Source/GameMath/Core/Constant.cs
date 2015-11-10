namespace GameMath
{
    using System;

    /// <summary>
    ///   Common math constants.
    /// </summary>
    [CLSCompliant(true)]
    public static class Constant
    {
        #region Constants

        /// <summary>
        ///   Factor converting angles in degrees to radians.
        /// </summary>
        public const float DegreesToRadians = Pi / 180.0f;

        /// <summary>
        ///   Base of the natural logarithm.
        /// </summary>
        public const float E = 2.7182818284590452354f;

        /// <summary>
        ///   Math constant Pi.
        /// </summary>
        public const float Pi = 3.1415926535897932384626433832795f;

        /// <summary>
        ///   Math constant Pi divided by four.
        /// </summary>
        public const float PiOverFour = Pi / 4;

        /// <summary>
        ///   Math constant Pi divided by two.
        /// </summary>
        public const float PiOverTwo = Pi / 2;

        /// <summary>
        ///   Square of math constant Pi.
        /// </summary>
        public const float PiSquared = Pi * Pi;

        /// <summary>
        ///   Factor converting angles in radians to degrees.
        /// </summary>
        public const float RadiansToDegrees = 180.0f / Pi;

        /// <summary>
        ///   Sine of 45 degrees.
        /// </summary>
        public const float Sin45 = 0.70710678118654752440084436210485f;

        /// <summary>
        ///   Math constant Pi times two.
        /// </summary>
        public const float TwoPi = Pi * 2.0f;

        #endregion
    }
}