namespace GameMath
{
    using System;

    /// <summary>
    ///   Box with floating point position and extents.
    ///   Origin is front-top-left.
    /// </summary>
    [CLSCompliant(true)]
    public class BoxF : IEquatable<BoxF>
    {
        #region Fields

        /// <summary>
        ///   Size of this box, its width, height and depth.
        /// </summary>
        private Vector3F size;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the box position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the box position.
        /// </param>
        /// <param name="z">
        ///   Z-component of the box position.
        /// </param>
        /// <param name="width">
        ///   Box width.
        /// </param>
        /// <param name="height">
        ///   Box height.
        /// </param>
        /// <param name="depth">
        ///   Box depth.
        /// </param>
        public BoxF(float x, float y, float z, float width, float height, float depth)
            : this(new Vector3F(x, y, z), new Vector3F(width, height, depth))
        {
        }

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the box position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the box position.
        /// </param>
        /// <param name="z">
        ///   Z-component of the box position.
        /// </param>
        /// <param name="size">
        ///   Box extents.
        /// </param>
        public BoxF(float x, float y, float z, Vector3F size)
            : this(new Vector3F(x, y, z), size)
        {
        }

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Box position.
        /// </param>
        /// <param name="width">
        ///   Box width.
        /// </param>
        /// <param name="height">
        ///   Box height.
        /// </param>
        /// <param name="depth">
        ///   Box depth.
        /// </param>
        public BoxF(Vector3F position, float width, float height, float depth)
            : this(position, new Vector3F(width, height, depth))
        {
        }

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Box position.
        /// </param>
        /// <param name="size">
        ///   Box size.
        /// </param>
        public BoxF(Vector3F position, Vector3F size)
        {
            this.Position = position;
            this.Size = size;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the z-component of the back face of this box.
        /// </summary>
        public float Back
        {
            get
            {
                return this.Position.Z + this.Size.Z;
            }
        }

        /// <summary>
        ///   Gets the y-component of the bottom face of this box.
        /// </summary>
        public float Bottom
        {
            get
            {
                return this.Position.Y + this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the position of the center of this box.
        /// </summary>
        public Vector3F Center
        {
            get
            {
                return (this.Position + this.Size) / 2;
            }
        }

        /// <summary>
        ///   Gets or sets the depth of this box.
        /// </summary>
        public float Depth
        {
            get
            {
                return this.Size.Z;
            }

            set
            {
                this.Size = new Vector3F(this.Size.X, this.Size.Y, value);
            }
        }

        /// <summary>
        ///   Gets the z-component of the front face of this box.
        /// </summary>
        public float Front
        {
            get
            {
                return this.Position.Z;
            }
        }

        /// <summary>
        ///   Gets or sets the height of this box.
        /// </summary>
        public float Height
        {
            get
            {
                return this.Size.Y;
            }

            set
            {
                this.Size = new Vector3F(this.Size.X, value, this.Size.Z);
            }
        }

        /// <summary>
        ///   Gets the x-component of the left face of this box.
        /// </summary>
        public float Left
        {
            get
            {
                return this.Position.X;
            }
        }

        /// <summary>
        ///   Gets or sets the position of this box.
        /// </summary>
        public Vector3F Position { get; set; }

        /// <summary>
        ///   Gets the x-component of the right face of this box.
        /// </summary>
        public float Right
        {
            get
            {
                return this.Position.X + this.Size.X;
            }
        }

        /// <summary>
        ///   Gets or sets the size of this box, its width, height and depth.
        /// </summary>
        public Vector3F Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value.X < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Width must be non-negative.");
                }

                if (value.Y < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Height must be non-negative.");
                }

                if (value.Z < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Depth must be non-negative.");
                }

                this.size = value;
            }
        }

        /// <summary>
        ///   Gets the y-component of the top face of this box.
        /// </summary>
        public float Top
        {
            get
            {
                return this.Position.Y;
            }
        }

        /// <summary>
        ///   Gets the volume of this box, the product of its width, height and depth.
        /// </summary>
        public float Volume
        {
            get
            {
                return this.Size.X * this.Size.Y * this.Size.Z;
            }
        }

        /// <summary>
        ///   Gets or sets the width of this box.
        /// </summary>
        public float Width
        {
            get
            {
                return this.Size.X;
            }

            set
            {
                this.Size = new Vector3F(value, this.Size.Y, this.Size.Z);
            }
        }

        /// <summary>
        ///   Gets or sets the x-component of the position of this box.
        /// </summary>
        public float X
        {
            get
            {
                return this.Position.X;
            }

            set
            {
                this.Position = new Vector3F(value, this.Position.Y, this.Position.Z);
            }
        }

        /// <summary>
        ///   Gets or sets the y-component of the position of this box.
        /// </summary>
        public float Y
        {
            get
            {
                return this.Position.Y;
            }

            set
            {
                this.Position = new Vector3F(this.Position.X, value, this.Position.Z);
            }
        }

        /// <summary>
        ///   Gets or sets the z-component of the position of this box.
        /// </summary>
        public float Z
        {
            get
            {
                return this.Position.Z;
            }

            set
            {
                this.Position = new Vector3F(this.Position.X, this.Position.Y, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether this box entirely encompasses the passed other one.
        /// </summary>
        /// <param name="other">
        ///   Box to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this box contains <paramref name="other" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(BoxF other)
        {
            return (this.Left <= other.Left && this.Right >= other.Right)
                   && (this.Top <= other.Top && this.Bottom >= other.Bottom)
                   && (this.Front <= other.Front && this.Back >= other.Front);
        }

        /// <summary>
        ///   Checks whether this box contains the point denoted by the specified vector.
        /// </summary>
        /// <param name="point">
        ///   Point to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this box contains <paramref name="point" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(Vector3F point)
        {
            return point.X >= this.Left && point.X < this.Right && point.Y >= this.Top && point.Y < this.Bottom
                   && point.Z >= this.Front && point.Z < this.Back;
        }

        /// <summary>
        ///   Compares the passed box to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Box to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both boxes are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(BoxF other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Position.Equals(other.Position) && this.Size.Equals(other.Size);
        }

        /// <summary>
        ///   Compares the passed box to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Box to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both boxes are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && this.Equals((BoxF)obj);
        }

        /// <summary>
        ///   Gets the hash code of this box.
        /// </summary>
        /// <returns>
        ///   Hash code of this box.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Position.GetHashCode() * 397) ^ this.Size.GetHashCode();
            }
        }

        /// <summary>
        ///   Checks whether this box at least partially intersects the passed other one.
        /// </summary>
        /// <param name="other">
        ///   Box to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this box intersects <paramref name="other" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Intersects(BoxF other)
        {
            return (this.Right > other.Left && this.Left < other.Right)
                   && (this.Bottom > other.Top && this.Top < other.Bottom)
                   && (this.Back > other.Front && this.Front < other.Back);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this box.
        /// </summary>
        /// <returns>
        ///   This box as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Position: {0}, Size: {1}", this.Position, this.Size);
        }

        #endregion
    }
}