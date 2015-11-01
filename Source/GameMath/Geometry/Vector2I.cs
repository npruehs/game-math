// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vector2I.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GameMath
{
    using System;

    /// <summary>
    ///   Vector in two-dimensional space with integer components. Note that vectors are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct Vector2I : IEquatable<Vector2I>
    {
        #region Constants

        /// <summary>
        ///   Vector with all components set to one.
        /// </summary>
        public static readonly Vector2I One = new Vector2I(1, 1);

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
                return (this.x * this.x) + (this.y * this.y);
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
        /// <param name="v1">
        ///   First summand.
        /// </param>
        /// <param name="v2">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector2I Add(Vector2I v1, Vector2I v2)
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
        public Vector2I Add(Vector2I v)
        {
            return Add(this, v);
        }

        /// <summary>
        ///   Computes the Euclidean distance between the points at <paramref name="v1" /> and <paramref name="v2" />.
        /// </summary>
        /// <param name="v1">
        ///   First point to compute the distance of.
        /// </param>
        /// <param name="v2">
        ///   Second point to compute the distance of.
        /// </param>
        /// <returns>
        ///   Euclidean distance between the two passed points.
        /// </returns>
        public static float Distance(Vector2I v1, Vector2I v2)
        {
            return MathF.Sqrt(DistanceSquared(v1, v2));
        }

        /// <summary>
        ///   Computes the Euclidean distance between the points denoted by this vector and <paramref name="v" />.
        /// </summary>
        /// <param name="v">
        ///   Point to compute the distance to.
        /// </param>
        /// <returns>
        ///   Euclidean distance between the two points.
        /// </returns>
        public float Distance(Vector2I v)
        {
            return Distance(this, v);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points at <paramref name="v1" /> and <paramref name="v2" />.
        ///   Faster than <see cref="Distance(Vector2I, Vector2I)" />.
        /// </summary>
        /// <param name="v1">
        ///   First point to compute the squared distance of.
        /// </param>
        /// <param name="v2">
        ///   Second point to compute the squared distance of.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two passed points.
        /// </returns>
        public static int DistanceSquared(Vector2I v1, Vector2I v2)
        {
            var distX = v1.x - v2.x;
            var distY = v1.y - v2.y;
            return (distX * distX) + (distY * distY);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points denoted by this vector and <paramref name="v" />. Faster
        ///   than <see cref="Distance(Vector2I)" />.
        /// </summary>
        /// <param name="v">
        ///   Point to compute the squared distance to.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two points.
        /// </returns>
        public int DistanceSquared(Vector2I v)
        {
            return DistanceSquared(this, v);
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
        public static Vector2I Divide(Vector2I v, int i)
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
        public Vector2I Divide(int i)
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
        public static int Dot(Vector2I v1, Vector2I v2)
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
        public static Vector2I Multiply(Vector2I v, int i)
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
        public static Vector2I Multiply(int i, Vector2I v)
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
        public Vector2I Multiply(int i)
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
        public static Vector2I operator +(Vector2I v1, Vector2I v2)
        {
            return new Vector2I(v1.x + v2.x, v1.y + v2.y);
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
        public static Vector2I operator /(Vector2I v, int i)
        {
            return new Vector2I(v.x / i, v.y / i);
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
        public static bool operator ==(Vector2I v1, Vector2I v2)
        {
            return v1.Equals(v2);
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
        public static bool operator !=(Vector2I v1, Vector2I v2)
        {
            return !(v1 == v2);
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
        public static Vector2I operator *(Vector2I v, int i)
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
        public static Vector2I operator *(int i, Vector2I v)
        {
            return new Vector2I(v.x * i, v.y * i);
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
        public static Vector2I operator -(Vector2I v1, Vector2I v2)
        {
            return new Vector2I(v1.x - v2.x, v1.y - v2.y);
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
        public static Vector2I Subtract(Vector2I v1, Vector2I v2)
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

        #endregion
    }
}