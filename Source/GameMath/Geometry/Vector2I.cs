namespace GameMath
{
    using System;

    /// <summary>
    ///   Vector in two-dimensional space with integer components. Note that vectors are immutable.
    /// </summary>
    /// <seealso cref="Vector2F"/>
    /// <seealso cref="Vector3F"/>
    /// <seealso cref="Vector3I"/>
    [CLSCompliant(true)]
    public struct Vector2I : IEquatable<Vector2I>
    {
        #region Constants

        /// <summary>
        ///   Unit vector in direction of the x axis.
        /// </summary>
        public static readonly Vector2I UnitX = new Vector2I(1, 0);

        /// <summary>
        ///   Unit vector in direction of the y axis.
        /// </summary>
        public static readonly Vector2I UnitY = new Vector2I(0, 1);

        /// <summary>
        ///   Null vector.
        /// </summary>
        public static readonly Vector2I Zero = new Vector2I();

        #endregion

        #region Fields

        /// <summary>
        ///   X-component of this vector.
        /// </summary>
        private readonly int x;

        /// <summary>
        ///   Y-component of this vector.
        /// </summary>
        private readonly int y;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new vector with the specified components.
        /// </summary>
        /// <param name="x">
        ///   X-component of the new vector.
        /// </param>
        /// <param name="y">
        ///   Y-component of the new vector.
        /// </param>
        public Vector2I(int x, int y)
            : this()
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the magnitude of this vector.
        /// </summary>
        public float Length
        {
            get
            {
                return MathF.Sqrt(this.LengthSquared);
            }
        }

        /// <summary>
        ///   Gets the squared magnitude of this vector. Faster than <see cref="Length" />.
        /// </summary>
        public int LengthSquared
        {
            get
            {
                return Dot(this, this);
            }
        }

        /// <summary>
        ///   Gets the x-component of this vector.
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        ///   Gets the y-component of this vector.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Adds the passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First summand.
        /// </param>
        /// <param name="w">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector2I Add(Vector2I v, Vector2I w)
        {
            return v + w;
        }

        /// <summary>
        ///   Adds the passed vector to this one, returning the sum of both vectors.
        /// </summary>
        /// <param name="v">
        ///   Vector to add.
        /// </param>
        /// <returns>
        ///   Sum of both vectors.
        /// </returns>
        public Vector2I Add(Vector2I v)
        {
            return Add(this, v);
        }

        /// <summary>
        ///   Computes the Euclidean distance between the points at <paramref name="p" /> and <paramref name="q" />.
        /// </summary>
        /// <param name="p">
        ///   First point to compute the distance of.
        /// </param>
        /// <param name="q">
        ///   Second point to compute the distance of.
        /// </param>
        /// <returns>
        ///   Euclidean distance between the two passed points.
        /// </returns>
        public static float Distance(Vector2I p, Vector2I q)
        {
            return MathF.Sqrt(DistanceSquared(p, q));
        }

        /// <summary>
        ///   Computes the Euclidean distance between the points denoted by this vector and <paramref name="p" />.
        /// </summary>
        /// <param name="p">
        ///   Point to compute the distance to.
        /// </param>
        /// <returns>
        ///   Euclidean distance between the two points.
        /// </returns>
        public float Distance(Vector2I p)
        {
            return Distance(this, p);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points at <paramref name="p" /> and <paramref name="q" />.
        ///   Faster than <see cref="Distance(Vector2I, Vector2I)" />.
        /// </summary>
        /// <param name="p">
        ///   First point to compute the squared distance of.
        /// </param>
        /// <param name="q">
        ///   Second point to compute the squared distance of.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two passed points.
        /// </returns>
        public static int DistanceSquared(Vector2I p, Vector2I q)
        {
            var distX = p.x - q.x;
            var distY = p.y - q.y;
            return (distX * distX) + (distY * distY);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points denoted by this vector and <paramref name="p" />. Faster
        ///   than <see cref="Distance(Vector2I)" />.
        /// </summary>
        /// <param name="p">
        ///   Point to compute the squared distance to.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two points.
        /// </returns>
        public int DistanceSquared(Vector2I p)
        {
            return DistanceSquared(this, p);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="divisor">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector2I Divide(Vector2I v, int divisor)
        {
            return v / divisor;
        }

        /// <summary>
        ///   Divides this vector by the specified scalar.
        /// </summary>
        /// <param name="divisor">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public Vector2I Divide(int divisor)
        {
            return Divide(this, divisor);
        }

        /// <summary>
        ///   Computes the dot product of the two passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First vector to compute the dot product of.
        /// </param>
        /// <param name="w">
        ///   Second vector to compute the dot product of.
        /// </param>
        /// <returns>
        ///   Dot product of the two passed vectors.
        /// </returns>
        public static int Dot(Vector2I v, Vector2I w)
        {
            return (v.x * w.x) + (v.y * w.y);
        }

        /// <summary>
        ///   Computes the dot product of the passed vector and this one.
        /// </summary>
        /// <param name="v">
        ///   Vector to compute the dot product of.
        /// </param>
        /// <returns>
        ///   Dot product of the two vectors.
        /// </returns>
        public int Dot(Vector2I v)
        {
            return Dot(this, v);
        }

        /// <summary>
        ///   Compares the passed vector to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Vector2I && this.Equals((Vector2I)obj);
        }

        /// <summary>
        ///   Compares the passed vector to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(Vector2I other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y);
        }

        /// <summary>
        ///   Gets the hash code of this vector.
        /// </summary>
        /// <returns>
        ///   Hash code of this vector.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.x.GetHashCode();
                hashCode = (hashCode * 397) ^ this.y.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        ///   Sum of the absolute differences of the Cartesian coordinates of this
        ///   point to the specified one.
        /// </summary>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Taxicab_geometry for details.
        /// </remarks>
        /// <param name="p">Point to compute the Manhattan distance to.</param>
        /// <returns>
        ///   Manhattan distance between both points.
        /// </returns>
        public int ManhattanDistance(Vector2I p)
        {
            return ManhattanDistance(this, p);
        }

        /// <summary>
        ///   Sum of the absolute differences of the Cartesian coordinates of both points.
        /// </summary>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Taxicab_geometry for details.
        /// </remarks>
        /// <param name="p">First point to compute the Manhattan distance of.</param>
        /// <param name="q">Second point to compute the Manhattan distance of.</param>
        /// <returns>
        ///   Manhattan distance between both points.
        /// </returns>
        public static int ManhattanDistance(Vector2I p, Vector2I q)
        {
            return Math.Abs(p.X - q.X) + Math.Abs(p.Y - q.Y);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2I Multiply(Vector2I v, int factor)
        {
            return factor * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2I Multiply(int factor, Vector2I v)
        {
            return factor * v;
        }

        /// <summary>
        ///   Multiplies this vector with the specified scalar.
        /// </summary>
        /// <param name="factor">
        ///   Scalar to multiply this vector with.
        /// </param>
        /// <returns>
        ///   Product of this vector and the scalar.
        /// </returns>
        public Vector2I Multiply(int factor)
        {
            return Multiply(factor, this);
        }

        /// <summary>
        ///   Adds the passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First summand.
        /// </param>
        /// <param name="w">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector2I operator +(Vector2I v, Vector2I w)
        {
            return new Vector2I(v.x + w.x, v.y + w.y);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="divisor">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector2I operator /(Vector2I v, int divisor)
        {
            return new Vector2I(v.x / divisor, v.y / divisor);
        }

        /// <summary>
        ///   Compares the passed vectors for equality.
        /// </summary>
        /// <param name="v">
        ///   First vector to compare.
        /// </param>
        /// <param name="w">
        ///   Second vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Vector2I v, Vector2I w)
        {
            return v.Equals(w);
        }

        /// <summary>
        ///   Compares the passed vectors for inequality.
        /// </summary>
        /// <param name="v">
        ///   First vector to compare.
        /// </param>
        /// <param name="w">
        ///   Second vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if the vectors are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(Vector2I v, Vector2I w)
        {
            return !(v == w);
        }

        /// <summary>
        ///   Computes the dot product of the two passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First vector to compute the dot product of.
        /// </param>
        /// <param name="w">
        ///   Second vector to compute the dot product of.
        /// </param>
        /// <returns>
        ///   Dot product of the two passed vectors.
        /// </returns>
        public static float operator *(Vector2I v, Vector2I w)
        {
            return Dot(v, w);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2I operator *(Vector2I v, int factor)
        {
            return factor * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2I operator *(int factor, Vector2I v)
        {
            return new Vector2I(v.x * factor, v.y * factor);
        }

        /// <summary>
        ///   Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v">
        ///   Vector to subtract from.
        /// </param>
        /// <param name="w">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public static Vector2I operator -(Vector2I v, Vector2I w)
        {
            return new Vector2I(v.x - w.x, v.y - w.y);
        }

        /// <summary>
        ///   Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v">
        ///   Vector to subtract from.
        /// </param>
        /// <param name="w">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public static Vector2I Subtract(Vector2I v, Vector2I w)
        {
            return v - w;
        }

        /// <summary>
        ///   Subtracts the passed vector from this one.
        /// </summary>
        /// <param name="v">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public Vector2I Subtract(Vector2I v)
        {
            return Subtract(this, v);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this vector.
        /// </summary>
        /// <returns>
        ///   This vector as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", this.x, this.y);
        }

        /// <summary>
        ///   Returns this vector with its x component changed to the specified value.
        /// </summary>
        /// <param name="newX">X component of the new vector.</param>
        /// <returns>This vector with its x component changed to the specified value. </returns>
        public Vector2I WithX(int newX)
        {
            return new Vector2I(newX, this.Y);
        }

        /// <summary>
        ///   Returns this vector with its y component changed to the specified value.
        /// </summary>
        /// <param name="newY">Y component of the new vector.</param>
        /// <returns>This vector with its y component changed to the specified value. </returns>
        public Vector2I WithY(int newY)
        {
            return new Vector2I(this.X, newY);
        }

        #endregion
    }
}