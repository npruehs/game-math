namespace GameMath
{
    using System;

    /// <summary>
    ///   Set of all points that are at a given distance from the center, in three-dimensional space.
    ///   Note that spheres are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct SphereF : IEquatable<SphereF>
    {
        #region Constants

        /// <summary>
        ///   Sphere around the origin with radius one.
        /// </summary>
        public static readonly SphereF UnitSphere = new SphereF(Vector2F.Zero, 1.0f);

        #endregion

        #region Fields

        /// <summary>
        ///   Center of this sphere.
        /// </summary>
        private readonly Vector3F center;

        /// <summary>
        ///   Radius of this sphere.
        /// </summary>
        private readonly float radius;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new sphere with the specified center and radius.
        /// </summary>
        /// <param name="center">Center of the sphere.</param>
        /// <param name="radius">Radius of the sphere.</param>
        public SphereF(Vector3F center, float radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius has to be positive", "radius");
            }

            this.center = center;
            this.radius = radius;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Center of this sphere.
        /// </summary>
        public Vector3F Center
        {
            get
            {
                return this.center;
            }
        }

        /// <summary>
        ///   Radius of this sphere.
        /// </summary>
        public float Radius
        {
            get
            {
                return this.radius;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Compares the passed sphere to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Sphere to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both spheres are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(SphereF other)
        {
            return this.Center.Equals(other.Center) && MathF.Equals(this.Radius, other.Radius);
        }

        /// <summary>
        ///   Compares the passed sphere to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Sphere to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both spheres are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is SphereF && this.Equals((SphereF)obj);
        }

        /// <summary>
        ///   Gets the hash code of this sphere.
        /// </summary>
        /// <returns>
        ///   Hash code of this sphere.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.center.GetHashCode() * 397) ^ this.radius.GetHashCode();
            }
        }

        /// <summary>
        ///   Compares the passed spheres for equality.
        /// </summary>
        /// <param name="first">
        ///   First sphere to compare.
        /// </param>
        /// <param name="second">
        ///   Second sphere to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both spheres are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(SphereF first, SphereF second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed spheres for inequality.
        /// </summary>
        /// <param name="first">
        ///   First sphere to compare.
        /// </param>
        /// <param name="second">
        ///   Second sphere to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both spheres are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(SphereF first, SphereF second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this sphere.
        /// </summary>
        /// <returns>
        ///   This sphere as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Center: {0}, Radius: {1}", this.Center, this.Radius);
        }

        #endregion
    }
}