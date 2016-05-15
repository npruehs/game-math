namespace GameMath
{
    using System;

    /// <summary>
    ///   Implementation of the Ranq1 struct found in Numerical Recipes in C:
    ///   3rd Edition. Combined generator (Ranq1 = D1(A1(right-shift first))
    ///   with a period of 1.8 x 10^19.
    /// </summary>
    [CLSCompliant(true)]
    public class Random2
    {
        #region Constants

        /// <summary>
        ///   Recommended multiplier for D1 method.
        /// </summary>
        private const long A = 2685821657736338717L;

        /// <summary>
        ///   First bit shift value.
        /// </summary>
        private const int A1 = 21;

        /// <summary>
        ///   Second bit shift value.
        /// </summary>
        private const int A2 = 35;

        /// <summary>
        ///   Third bit shift value.
        /// </summary>
        private const int A3 = 4;

        /// <summary>
        ///   Initialization value.
        /// </summary>
        private const long M = 4101842887655102017L;

        #endregion

        #region Fields

        /// <summary>
        ///   Current state of the random number generation.
        /// </summary>
        private ulong v;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new random number generator with the current system
        ///   time as seed.
        /// </summary>
        public Random2()
            : this(DateTime.Now.Ticks)
        {
        }

        /// <summary>
        ///   Constructs a new random number generator with the given 64-bit
        ///   unsigned integer as seed.
        /// </summary>
        /// <param name="seed">
        ///   64-bit unsigned integer to use as seed.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="seed"/> is equal to <see cref="M"/>.
        /// </exception>
        /// <seealso cref="Seed" />
        public Random2(long seed)
        {
            if (seed == M)
            {
                throw new ArgumentOutOfRangeException(
                    "seed",
                    string.Format("Seed must be different from the constant {0}.", M));
            }

            this.Seed = seed;

            this.v = M ^ (ulong)seed;
            this.v = this.NextULong();
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Seed for the random number sequence.
        /// </summary>
        public long Seed { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Gets the next random number in the sequence and returns it as a double-precision floating-point number
        ///   between 0.0 and 1.0.
        /// </summary>
        /// <returns>
        ///   Next random number in the sequence as a double-precision floating-point number
        ///   between 0.0 and 1.0.
        /// </returns>
        public double NextDouble()
        {
            return 5.42101086242752217E-20 * this.NextULong();
        }

        /// <summary>
        ///   Gets the next random number in the sequence and returns it as a single-precision floating-point number
        ///   between 0.0f and 1.0f.
        /// </summary>
        /// <returns>
        ///   Next random number in the sequence as a single-precision floating-point number
        ///   between 0.0f and 1.0f.
        /// </returns>
        public float NextFloat()
        {
            return (float)this.NextDouble();
        }

        /// <summary>
        ///   Gets the next random number in the sequence and returns it as a 32-bit signed integer.
        /// </summary>
        /// <returns>Next random number in the sequence as a 32-bit unsigned integer.</returns>
        public int NextInt()
        {
            return (int)this.NextULong();
        }

        /// <summary>
        ///   Gets the next random number in the sequence and returns it as a 32-bit signed integer with the specified upper bound.
        /// </summary>
        /// <param name="maxExclusive">
        ///   Exclusive upper bound on the number to get.
        /// </param>
        /// <returns>
        ///   Next random number in the sequence as a 32-bit signed integer with the specified upper bound.
        /// </returns>
        public int NextInt(int maxExclusive)
        {
            return (int)(this.NextULong() % (ulong)maxExclusive);
        }

        /// <summary>
        ///   Gets the next random number in the sequence and returns it as a 64-bit signed integer.
        /// </summary>
        /// <returns>Next random number in the sequence as a 64-bit unsigned integer.</returns>
        public long NextLong()
        {
            return (long)this.NextULong();
        }

        /// <summary>
        ///   Gets the next random number in the sequence and returns it as a 64-bit signed integer with the specified upper bound.
        /// </summary>
        /// <param name="maxExclusive">
        ///   Exclusive upper bound on the number to get.
        /// </param>
        /// <returns>
        ///   Next random number in the sequence as a 64-bit signed integer with the specified upper bound.
        /// </returns>
        public long NextLong(long maxExclusive)
        {
            return (long)(this.NextULong() % (ulong)maxExclusive);
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Gets the next random number in the sequence and returns it as a 64-bit unsigned integer.
        /// </summary>
        /// <returns>Next random number in the sequence as a 64-bit unsigned integer.</returns>
        private ulong NextULong()
        {
            this.v ^= this.v >> A1;
            this.v ^= this.v << A2;
            this.v ^= this.v >> A3;

            return this.v * A;
        }

        #endregion
    }
}