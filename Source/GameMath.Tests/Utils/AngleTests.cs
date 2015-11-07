// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AngleTests.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GameMath.Tests.Utils
{
    using NUnit.Framework;

    public class AngleTests
    {
        #region Public Methods and Operators

        [Test]
        public static void TestAngleDeltaNegative()
        {
            // ARRANGE.
            const float A = Constants.PiOverFour;
            const float B = Constants.PiOverTwo;

            // ACT.
            var delta = Angle.Delta(A, B);

            // ASSERT.
            Assert.AreEqual(-Constants.PiOverFour, delta);
        }

        [Test]
        public static void TestAngleDeltaPositive()
        {
            // ARRANGE.
            const float A = Constants.PiOverTwo;
            const float B = Constants.PiOverFour;

            // ACT.
            var delta = Angle.Delta(A, B);

            // ASSERT.
            Assert.AreEqual(Constants.PiOverFour, delta);
        }

        [Test]
        public static void TestAngleDeltaWrappedAround()
        {
            // ARRANGE.
            const float A = Constants.Pi * 3 / 2;
            const float B = 0;

            // ACT.
            var delta = Angle.Delta(A, B);

            // ASSERT.
            Assert.AreEqual(-Constants.PiOverTwo, delta);
        }

        [Test]
        public static void TestBetweenXAndY()
        {
            // ACT.
            var angle = Angle.Between(Vector2F.UnitX, Vector2F.UnitY);

            // ASSERT.
            Assert.AreEqual(Angle.DegreesToRadians(90.0f), angle);
        }

        [Test]
        public static void TestFromUnitVector()
        {
            // ARRANGE.
            var v = new Vector2F(0.5f, 0.5f);

            // ACT.
            var angle = Angle.FromVector(v);

            // ASSERT.
            Assert.AreEqual(Angle.DegreesToRadians(45.0f), angle);
        }

        #endregion
    }
}