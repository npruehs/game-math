namespace GameMath
{
    using System;

    /// <summary>
    ///   Part of a line that is bounded by two distinct end points. Note that line segments are immutable.
    /// </summary>
    /// <seealso cref="LineSegment2I"/>
    /// <seealso cref="LineSegment3F"/>
    /// <seealso cref="LineSegment3I"/>
    [CLSCompliant(true)]
    public struct LineSegment2F : IEquatable<LineSegment2F>
    {
        #region Fields

        /// <summary>
        ///   First point of this line segment.
        /// </summary>
        private readonly Vector2F p;

        /// <summary>
        ///   Second point of this line segment.
        /// </summary>
        private readonly Vector2F q;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new line segment between the specified points.
        /// </summary>
        /// <param name="p">First point of the line segment.</param>
        /// <param name="q">Second point of the line segment.</param>
        public LineSegment2F(Vector2F p, Vector2F q)
        {
            this.p = p;
            this.q = q;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Length of this line segment.
        /// </summary>
        public float Length
        {
            get
            {
                return this.p.Distance(this.q);
            }
        }

        /// <summary>
        ///   Squared length of this line segment.
        ///   Faster than <see cref="Length" />.
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return this.p.DistanceSquared(this.q);
            }
        }

        /// <summary>
        ///   First point of this line segment.
        /// </summary>
        public Vector2F P
        {
            get
            {
                return this.p;
            }
        }

        /// <summary>
        ///   Second point of this line segment.
        /// </summary>
        public Vector2F Q
        {
            get
            {
                return this.q;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether the passed point lies on this line segment.
        /// </summary>
        /// <remarks>
        ///   http://stackoverflow.com/questions/7050186/find-if-point-lays-on-line-segment
        /// </remarks>
        /// <param name="point">Point to check.</param>
        /// <returns>
        ///   <c>true</c>, if the passed point lies on this line segment, and
        ///   <c>false</c>, otherwise.
        /// </returns>
        public bool Contains(Vector2F point)
        {
            var ab =
                Math.Sqrt((this.Q.X - this.P.X) * (this.Q.X - this.P.X) + (this.Q.Y - this.P.Y) * (this.Q.Y - this.P.Y));
            var ap = Math.Sqrt(
                (point.X - this.P.X) * (point.X - this.P.X) + (point.Y - this.P.Y) * (point.Y - this.P.Y));
            var pb = Math.Sqrt(
                (this.Q.X - point.X) * (this.Q.X - point.X) + (this.Q.Y - point.Y) * (this.Q.Y - point.Y));

            return Math.Abs(ab - (ap + pb)) < float.Epsilon;
        }

        /// <summary>
        ///   Compares the passed line segment to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Line segment to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both line segments are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(LineSegment2F other)
        {
            return this.p.Equals(other.p) && this.q.Equals(other.q);
        }

        /// <summary>
        ///   Compares the passed line segment to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Line segment to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both line segments are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is LineSegment2F && this.Equals((LineSegment2F)obj);
        }

        /// <summary>
        ///   Gets the shortest distance of the specified point to this line segment.
        /// </summary>
        /// <remarks>
        ///   See http://stackoverflow.com/questions/849211/shortest-distance-between-a-point-and-a-line-segment
        ///   for details.
        /// </remarks>
        /// <param name="point">Point to get the distance of.</param>
        /// <returns>Shortest distance of the specified point to this line segment.</returns>
        public float GetDistance(Vector2F point)
        {
            var t = Vector2F.Dot(point - this.P, this.Q - this.P) / this.LengthSquared;

            // Check if point is beyond start (P) of this segment.
            if (t < 0.0f)
            {
                return this.P.Distance(point);
            }

            // Check if point is beyond end (Q) of this segment.
            if (t > 1.0f)
            {
                return this.Q.Distance(point);
            }

            // Projection falls onto this segment.
            var projection = point + t * (this.Q - this.P);
            return this.P.Distance(projection);
        }

        /// <summary>
        ///   Gets the hash code of this line segment.
        /// </summary>
        /// <returns>
        ///   Hash code of this line segment.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.p.GetHashCode() * 397) ^ this.q.GetHashCode();
            }
        }

        /// <summary>
        ///   Compares the passed line segments for equality.
        /// </summary>
        /// <param name="first">
        ///   First line segment to compare.
        /// </param>
        /// <param name="second">
        ///   Second line segment to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both line segments are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(LineSegment2F first, LineSegment2F second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed line segments for inequality.
        /// </summary>
        /// <param name="first">
        ///   First line segment to compare.
        /// </param>
        /// <param name="second">
        ///   Second line segment to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both line segments are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(LineSegment2F first, LineSegment2F second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this line segment.
        /// </summary>
        /// <returns>
        ///   This line segment as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("P: {0}, Q: {1}", this.p, this.q);
        }

        #endregion
    }
}