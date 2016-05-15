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
                return Dot(this, this);
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
        /// <param name="v">
        ///   First summand.
        /// </param>
        /// <param name="w">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector2F Add(Vector2F v, Vector2F w)
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
        public Vector2F Add(Vector2F v)
        {
            return Add(this, v);
        }

        /// <summary>
        ///   Checks whether the given points are in counter-clockwise order.
        /// </summary>
        /// <remarks>
        ///   See http://jeffe.cs.illinois.edu/teaching/373/notes/x05-convexhull.pdf for details.
        /// </remarks>
        /// <param name="p">First point.</param>
        /// <param name="q">Second point.</param>
        /// <param name="r">Third point.</param>
        /// <returns>
        ///   <c>true</c>, if the three points are in counter-clockwise order, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool CounterClockwise(Vector2F p, Vector2F q, Vector2F r)
        {
            var a = p.X;
            var b = p.Y;

            var c = q.X;
            var d = q.Y;

            var e = r.X;
            var f = r.Y;

            return (f - b) * (c - a) > (d - b) * (e - a);
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
        /// <param name="divisor">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector2F Divide(Vector2F v, float divisor)
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
        public Vector2F Divide(float divisor)
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
        public static float Dot(Vector2F v, Vector2F w)
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
        /// <param name="v">
        ///   First vector to interpolate.
        /// </param>
        /// <param name="w">
        ///   Second vector to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="v" />, 1 returns <paramref name="w" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two passed vectors.
        /// </returns>
        public static Vector2F Lerp(Vector2F v, Vector2F w, float l)
        {
            var lerpX = MathF.Lerp(v.x, w.x, l);
            var lerpY = MathF.Lerp(v.y, w.y, l);
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
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector2F Multiply(Vector2F v, float factor)
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
        public static Vector2F Multiply(float factor, Vector2F v)
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
        public Vector2F Multiply(float factor)
        {
            return Multiply(factor, this);
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
            return v / v.Length;
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
        /// <param name="v">
        ///   First summand.
        /// </param>
        /// <param name="w">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector2F operator +(Vector2F v, Vector2F w)
        {
            return new Vector2F(v.x + w.x, v.y + w.y);
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
        public static Vector2F operator /(Vector2F v, float divisor)
        {
            return new Vector2F(v.x / divisor, v.y / divisor);
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
        public static bool operator ==(Vector2F v, Vector2F w)
        {
            return v.Equals(w);
        }

        /// <summary>
        ///   Implicitly converts the passed vector with integer components to
        ///   a vector with floating point components.
        /// </summary>
        /// <param name="v">Vector to convert.</param>
        /// <returns>Passed vector with floating point components.</returns>
        public static implicit operator Vector2F(Vector2I v)
        {
            return new Vector2F(v.X, v.Y);
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
        public static bool operator !=(Vector2F v, Vector2F w)
        {
            return !(v == w);
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
        public static Vector2F operator *(Vector2F v, float factor)
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
        public static Vector2F operator *(float factor, Vector2F v)
        {
            return new Vector2F(v.x * factor, v.y * factor);
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
        public static float operator *(Vector2F v, Vector2F w)
        {
            return Dot(v, w);
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
        public static Vector2F operator -(Vector2F v, Vector2F w)
        {
            return new Vector2F(v.x - w.x, v.y - w.y);
        }

        /// <summary>
        ///   Orthogonally projects <paramref name="v" /> onto a straight line
        ///   parallel to <paramref name="w" />.
        /// </summary>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Vector_projection for details.
        /// </remarks>
        /// <param name="v">Vector to project.</param>
        /// <param name="w">Vector to project onto.</param>
        /// <returns>Projected vector.</returns>
        public static Vector2F Project(Vector2F v, Vector2F w)
        {
            return v.Length * Angle.Cos(Angle.Between(v, w)) * w.Normalize();
        }

        /// <summary>
        ///   Orthogonally projects this vector onto a straight line
        ///   parallel to the specified vector.
        /// </summary>
        /// <param name="v">Vector to project onto.</param>
        /// <returns>Projected vector.</returns>
        public Vector2F Project(Vector2F v)
        {
            return Project(this, v);
        }

        /// <summary>
        ///   Reflects the passed vector off the plane defined by the specified normal.
        /// </summary>
        /// <remarks>
        ///   See http://www.blitzbasic.com/Community/posts.php?topic=52511 for details.
        /// </remarks>
        /// <param name="v">Vector to reflect.</param>
        /// <param name="n">Normal of the plane to reflect off.</param>
        /// <returns>Reflected vector.</returns>
        public static Vector2F Reflect(Vector2F v, Vector2F n)
        {
            return v - (2 * n * (n * v));
        }

        /// <summary>
        ///   Reflects this off the plane defined by the specified normal.
        /// </summary>
        /// <param name="n">Normal of the plane to reflect off.</param>
        /// <returns>Reflected vector.</returns>
        public Vector2F Reflect(Vector2F n)
        {
            return Reflect(this, n);
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
        /// <remarks>
        ///   See http://stackoverflow.com/questions/4780119/2d-euclidean-vector-rotations for details.
        /// </remarks>
        /// <param name="v">Vector to rotate.</param>
        /// <param name="theta">Angle to rotate by, in radians.</param>
        /// <returns>Rotated vector.</returns>
        public static Vector2F Rotate(Vector2F v, float theta)
        {
            var cos = Angle.Cos(theta);
            var sin = Angle.Sin(theta);

            var newX = v.X * cos - v.Y * sin;
            var newY = v.X * sin + v.Y * cos;

            return new Vector2F(newX, newY);
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
        public static Vector2F Subtract(Vector2F v, Vector2F w)
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