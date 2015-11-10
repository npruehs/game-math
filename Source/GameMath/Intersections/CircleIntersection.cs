namespace GameMath
{
    using System;

    /// <summary>
    ///   Intersection tests for circles.
    /// </summary>
    [CLSCompliant(true)]
    public static class CircleIntersection
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the specified circle intersects the passed line.
        /// </summary>
        /// <param name="circle">
        ///   Circle to check.
        /// </param>
        /// <param name="line">
        ///   Line to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if circle and line intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(this CircleF circle, LineSegment2F line)
        {
            return line.Intersects(circle);
        }

        /// <summary>
        ///   Checks whether the specified circle intersects the passed line.
        /// </summary>
        /// <param name="circle">
        ///   Circle to check.
        /// </param>
        /// <param name="line">
        ///   Line to check.
        /// </param>
        /// <param name="first">
        ///   First intersection point, if found.
        /// </param>
        /// <param name="second">
        ///   Second intersection point, if found.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if circle and line intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(
            this CircleF circle,
            LineSegment2F line,
            out Vector2F? first,
            out Vector2F? second)
        {
            return line.Intersects(circle, out first, out second);
        }

        #endregion
    }
}