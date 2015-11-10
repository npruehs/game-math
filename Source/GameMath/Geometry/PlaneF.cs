namespace GameMath
{
    using System;

    /// <summary>
    ///   Flat, two-dimensional surface.
    ///   Note that planes are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct PlaneF : IEquatable<PlaneF>
    {
        #region Constants

        /// <summary>
        ///   Plane going through the origin with the z axis as normal.
        /// </summary>
        public static readonly PlaneF XYPlane = new PlaneF(Vector3F.UnitZ, Vector3F.Zero);

        /// <summary>
        ///   Plane going through the origin with the y axis as normal.
        /// </summary>
        public static readonly PlaneF XZPlane = new PlaneF(Vector3F.UnitY, Vector3F.Zero);

        /// <summary>
        ///   Plane going through the origin with the x axis as normal.
        /// </summary>
        public static readonly PlaneF YZPlane = new PlaneF(Vector3F.UnitX, Vector3F.Zero);

        #endregion

        #region Fields

        /// <summary>
        ///   Vector orthogonal to this plane.
        /// </summary>
        private readonly Vector3F normal;

        /// <summary>
        ///   Point in this plane.
        /// </summary>
        private readonly Vector3F point;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new plane with the specified point and normal.
        /// </summary>
        /// <param name="point">Point in the plane.</param>
        /// <param name="normal">Vector orthogonal to the plane.</param>
        public PlaneF(Vector3F point, Vector3F normal)
        {
            this.point = point;
            this.normal = normal;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Vector orthogonal to this plane.
        /// </summary>
        public Vector3F Normal
        {
            get
            {
                return this.normal;
            }
        }

        /// <summary>
        ///   Point in this plane.
        /// </summary>
        public Vector3F Point
        {
            get
            {
                return this.point;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Compares the passed plane to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Plane to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both planes are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(PlaneF other)
        {
            return this.normal.Equals(other.normal) && this.point.Equals(other.point);
        }

        /// <summary>
        ///   Compares the passed plane to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Plane to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both planes are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is PlaneF && this.Equals((PlaneF)obj);
        }

        /// <summary>
        ///   Gets the hash code of this plane.
        /// </summary>
        /// <returns>
        ///   Hash code of this plane.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.normal.GetHashCode() * 397) ^ this.point.GetHashCode();
            }
        }

        /// <summary>
        ///   Compares the passed planes for equality.
        /// </summary>
        /// <param name="first">
        ///   First plane to compare.
        /// </param>
        /// <param name="second">
        ///   Second plane to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both planes are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(PlaneF first, PlaneF second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed planes for inequality.
        /// </summary>
        /// <param name="first">
        ///   First plane to compare.
        /// </param>
        /// <param name="second">
        ///   Second plane to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both planes are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(PlaneF first, PlaneF second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this plane.
        /// </summary>
        /// <returns>
        ///   This plane as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Point: {0}, Normal: {1}", this.Point, this.Normal);
        }

        #endregion
    }
}