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
            return (first.MaxX > second.X && first.X < second.MaxX)
                   && (first.MaxY > second.Y && first.Y < second.MaxY);
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
            return (first.MaxX > second.X && first.X < second.MaxX)
                   && (first.MaxY > second.Y && first.Y < second.MaxY);
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
            var topLeft = new Vector2F(rectangle.X, rectangle.Y);
            var bottomLeft = new Vector2F(rectangle.X, rectangle.MaxY);
            var topRight = new Vector2F(rectangle.MaxX, rectangle.Y);
            var bottomRight = new Vector2F(rectangle.MaxX, rectangle.MaxY);

            var left = new LineSegment2F(topLeft, bottomLeft);
            var right = new LineSegment2F(topRight, bottomRight);
            var top = new LineSegment2F(topLeft, topRight);
            var bottom = new LineSegment2F(bottomLeft, bottomRight);

            return left.Intersects(circle) || right.Intersects(circle) || top.Intersects(circle)
                   || bottom.Intersects(circle);
        }

        #endregion
    }
}