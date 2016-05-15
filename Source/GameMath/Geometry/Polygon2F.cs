namespace GameMath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///   Polygon in two-dimensional space with floating point points.
    /// </summary>
    [CLSCompliant(true)]
    public class Polygon2F : IEquatable<Polygon2F>
    {
        #region Fields

        /// <summary>
        ///   Edges bounding this polygon.
        /// </summary>
        private readonly List<LineSegment2F> edges;

        /// <summary>
        ///   Points of this polygon.
        /// </summary>
        private readonly IList<Vector2F> points;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new polygon with the specified points.
        /// </summary>
        /// <param name="points">Points making up the new polygon.</param>
        public Polygon2F(IEnumerable<Vector2F> points)
            : this(points.ToList())
        {
        }

        /// <summary>
        ///   Constructs a new polygon with the specified points.
        /// </summary>
        /// <param name="points">Points making up the new polygon.</param>
        public Polygon2F(IList<Vector2F> points)
        {
            if (points.Count < 3)
            {
                throw new ArgumentException("Polygon must consist of at least three points.", "points");
            }

            this.points = points;

            // Build edges.
            this.edges = new List<LineSegment2F>();

            for (var i = 0; i < this.points.Count; i++)
            {
                var edge = new LineSegment2F(this.points[i], this.points[(i + 1) % this.points.Count]);
                this.edges.Add(edge);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the area of this polygon.
        /// </summary>
        /// <remarks>
        ///   See http://alienryderflex.com/polygon_area/ for details.
        /// </remarks>
        public float Area
        {
            get
            {
                var area = 0.0f;

                var i = this.points.Count - 1;
                var j = i;

                for (i = 0; i < this.points.Count; i++)
                {
                    var pointI = this.Points[i];
                    var pointJ = this.Points[j];

                    area += (pointJ.X + pointI.X) * (pointJ.Y - pointI.Y);
                    j = i;
                }

                return area / 2;
            }
        }

        /// <summary>
        ///   Edges bounding this polygon.
        /// </summary>
        public IList<LineSegment2F> Edges
        {
            get
            {
                return this.edges;
            }
        }

        /// <summary>
        ///   Points of this polygon.
        /// </summary>
        public IList<Vector2F> Points
        {
            get
            {
                return this.points;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether this polygon fully contains the passed line segment.
        /// </summary>
        /// <param name="lineSegment">Line segment to check.</param>
        /// <returns>
        ///   <c>true</c>, if this polygon fully contains <paramref name="lineSegment" />, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public bool Contains(LineSegment2F lineSegment)
        {
            // Check whether any of the edges intersect with the line.
            if (this.Edges.Any(edge => lineSegment.Intersects(edge)))
            {
                return false;
            }

            // Check whether the line endpoints are inside the polygon.
            return this.Contains(lineSegment.P) && this.Contains(lineSegment.Q);
        }

        /// <summary>
        ///   Checks whether this polygon fully contains the passed other polygon.
        /// </summary>
        /// <param name="other">Polygon to check.</param>
        /// <returns>
        ///   <c>true</c>, if this polygon fully contains <paramref name="other" />, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public bool Contains(Polygon2F other)
        {
            return other.points.All(this.Contains);
        }

        /// <summary>
        ///   Checks whether this polygon contains the passed point.
        /// </summary>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Point_in_polygon,
        ///   https://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon/2922778
        ///   and http://web.archive.org/web/20120323102807/http:/local.wasp.uwa.edu.au/~pbourke/geometry/insidepoly/
        ///   for details.
        /// </remarks>
        /// <param name="point">Point to check.</param>
        /// <returns>
        ///   <c>true</c>, if this polygon <paramref name="point" />, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public bool Contains(Vector2F point)
        {
            // Check how often a ray from the point intersects with the polygon edges.
            var j = this.points.Count - 1;
            var inside = false;

            for (var i = 0; i < this.points.Count; j = i++)
            {
                var vertex = this.points[i];
                var prevVertex = this.points[j];

                // Check for intersection of ray from point and polygon edge.
                if (vertex.Y > point.Y == prevVertex.Y > point.Y)
                {
                    continue;
                }

                var edgeX = (prevVertex.X - vertex.X) * (point.Y - vertex.Y) / (prevVertex.Y - vertex.Y) + vertex.X;
                if (point.X < edgeX)
                {
                    // Flip result on intersection.
                    inside = !inside;
                }
            }

            if (inside)
            {
                return true;
            }

            // Check if lies on edge.
            return this.Points.Contains(point);
        }

        /// <summary>
        ///   Compares the passed polygon to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Polygon to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both polygons are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(Polygon2F other)
        {
            return this.Points.SequenceEqual(other.Points);
        }

        /// <summary>
        ///   Compares the passed polygon to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Polygon to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both polygons are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Polygon2F && this.Equals((Polygon2F)obj);
        }

        /// <summary>
        ///   Gets the hash code of this polygon.
        /// </summary>
        /// <returns>
        ///   Hash code of this polygon.
        /// </returns>
        public override int GetHashCode()
        {
            return (this.points != null ? this.Points.GetHashCode() : 0);
        }

        /// <summary>
        ///   Checks if the points of this polygon are in clockwise or counter-clockwise order.
        /// </summary>
        /// <remarks>
        ///   See http://stackoverflow.com/questions/1165647/how-to-determine-if-a-list-of-polygon-points-are-in-clockwise-order
        ///   for details.
        /// </remarks>
        /// <returns>
        ///   <c>true</c>, if the points of this polygon are in clockwise order, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public bool IsClockwise()
        {
            float sum = 0;
            for (var index = 0; index < this.points.Count; index++)
            {
                var point = this.points[index];
                var nextPoint = this.points[(index + 1) % this.points.Count];
                sum += (nextPoint.X - point.X) * (nextPoint.Y + point.Y);
            }
            return sum >= 0;
        }

        /// <summary>
        ///   Compares the passed polygons for equality.
        /// </summary>
        /// <param name="first">
        ///   First polygon to compare.
        /// </param>
        /// <param name="second">
        ///   Second polygon to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both polygons are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Polygon2F first, Polygon2F second)
        {
            return Equals(first, second);
        }

        /// <summary>
        ///   Compares the passed polygons for inequality.
        /// </summary>
        /// <param name="first">
        ///   First polygon to compare.
        /// </param>
        /// <param name="second">
        ///   Second polygon to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both polygon are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(Polygon2F first, Polygon2F second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this polygon.
        /// </summary>
        /// <returns>
        ///   This polygon as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("[");

            for (var i = 0; i < this.points.Count; ++i)
            {
                stringBuilder.Append(this.points[i]);

                if (i < this.points.Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        /// <summary>
        ///   Decomposes this polygon into triangles.
        /// </summary>
        /// <remarks>
        ///   See http://www.geometrictools.com/Documentation/TriangulationByEarClipping.pdf for details.
        /// </remarks>
        /// <returns>Triangles composing this polygon.</returns>
        public List<Polygon2F> Triangulate()
        {
            var triangles = new List<Polygon2F>();
            var vertices = new List<Vector2F>(this.points);

            if (this.IsClockwise())
            {
                vertices.Reverse();
            }

            // Remove ears one by one.
            var index = 0;

            while (vertices.Count > 3)
            {
                var remainingPolygon = new Polygon2F(vertices);

                // Get three consecutive vertices.
                var u = vertices[(index - 1 + vertices.Count) % vertices.Count];
                var v = vertices[index % vertices.Count];
                var w = vertices[(index + 1) % vertices.Count];

                // Check if middle vertex is convex.
                var vu = u - v;
                var vw = w - v;

                var angle = Angle.Between(vw, vu);
                var convex = angle < Math.PI;

                if (!convex)
                {
                    ++index;
                    continue;
                }

                // Check if line segment lies completely inside the polygon.
                var uw = new LineSegment2F(u, w);

                if (!remainingPolygon.Contains(uw))
                {
                    ++index;
                    continue;
                }

                // Check if no other vertices of the polygon are contained in the triangle.
                var triangle =
                    new Polygon2F(new[] { new Vector2F(u.X, u.Y), new Vector2F(v.X, v.Y), new Vector2F(w.X, w.Y) });

                var containsOtherVertex =
                    vertices.Where(other => other != u && other != v && other != w)
                        .Any(other => triangle.Contains(other));

                if (containsOtherVertex)
                {
                    ++index;
                    continue;
                }

                // Remove ear.
                vertices.Remove(v);
                triangles.Add(triangle);
            }

            // Add last triangle.
            triangles.Add(new Polygon2F(vertices));
            return triangles;
        }

        #endregion
    }
}