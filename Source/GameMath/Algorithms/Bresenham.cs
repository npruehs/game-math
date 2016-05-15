namespace GameMath
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///   Optimized version of the Bresenham line algorithm that finds an
    ///   approximation to a straight line between two given points.
    /// </summary>
    [CLSCompliant(true)]
    public static class Bresenham
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Returns an approximation to a straight line between the given points.
        /// </summary>
        /// <remarks>
        ///   http://rosettacode.org/wiki/Bitmap/Bresenham's_line_algorithm
        /// </remarks>
        /// <param name="p">
        ///   First line endpoint.
        /// </param>
        /// <param name="q">
        ///   Second line endpoint.
        /// </param>
        /// <returns>
        ///   Approximation to a straight line between the given points.
        /// </returns>
        public static List<Vector2I> Plot(Vector2I p, Vector2I q)
        {
            var line = new List<Vector2I>();

            int x0;
            int x1;
            int y0;
            int y1;

            var steep = Math.Abs(q.Y - p.Y) > Math.Abs(q.X - p.X);

            if (steep)
            {
                // swap(x0, y0)
                x0 = p.Y;
                y0 = p.X;

                // swap(x1, y1)
                x1 = q.Y;
                y1 = q.X;
            }
            else
            {
                x0 = p.X;
                y0 = p.Y;

                x1 = q.X;
                y1 = q.Y;
            }

            if (x0 > x1)
            {
                // swap(x0, x1)
                var tmp = x0;
                x0 = x1;
                x1 = tmp;

                // swap(y0, y1)
                tmp = y0;
                y0 = y1;
                y1 = tmp;
            }

            var deltaX = x1 - x0;
            var deltaY = Math.Abs(y1 - y0);

            var error = 0d;
            var deltaErr = deltaY / (double)deltaX;

            var stepY = (y0 < y1) ? 1 : -1;
            var y = y0;

            for (var x = x0; x <= x1; x++)
            {
                var point = steep ? new Vector2I(y, x) : new Vector2I(x, y);
                line.Add(point);

                error += deltaErr;

                if (error >= 0.5f)
                {
                    y += stepY;
                    error -= 1.0f;
                }
            }

            return line;
        }

        #endregion
    }
}