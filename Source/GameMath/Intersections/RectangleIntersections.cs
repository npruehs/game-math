namespace GameMath
{
    using System;

    /// <summary>
    ///   Intersection tests for rectangles.
    /// </summary>
    [CLSCompliant(true)]
    public static class RectangleIntersection
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the two specified rectangles at least partially intersect each other.
        /// </summary>
        /// <param name="first">
        ///   First rectangle to check.
        /// </param>
        /// <param name="second">
        ///   Second rectangle to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if the two rectangles intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(this RectangleF first, RectangleF second)
        {
            return (first.Right > second.Left && first.Left < second.Right)
                   && (first.Bottom > second.Top && first.Top < second.Bottom);
        }

        /// <summary>
        ///   Checks whether the two specified rectangles at least partially intersect each other.
        /// </summary>
        /// <param name="first">
        ///   First rectangle to check.
        /// </param>
        /// <param name="second">
        ///   Second rectangle to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if the two rectangles intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(this RectangleI first, RectangleI second)
        {
            return (first.Right > second.Left && first.Left < second.Right)
                   && (first.Bottom > second.Top && first.Top < second.Bottom);
        }

        /// <summary>
        ///   Checks whether the specified rectangle intersects the passed circle.
        /// </summary>
        /// <param name="rectangle">
        ///   Rectangle to check.
        /// </param>
        /// <param name="circle">
        ///   Circle to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if rectangle and circle intersect each other, and <c>false</c> otherwise.
        /// </returns>
        public static bool Intersects(this RectangleF rectangle, CircleF circle)
        {
            // Check if rectangle contains center.
            if (rectangle.Contains(circle.Center))
            {
                return true;
            }

            // Check each edge.
            var left = new LineSegment2F(rectangle.TopLeft, rectangle.BottomLeft);
            var right = new LineSegment2F(rectangle.TopRight, rectangle.BottomRight);
            var top = new LineSegment2F(rectangle.TopLeft, rectangle.TopRight);
            var bottom = new LineSegment2F(rectangle.BottomLeft, rectangle.BottomRight);

            return left.Intersects(circle) || right.Intersects(circle) || top.Intersects(circle)
                   || bottom.Intersects(circle);
        }

        #endregion
    }
}