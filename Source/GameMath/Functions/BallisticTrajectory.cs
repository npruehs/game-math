namespace GameMath
{
    using System;

    /// <summary>
    ///   Path that a thrown or launched projectile or missile will take under the action of gravity,
    ///   neglecting all other forces, such as friction from aerodynamic drag, without propulsion.
    /// </summary>
    /// <remarks>
    ///   https://en.wikipedia.org/wiki/Trajectory_of_a_projectile
    /// </remarks>
    [CLSCompliant(true)]
    public static class BallisticTrajectory
    {
        #region Constants

        /// <summary>
        ///   Gravity of Earth. Acceleration that the Earth imparts to objects on or near its surface due to gravity.
        /// </summary>
        private const float G = 9.8067f;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Angle at which a projectile with initial velocity <paramref name="v" /> must be launched
        ///   in order to go a distance <paramref name="d" />.
        /// </summary>
        /// <param name="d">Target distance of the projectile.</param>
        /// <param name="v">Initial projectile velocity</param>
        /// <returns>Recommended launch angle.</returns>
        public static float AngleOfReach(float d, float v)
        {
            return 0.5f * Angle.Asin(G * d / (v * v));
        }

        /// <summary>
        ///   Height of a projectile with initial velocity <paramref name="v" /> launched at angle
        ///   <paramref name="theta" /> in radians after it has traveled distance <paramref name="x" />.
        /// </summary>
        /// <param name="x">Position to get the projectile height at.</param>
        /// <param name="theta">Projectile launch angle.</param>
        /// <param name="v">Initial projectile velocity.</param>
        /// <returns>Projectile height after the specified distance.</returns>
        public static float Height(float x, float theta, float v)
        {
            return x * Angle.Tan(theta) - ((G * (x * x)) / (2 * MathF.Pow(v * Angle.Cos(theta), 2)));
        }

        #endregion
    }
}