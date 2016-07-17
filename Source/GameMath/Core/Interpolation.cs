namespace GameMath
{
    using System;

    /// <summary>
    ///   Interpolates between two values.
    /// </summary>
    [CLSCompliant(true)]
    public static class Interpolation
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Boing-like interpolation between the two passed values,
        ///   overshooting around the center.
        /// </summary>
        /// <param name="x">
        ///   First value to interpolate.
        /// </param>
        /// <param name="y">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="x" />, 1 returns <paramref name="y" />.
        /// </param>
        /// <returns>
        ///   Boing-like interpolation between the two passed values.
        /// </returns>
        /// <remarks>
        ///   See https://www.thegamecreators.com/pages/newsletters/newsletter_issue_114.html for details.
        /// </remarks>
        public static float Berp(float x, float y, float l)
        {
            l = (Angle.Sin(l * 3.14159f * (0.2f + 2.5f * l * l * l)) * (1.0f - MathF.Pow(l, 2.2f)) + l)
                * (1.0f + (1.2f * (1.0f - l)));
            return x + (y - x) * l;
        }

        /// <summary>
        ///   Cosinusoidally interpolates between the two passed values.
        /// </summary>
        /// <param name="x">
        ///   First value to interpolate.
        /// </param>
        /// <param name="y">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="x" />, 1 returns <paramref name="y" />.
        /// </param>
        /// <returns>
        ///   Cosinusoidally interpolation between the two passed values.
        /// </returns>
        /// <remarks>
        ///   See https://chicounity3d.wordpress.com/2014/05/23/how-to-lerp-like-a-pro/ for details.
        /// </remarks>
        public static float EaseIn(float x, float y, float l)
        {
            if (l <= 0.0f)
            {
                return x;
            }

            if (l >= 1.0f)
            {
                return y;
            }

            return 1.0f - Angle.Cos(l * Constant.Pi * 0.5f);
        }

        /// <summary>
        ///   Sinusoidally interpolates between the two passed values.
        /// </summary>
        /// <param name="x">
        ///   First value to interpolate.
        /// </param>
        /// <param name="y">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="x" />, 1 returns <paramref name="y" />.
        /// </param>
        /// <returns>
        ///   Sinusoidal interpolation between the two passed values.
        /// </returns>
        /// <remarks>
        ///   See https://chicounity3d.wordpress.com/2014/05/23/how-to-lerp-like-a-pro/ for details.
        /// </remarks>
        public static float EaseOut(float x, float y, float l)
        {
            if (l <= 0.0f)
            {
                return x;
            }

            if (l >= 1.0f)
            {
                return y;
            }

            return Angle.Sin(l * Constant.Pi * 0.5f);
        }

        /// <summary>
        ///   Linearly interpolates between the two passed values.
        /// </summary>
        /// <param name="x">
        ///   First value to interpolate.
        /// </param>
        /// <param name="y">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="x" />, 1 returns <paramref name="y" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two passed values.
        /// </returns>
        public static float Lerp(float x, float y, float l)
        {
            if (l <= 0.0f)
            {
                return x;
            }

            if (l >= 1.0f)
            {
                return y;
            }

            return x + (l * (y - x));
        }

        /// <summary>
        ///   Smoother Hermite interpolation between the two passed values,
        ///   easing in and out at the borders, as proposed by Ken Perlin.
        /// </summary>
        /// <param name="x">
        ///   First value to interpolate.
        /// </param>
        /// <param name="y">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="x" />, 1 returns <paramref name="y" />.
        /// </param>
        /// <returns>
        ///   Smoother Hermite interpolation between the two passed values.
        /// </returns>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Smoothstep for details.
        /// </remarks>
        public static float SmootherStep(float x, float y, float l)
        {
            if (l <= 0.0f)
            {
                return x;
            }

            if (l >= 1.0f)
            {
                return y;
            }

            return l * l * l * (l * (6.0f * l - 15.0f) + 10.0f);
        }

        /// <summary>
        ///   Smooth Hermite interpolation between the two passed values,
        ///   easing in and out at the borders.
        /// </summary>
        /// <param name="x">
        ///   First value to interpolate.
        /// </param>
        /// <param name="y">
        ///   Second value to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="x" />, 1 returns <paramref name="y" />.
        /// </param>
        /// <returns>
        ///   Smooth Hermite interpolation between the two passed values.
        /// </returns>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Smoothstep for details.
        /// </remarks>
        public static float SmoothStep(float x, float y, float l)
        {
            if (l <= 0.0f)
            {
                return x;
            }

            if (l >= 1.0f)
            {
                return y;
            }

            return l * l * (3.0f - 2.0f * l);
        }

        #endregion
    }
}