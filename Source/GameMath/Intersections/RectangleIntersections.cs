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

        #endregion
    }
}