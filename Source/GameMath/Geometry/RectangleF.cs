namespace GameMath
{
    using System;

    /// <summary>
    ///   Axis-aligned rectangle with floating point position and extent.
    ///   Note that rectangles are immutable.
    /// </summary>
    [CLSCompliant(true)]
    public struct RectangleF : IEquatable<RectangleF>
    {
        #region Fields

        /// <summary>
        ///   Position of this rectangle.
        /// </summary>
        private readonly Vector2F position;

        /// <summary>
        ///   Size of this rectangle, its width and height.
        /// </summary>
        private readonly Vector2F size;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the rectangle position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the rectangle position.
        /// </param>
        /// <param name="width">
        ///   Rectangle width.
        /// </param>
        /// <param name="height">
        ///   Rectangle height.
        /// </param>
        public RectangleF(float x, float y, float width, float height)
            : this(new Vector2F(x, y), new Vector2F(width, height))
        {
        }

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the rectangle position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the rectangle position.
        /// </param>
        /// <param name="size">
        ///   Rectangle size.
        /// </param>
        public RectangleF(float x, float y, Vector2F size)
            : this(new Vector2F(x, y), size)
        {
        }

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Rectangle position.
        /// </param>
        /// <param name="width">
        ///   Rectangle width.
        /// </param>
        /// <param name="height">
        ///   Rectangle height.
        /// </param>
        public RectangleF(Vector2F position, float width, float height)
            : this(position, new Vector2F(width, height))
        {
        }

        /// <summary>
        ///   Constructs a new rectangle with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Rectangle position.
        /// </param>
        /// <param name="size">
        ///   Rectangle size.
        /// </param>
        public RectangleF(Vector2F position, Vector2F size)
        {
            if (size.X < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Width must be non-negative.");
            }

            if (size.Y < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Height must be non-negative.");
            }

            this.position = position;
            this.size = size;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the area of this rectangle, the product of its width and height.
        /// </summary>
        public float Area
        {
            get
            {
                return this.Size.X * this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the position of the center of this rectangle.
        /// </summary>
        public Vector2F Center
        {
            get
            {
                return (this.Position + this.Size) / 2;
            }
        }

        /// <summary>
        ///   Gets or sets the height of this rectangle.
        /// </summary>
        public float Height
        {
            get
            {
                return this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the maximum x-component of this rectangle.
        /// </summary>
        public float MaxX
        {
            get
            {
                return this.Position.X + this.Size.X;
            }
        }

        /// <summary>
        ///   Gets the maximum y-component of this rectangle.
        /// </summary>
        public float MaxY
        {
            get
            {
                return this.Position.Y + this.Size.Y;
            }
        }

        /// <summary>
        ///   Position of this rectangle.
        /// </summary>
        public Vector2F Position
        {
            get
            {
                return this.position;
            }
        }

        /// <summary>
        ///   Gets or sets the size of this rectangle, its width and height.
        /// </summary>
        public Vector2F Size
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        ///   Gets or sets the width of this rectangle.
        /// </summary>
        public float Width
        {
            get
            {
                return this.Size.X;
            }
        }

        /// <summary>
        ///   Gets or sets the x-component of the position of this rectangle.
        /// </summary>
        public float X
        {
            get
            {
                return this.Position.X;
            }
        }

        /// <summary>
        ///   Gets or sets the y-component of the position of this rectangle.
        /// </summary>
        public float Y
        {
            get
            {
                return this.Position.Y;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether this rectangle entirely encompasses the passed other one.
        /// </summary>
        /// <param name="other">
        ///   Rectangle to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this rectangle contains <paramref name="other" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(RectangleF other)
        {
            return (this.X <= other.X && this.MaxX >= other.MaxX) && (this.Y <= other.Y && this.MaxY >= other.MaxY);
        }

        /// <summary>
        ///   Checks whether this rectangle contains the point denoted by the specified vector.
        /// </summary>
        /// <param name="point">
        ///   Point to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this rectangle contains <paramref name="point" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(Vector2F point)
        {
            return point.X.IsWithinBounds(this.X, this.MaxX) && point.Y.IsWithinBounds(this.Y, this.MaxY);
        }

        /// <summary>
        ///   Compares the passed rectangle to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(RectangleF other)
        {
            return this.Position.Equals(other.Position) && this.Size.Equals(other.Size);
        }

        /// <summary>
        ///   Compares the passed rectangle to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType() && this.Equals((RectangleF)obj);
        }

        /// <summary>
        ///   Gets the hash code of this rectangle.
        /// </summary>
        /// <returns>
        ///   Hash code of this rectangle.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Position.GetHashCode() * 397) ^ this.Size.GetHashCode();
            }
        }

        /// <summary>
        ///   Compares the passed rectangles for equality.
        /// </summary>
        /// <param name="first">
        ///   First rectangle to compare.
        /// </param>
        /// <param name="second">
        ///   Second rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(RectangleF first, RectangleF second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed rectangles for inequality.
        /// </summary>
        /// <param name="first">
        ///   First rectangle to compare.
        /// </param>
        /// <param name="second">
        ///   Second rectangle to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both rectangles are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(RectangleF first, RectangleF second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this rectangle.
        /// </summary>
        /// <returns>
        ///   This rectangle as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Position: {0}, Size: {1}", this.Position, this.Size);
        }

        #endregion
    }
}