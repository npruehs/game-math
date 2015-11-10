namespace GameMath
{
    using System;

    /// <summary>
    ///   Vector in three-dimensional space with integer components. Note that vectors are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct Vector3I : IEquatable<Vector3I>
    {
        #region Constants

        /// <summary>
        ///   Unit vector in direction of the x axis.
        /// </summary>
        public static readonly Vector3I UnitX = new Vector3I(1, 0, 0);

        /// <summary>
        ///   Unit vector in direction of the y axis.
        /// </summary>
        public static readonly Vector3I UnitY = new Vector3I(0, 1, 0);

        /// <summary>
        ///   Unit vector in direction of the z axis.
        /// </summary>
        public static readonly Vector3I UnitZ = new Vector3I(0, 0, 1);

        /// <summary>
        ///   Null vector.
        /// </summary>
        public static readonly Vector3I Zero = new Vector3I();

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

        /// <summary>
        ///   Z-component of this vector.
        /// </summary>
        private readonly int z;

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
        /// <param name="z">
        ///   Z-component of the new vector.
        /// </param>
        public Vector3I(int x, int y, int z)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
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
        public int X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        ///   Two-dimensional vector with the x and y component of this vector.
        /// </summary>
        public Vector2I XY
        {
            get
            {
                return new Vector2I(this.X, this.Y);
            }
        }

        /// <summary>
        ///   Two-dimensional vector with the x and z component of this vector.
        /// </summary>
        public Vector2I XZ
        {
            get
            {
                return new Vector2I(this.X, this.Z);
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

        /// <summary>
        ///   Two-dimensional vector with the y and z component of this vector.
        /// </summary>
        public Vector2I YZ
        {
            get
            {
                return new Vector2I(this.Y, this.Z);
            }
        }

        /// <summary>
        ///   Gets the z-component of this vector.
        /// </summary>
        public int Z
        {
            get
            {
                return this.z;
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
        public static Vector3I Add(Vector3I v1, Vector3I v2)
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
        public Vector3I Add(Vector3I v)
        {
            return Add(this, v);
        }

        /// <summary>
        ///   Computes the cross product of the passed vectors. See
        ///   http://en.wikipedia.org/wiki/Cross_product for details.
        /// </summary>
        /// <param name="v1">
        ///   First vector to compute the cross product of.
        /// </param>
        /// <param name="v2">
        ///   Second vector to compute the cross product of.
        /// </param>
        /// <returns>
        ///   Cross product of the passed vectors.
        /// </returns>
        public static Vector3I Cross(Vector3I v1, Vector3I v2)
        {
            return new Vector3I(
                (v1.y * v2.z) - (v1.z * v2.y),
                (v1.z * v2.x) - (v1.x * v2.z),
                (v1.x * v2.y) - (v1.y * v2.x));
        }

        /// <summary>
        ///   Computes the cross product of the passed vector and this one. See
        ///   http://en.wikipedia.org/wiki/Cross_product for details.
        /// </summary>
        /// <param name="v">
        ///   Vector to compute the cross product of.
        /// </param>
        /// <returns>
        ///   Cross product of the both vectors.
        /// </returns>
        public Vector3I Cross(Vector3I v)
        {
            return Cross(this, v);
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
        public static float Distance(Vector3I p, Vector3I q)
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
        public float Distance(Vector3I p)
        {
            return Distance(this, p);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points at <paramref name="p" /> and <paramref name="q" />.
        ///   Faster than <see cref="Distance(Vector3I, Vector3I)" />.
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
        public static float DistanceSquared(Vector3I p, Vector3I q)
        {
            var distX = p.x - q.x;
            var distY = p.y - q.y;
            var distZ = p.z - q.z;
            return (distX * distX) + (distY * distY) + (distZ * distZ);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points denoted by this vector and <paramref name="p" />.
        ///   Faster than <see cref="Distance(Vector3I)" />.
        /// </summary>
        /// <param name="p">
        ///   Point to compute the squared distance to.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two points.
        /// </returns>
        public float DistanceSquared(Vector3I p)
        {
            return DistanceSquared(this, p);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="i">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector3I Divide(Vector3I v, int i)
        {
            return v / i;
        }

        /// <summary>
        ///   Divides this vector by the specified scalar.
        /// </summary>
        /// <param name="i">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public Vector3I Divide(int i)
        {
            return Divide(this, i);
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
        public static int Dot(Vector3I v1, Vector3I v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
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
        public int Dot(Vector3I v)
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

            return obj is Vector3I && this.Equals((Vector3I)obj);
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
        public bool Equals(Vector3I other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z);
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
                hashCode = (hashCode * 397) ^ this.z.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        ///   Sum of the absolute differences of the Cartesian coordinates of this
        ///   point to the specified one.
        /// </summary>
        /// <remarks>
        ///   https://en.wikipedia.org/wiki/Taxicab_geometry
        /// </remarks>
        /// <param name="p">Point to compute the Manhattan distance to.</param>
        /// <returns>
        ///   Manhattan distance between both points.
        /// </returns>
        public int ManhattanDistance(Vector3I p)
        {
            return ManhattanDistance(this, p);
        }

        /// <summary>
        ///   Sum of the absolute differences of the Cartesian coordinates of both points.
        /// </summary>
        /// <remarks>
        ///   https://en.wikipedia.org/wiki/Taxicab_geometry
        /// </remarks>
        /// <param name="p">First point to compute the Manhattan distance of.</param>
        /// <param name="q">Second point to compute the Manhattan distance of.</param>
        /// <returns>
        ///   Manhattan distance between both points.
        /// </returns>
        public static int ManhattanDistance(Vector3I p, Vector3I q)
        {
            return Math.Abs(p.X - q.X) + Math.Abs(p.Y - q.Y) + Math.Abs(p.Z - q.Z);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="i">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3I Multiply(Vector3I v, int i)
        {
            return i * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="i">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3I Multiply(int i, Vector3I v)
        {
            return i * v;
        }

        /// <summary>
        ///   Multiplies this vector with the specified scalar.
        /// </summary>
        /// <param name="i">
        ///   Scalar to multiply this vector with.
        /// </param>
        /// <returns>
        ///   Product of this vector and the scalar.
        /// </returns>
        public Vector3I Multiply(int i)
        {
            return Multiply(i, this);
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
        public static Vector3I operator +(Vector3I v1, Vector3I v2)
        {
            return new Vector3I(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="i">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector3I operator /(Vector3I v, int i)
        {
            return new Vector3I(v.x / i, v.y / i, v.z / i);
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
        public static bool operator ==(Vector3I v1, Vector3I v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        ///   Implicitly converts the passed two-dimensional vector to
        ///   a three-dimensional vector by using zero as z component.
        /// </summary>
        /// <param name="v">Vector to convert.</param>
        /// <returns>Passed vector as three-dimensional vector.</returns>
        public static implicit operator Vector3I(Vector2I v)
        {
            return new Vector3I(v.X, v.Y, 0);
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
        public static bool operator !=(Vector3I v1, Vector3I v2)
        {
            return !(v1 == v2);
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
        public static float operator *(Vector3I v, Vector3I w)
        {
            return Dot(v, w);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="i">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3I operator *(Vector3I v, int i)
        {
            return i * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="i">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3I operator *(int i, Vector3I v)
        {
            return new Vector3I(v.x * i, v.y * i, v.z * i);
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
        public static Vector3I operator -(Vector3I v1, Vector3I v2)
        {
            return new Vector3I(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
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
        public static Vector3I Subtract(Vector3I v1, Vector3I v2)
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
        public Vector3I Subtract(Vector3I v)
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
            return string.Format("({0}, {1}, {2})", this.x, this.y, this.z);
        }

        /// <summary>
        ///   Returns this vector with its x component changed to the specified value.
        /// </summary>
        /// <param name="newX">X component of the new vector.</param>
        /// <returns>This vector with its x component changed to the specified value. </returns>
        public Vector3I WithX(int newX)
        {
            return new Vector3I(newX, this.Y, this.Z);
        }

        /// <summary>
        ///   Returns this vector with its y component changed to the specified value.
        /// </summary>
        /// <param name="newY">Y component of the new vector.</param>
        /// <returns>This vector with its y component changed to the specified value. </returns>
        public Vector3I WithY(int newY)
        {
            return new Vector3I(this.X, newY, this.Z);
        }

        /// <summary>
        ///   Returns this vector with its z component changed to the specified value.
        /// </summary>
        /// <param name="newZ">Z component of the new vector.</param>
        /// <returns>This vector with its z component changed to the specified value. </returns>
        public Vector3I WithZ(int newZ)
        {
            return new Vector3I(this.X, this.Y, newZ);
        }

        #endregion
    }
}