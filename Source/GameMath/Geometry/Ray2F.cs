namespace GameMath
{
    using System;

    /// <summary>
    ///   Line starting at a specific point and proceeding indefinitely.
    ///   Note that rays are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct Ray2F : IEquatable<Ray2F>
    {
        #region Fields

        /// <summary>
        ///   Direction vector of this ray.
        /// </summary>
        private readonly Vector2F direction;

        /// <summary>
        ///   Origin point of this ray.
        /// </summary>
        private readonly Vector2F origin;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new ray with the specified origin and direction.
        /// </summary>
        /// <param name="origin">Origin point of the ray.</param>
        /// <param name="direction">Direction vector of the ray.</param>
        public Ray2F(Vector2F origin, Vector2F direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Direction vector of this ray.
        /// </summary>
        public Vector2F Direction
        {
            get
            {
                return this.direction;
            }
        }

        /// <summary>
        ///   Origin point of this ray.
        /// </summary>
        public Vector2F Origin
        {
            get
            {
                return this.origin;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Compares the passed ray to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Ray to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rays are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(Ray2F other)
        {
            return this.origin.Equals(other.origin) && this.direction.Equals(other.direction);
        }

        /// <summary>
        ///   Compares the passed ray to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Ray to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rays are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Ray2F && this.Equals((Ray2F)obj);
        }

        /// <summary>
        ///   Gets the hash code of this ray.
        /// </summary>
        /// <returns>
        ///   Hash code of this ray.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.origin.GetHashCode() * 397) ^ this.direction.GetHashCode();
            }
        }

        /// <summary>
        ///   Gets the point with the specified distance from the origin on this ray.
        /// </summary>
        /// <param name="t">Distance from the ray origin.</param>
        /// <returns>Point with the specified distance from the origin on this ray.</returns>
        public Vector2F GetPoint(float t)
        {
            return this.origin + this.direction * t;
        }

        /// <summary>
        ///   Compares the passed rays for equality.
        /// </summary>
        /// <param name="first">
        ///   First ray to compare.
        /// </param>
        /// <param name="second">
        ///   Second ray to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rays are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Ray2F first, Ray2F second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed rays for inequality.
        /// </summary>
        /// <param name="first">
        ///   First ray to compare.
        /// </param>
        /// <param name="second">
        ///   Second ray to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rays are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(Ray2F first, Ray2F second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this ray.
        /// </summary>
        /// <returns>
        ///   This ray as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Origin: {0}, Direction: {1}", this.origin, this.direction);
        }

        #endregion
    }
}