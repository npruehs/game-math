namespace GameMath
{
    using System;

    /// <summary>
    ///   Vector in two-dimensional space with floating point components. Note that vectors are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct Vector2F : IEquatable<Vector2F>
    {
        #region Constants

        /// <summary>
        ///   Unit vector in direction of the x axis.
        /// </summary>
        public static readonly Vector2F UnitX = new Vector2F(1.0f, 0.0f);

        /// <summary>
        ///   Unit vector in direction of the y axis.
        /// </summary>
        public static readonly Vector2F UnitY = new Vector2F(0.0f, 1.0f);

        /// <summary>
        ///   Null vector.
        /// </summary>
        public static readonly Vector2F Zero = new Vector2F();

        #endregion

        #region Fields

        /// <summary>
        ///   X-component of this vector.
        /// </summary>
        private readonly float x;

        /// <summary>
        ///   Y-component of this vector.
        /// </summary>
        private readonly float y;

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
        public Vector2F(float x, float y)
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
        public float LengthSquared
        {
            get
            {
                return (this.x * this.x) + (this.y * this.y);
            }
        }

        /// <summary>
        ///   Gets the x-component of this vector.
        /// </summary>
        public float X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        ///   Gets the y-component of this vector.
        /// </summary>
        public float Y
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
        /// <param name="v1">
        ///   First summand.
        /// </param>
        /// <param name="v2">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector2F Add(Vector2F v1, Vector2F v2)
        {
            return v1 + v2;
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
        public Vector2F Add(Vector2F v)
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
        public static float Distance(Vector2F p, Vector2F q)
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
        public float Distance(Vector2F p)
        {
            return Distance(this, p);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points at <paramref name="p" /> and <paramref name="q" />.
        ///   Faster than <see cref="Distance(Vector2F, Vector2F)" />.
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
        public static float DistanceSquared(Vector2F p, Vector2F q)
        {
            var distX = p.x - q.x;
            var distY = p.y - q.y;
            return (distX * distX) + (distY * distY);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points denoted by this vector and <paramref name="p" />. Faster
        ///   than <see cref="Distance(Vector2F)" />.
        /// </summary>
        /// <param name="p">
        ///   Point to compute the squared distance to.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two points.
        /// </returns>
        public float DistanceSquared(Vector2F p)
        {
            return DistanceSquared(this, p);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="f">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector2F Divide(Vector2F v, float f)
        {
            return v / f;
        }

        /// <summary>
        ///   Divides this vector by the specified scalar.
        /// </summary>
        /// <param name="f">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public Vector2F Divide(float f)
        {
            return Divide(this, f);
        }

        /// <summary>
        ///   Computes the dot product of the two passed vectors.
        /// </summary>
        /// <param name="v1">
        ///   First vector to compute the dot product of.
        /// </param>
        /// <param name="v2">
        ///   Second vector to compute the dot product of.
        /// </param>
        /// <returns>
        ///   Dot product of the two passed vectors.
        /// </returns>
        public static float Dot(Vector2F v1, Vector2F v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y);
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
        public float Dot(Vector2F v)
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

            return obj is Vector2F && this.Equals((Vector2F)obj);
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
        public bool Equals(Vector2F other)
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
        ///   Linearly interpolates between the two passed vectors.
        /// </summary>
        /// <param name="v1">
        ///   First vector to interpolate.
        /// </param>
        /// <param name="v2">
        ///   Second vector to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="v1" />, 1 returns <paramref name="v2" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two passed vectors.
        /// </returns>
        public static Vector2F Lerp(Vector2F v1, Vector2F v2, float l)
        {
            var lerpX = MathF.Lerp(v1.x, v2.x, l);
            var lerpY = MathF.Lerp(v1.y, v2.y, l);
            return new Vector2F(lerpX, lerpY);
        }

        /// <summary>
        ///   Linearly interpolates between the passed vector and this one.
        /// </summary>
        /// <param name="v">
        ///   Vector to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns this vector, 1 returns <paramref name="v" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two vectors.
        /// </returns>
        public Vector2F Lerp(Vector2F v, float l)
        {
            return Lerp(this, v, l);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="f">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2F Multiply(Vector2F v, float f)
        {
            return f * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="f">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2F Multiply(float f, Vector2F v)
        {
            return f * v;
        }

        /// <summary>
        ///   Multiplies this vector with the specified scalar.
        /// </summary>
        /// <param name="f">
        ///   Scalar to multiply this vector with.
        /// </param>
        /// <returns>
        ///   Product of this vector and the scalar.
        /// </returns>
        public Vector2F Multiply(float f)
        {
            return Multiply(f, this);
        }

        /// <summary>
        ///   Normalizes the passed vector, returning a unit vector with the same orientation.
        ///   If the passed vector is the zero vector, the zero vector is returned instead.
        /// </summary>
        /// <param name="v">
        ///   Vector to normalize.
        /// </param>
        /// <returns>
        ///   Normalized passed vector.
        /// </returns>
        public static Vector2F Normalize(Vector2F v)
        {
            var lengthSquared = v.LengthSquared;
            if (MathF.Equals(lengthSquared, 0f) || MathF.Equals(lengthSquared, 1f))
            {
                return v;
            }

            var lengthInverse = 1.0f / MathF.Sqrt(lengthSquared);

            return new Vector2F(v.x * lengthInverse, v.y * lengthInverse);
        }

        /// <summary>
        ///   Normalizes this vector, returning a unit vector with the same orientation.
        ///   If this passed vector is the zero vector, the zero vector is returned instead.
        /// </summary>
        /// <returns>
        ///   Normalized vector.
        /// </returns>
        public Vector2F Normalize()
        {
            return Normalize(this);
        }

        /// <summary>
        ///   Adds the passed vectors.
        /// </summary>
        /// <param name="v1">
        ///   First summand.
        /// </param>
        /// <param name="v2">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector2F operator +(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.x + v2.x, v1.y + v2.y);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="f">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector2F operator /(Vector2F v, float f)
        {
            return new Vector2F(v.x / f, v.y / f);
        }

        /// <summary>
        ///   Compares the passed vectors for equality.
        /// </summary>
        /// <param name="v1">
        ///   First vector to compare.
        /// </param>
        /// <param name="v2">
        ///   Second vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Vector2F v1, Vector2F v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        ///   Implicitly converts the passed vector with integer components to
        ///   a vector with floating point components.
        /// </summary>
        /// <param name="v">Vector to convert.</param>
        public static implicit operator Vector2F(Vector2I v)
        {
            return new Vector2F(v.X, v.Y);
        }

        /// <summary>
        ///   Compares the passed vectors for inequality.
        /// </summary>
        /// <param name="v1">
        ///   First vector to compare.
        /// </param>
        /// <param name="v2">
        ///   Second vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if the vectors are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(Vector2F v1, Vector2F v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="f">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2F operator *(Vector2F v, float f)
        {
            return f * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="f">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2F operator *(float f, Vector2F v)
        {
            return new Vector2F(v.x * f, v.y * f);
        }

        /// <summary>
        ///   Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v1">
        ///   Vector to subtract from.
        /// </param>
        /// <param name="v2">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public static Vector2F operator -(Vector2F v1, Vector2F v2)
        {
            return new Vector2F(v1.x - v2.x, v1.y - v2.y);
        }

        /// <summary>
        ///   Rotates this vector counter-clockwise around its origin
        ///   by the specified angle in radians.
        /// </summary>
        /// <param name="theta">Angle to rotate by, in radians.</param>
        /// <returns>Rotated vector.</returns>
        public Vector2F Rotate(float theta)
        {
            return Rotate(this, theta);
        }

        /// <summary>
        ///   Rotates the specified vector counter-clockwise around its origin
        ///   by the specified angle in radians.
        /// </summary>
        /// <param name="v">Vector to rotate.</param>
        /// <param name="theta">Angle to rotate by, in radians.</param>
        /// <returns>Rotated vector.</returns>
        public static Vector2F Rotate(Vector2F v, float theta)
        {
            // http://stackoverflow.com/questions/4780119/2d-euclidean-vector-rotations
            var cos = Angle.Cos(theta);
            var sin = Angle.Sin(theta);

            var newX = v.X * cos - v.Y * sin;
            var newY = v.X * sin + v.Y * cos;

            return new Vector2F(newX, newY);
        }

        /// <summary>
        ///   Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v1">
        ///   Vector to subtract from.
        /// </param>
        /// <param name="v2">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public static Vector2F Subtract(Vector2F v1, Vector2F v2)
        {
            return v1 - v2;
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
        public Vector2F Subtract(Vector2F v)
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
        public Vector2F WithX(float newX)
        {
            return new Vector2F(newX, this.Y);
        }

        /// <summary>
        ///   Returns this vector with its y component changed to the specified value.
        /// </summary>
        /// <param name="newY">Y component of the new vector.</param>
        /// <returns>This vector with its y component changed to the specified value. </returns>
        public Vector2F WithY(float newY)
        {
            return new Vector2F(this.X, newY);
        }

        #endregion
    }
}