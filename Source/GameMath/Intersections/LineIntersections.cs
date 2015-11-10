namespace GameMath
{
    using System;

    /// <summary>
    ///   Intersection tests for line segments.
    /// </summary>
    [CLSCompliant(true)]
    public static class LineIntersections
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the specified line intersects the passed circle.
        /// </summary>
        /// <param name="line">
        ///   Line to check.
        /// </param>
        /// <param name="circle">
        ///   Circle to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if line and circle intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(this LineSegment2F line, CircleF circle)
        {
            return line.GetDistance(circle.Center) < circle.Radius;
        }

        /// <summary>
        ///   Checks whether the specified line intersects the passed circle.
        /// </summary>
        /// <param name="line">
        ///   Line to check.
        /// </param>
        /// <param name="circle">
        ///   Circle to check.
        /// </param>
        /// <param name="first">
        ///   First intersection point, if found.
        /// </param>
        /// <param name="second">
        ///   Second intersection point, if found.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if line and circle intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(
            this LineSegment2F line,
            CircleF circle,
            out Vector2F? first,
            out Vector2F? second)
        {
            // http://devmag.org.za/2009/04/17/basic-collision-detection-in-2d-part-2/

            // Transform to local coordinates.
            var localPointA = line.P - circle.Center;
            var localPointB = line.Q - circle.Center;

            // Precalculate this value. We use it often.
            var localPointBMinusA = localPointB - localPointA;

            var a = (localPointBMinusA.X) * (localPointBMinusA.X) + (localPointBMinusA.Y) * (localPointBMinusA.Y);
            var b = 2 * ((localPointBMinusA.X * localPointA.X) + (localPointBMinusA.Y * localPointA.Y));
            var c = (localPointA.X * localPointA.X) + (localPointA.Y * localPointA.Y) - (circle.Radius * circle.Radius);
            var delta = b * b - (4 * a * c);

            if (delta < 0)
            {
                // No intersection.
                first = null;
                second = null;
                return false;
            }

            if (delta > 0)
            {
                // Two intersections.
                var squareRootDelta = MathF.Sqrt(delta);

                var u1 = (-b + squareRootDelta) / (2 * a);
                var u2 = (-b - squareRootDelta) / (2 * a);

                // Use line point instead of local point because we want our answer in global space, not the circle's local space.
                first = line.P + (u1 * localPointBMinusA);
                second = line.P + (u2 * localPointBMinusA);
                return true;
            }

            // One intersection.
            var u = -b / (2 * a);

            first = line.P + (u * localPointBMinusA);
            second = null;
            return true;
        }

        #endregion
    }
}