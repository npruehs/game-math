namespace GameMath
{
    using System;

    /// <summary>
    ///   Common math operations on angles.
    /// </summary>
    [CLSCompliant(true)]
    public static class Angle
    {
        #region Public Methods and Operators

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

        #endregion
    }
}