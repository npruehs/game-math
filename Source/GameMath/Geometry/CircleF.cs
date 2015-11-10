namespace GameMath
{
    using System;

    /// <summary>
    ///   Set of all points in a plane that are at a given distance from the center.
    ///   Note that circles are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct CircleF : IEquatable<CircleF>
    {
        #region Constants

        /// <summary>
        ///   Circle around the origin with radius one.
        /// </summary>
        public static readonly CircleF UnitCircle = new CircleF(Vector2F.Zero, 1.0f);

        #endregion

        #region Fields

        /// <summary>
        ///   Center of this circle.
        /// </summary>
        private readonly Vector2F center;

        /// <summary>
        ///   Radius of this circle.
        /// </summary>
        private readonly float radius;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new circle with the specified center and radius.
        /// </summary>
        /// <param name="center">Center of the circle.</param>
        /// <param name="radius">Radius of the circle.</param>
        public CircleF(Vector2F center, float radius)
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
        ///   Center of this circle.
        /// </summary>
        public Vector2F Center
        {
            get
            {
                return this.center;
            }
        }

        /// <summary>
        ///   Linear distance around the edge of this circle.
        /// </summary>
        public float Circumference
        {
            get
            {
                return Constants.Pi * this.Diameter;
            }
        }

        /// <summary>
        ///   Length of a straight line segment that passes through the center
        ///   of this circle and whose endpoints lie on the circle.
        /// </summary>
        public float Diameter
        {
            get
            {
                return 2 * this.Radius;
            }
        }

        /// <summary>
        ///   Radius of this circle.
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
        ///   Compares the passed circle to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Circle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both circles are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(CircleF other)
        {
            return this.center.Equals(other.center) && MathF.Equals(this.Radius, other.Radius);
        }

        /// <summary>
        ///   Compares the passed circle to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Circle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both circles are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is CircleF && this.Equals((CircleF)obj);
        }

        /// <summary>
        ///   Gets the hash code of this circle.
        /// </summary>
        /// <returns>
        ///   Hash code of this circle.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.center.GetHashCode() * 397) ^ this.radius.GetHashCode();
            }
        }

        /// <summary>
        ///   Compares the passed circles for equality.
        /// </summary>
        /// <param name="first">
        ///   First circle to compare.
        /// </param>
        /// <param name="second">
        ///   Second circle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both circles are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(CircleF first, CircleF second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed circles for inequality.
        /// </summary>
        /// <param name="first">
        ///   First circle to compare.
        /// </param>
        /// <param name="second">
        ///   Second circle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both circles are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(CircleF first, CircleF second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this circle.
        /// </summary>
        /// <returns>
        ///   This circle as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Center: {0}, Radius: {1}", this.Center, this.Radius);
        }

        #endregion
    }
}