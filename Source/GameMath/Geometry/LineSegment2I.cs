namespace GameMath
{
    using System;

    /// <summary>
    ///   Part of a line that is bounded by two distinct end points. Note that line segments are immutable.
    /// </summary>
    /// <seealso cref="LineSegment2F"/>
    /// <seealso cref="LineSegment3F"/>
    /// <seealso cref="LineSegment3I"/>
    [CLSCompliant(true)]
    public struct LineSegment2I : IEquatable<LineSegment2I>
    {
        #region Fields

        /// <summary>
        ///   First point of this line segment.
        /// </summary>
        private readonly Vector2I p;

        /// <summary>
        ///   Second point of this line segment.
        /// </summary>
        private readonly Vector2I q;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new line segment between the specified points.
        /// </summary>
        /// <param name="p">First point of the line segment.</param>
        /// <param name="q">Second point of the line segment.</param>
        public LineSegment2I(Vector2I p, Vector2I q)
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
        public Vector2I P
        {
            get
            {
                return this.p;
            }
        }

        /// <summary>
        ///   Second point of this line segment.
        /// </summary>
        public Vector2I Q
        {
            get
            {
                return this.q;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Compares the passed line segment to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Line segment to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both line segments are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(LineSegment2I other)
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
            return obj is LineSegment2I && this.Equals((LineSegment2I)obj);
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
        public static bool operator ==(LineSegment2I first, LineSegment2I second)
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
        public static bool operator !=(LineSegment2I first, LineSegment2I second)
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