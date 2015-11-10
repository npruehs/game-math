namespace GameMath
{
    using System;

    /// <summary>
    ///   Intersection tests for boxes.
    /// </summary>
    [CLSCompliant(true)]
    public static class BoxIntersection
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the two specified boxes at least partially intersect each other.
        /// </summary>
        /// <param name="first">
        ///   First box to check.
        /// </param>
        /// <param name="second">
        ///   Second box to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if the two boxes intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(this BoxF first, BoxF second)
        {
            return (first.MaxX > second.X && first.X < second.MaxX)
                   && (first.MaxY > second.Y && first.Y < second.MaxY)
                   && (first.MaxZ > second.Z && first.Z < second.MaxZ);
        }

        /// <summary>
        ///   Checks whether the two specified boxes at least partially intersect each other.
        /// </summary>
        /// <param name="first">
        ///   First box to check.
        /// </param>
        /// <param name="second">
        ///   Second box to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if the two boxes intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(this BoxI first, BoxI second)
        {
            return (first.MaxX > second.X && first.X < second.MaxX)
                   && (first.MaxY > second.Y && first.Y < second.MaxY)
                   && (first.MaxZ > second.Z && first.Z < second.MaxZ);
        }

        #endregion
    }
}