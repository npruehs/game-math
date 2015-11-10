namespace GameMath.Tests
{
    using NUnit.Framework;

    public class AngleTests
    {
        #region Public Methods and Operators

        [Test]
        public static void TestAngleDeltaNegative()
        {
            // ARRANGE.
            const float A = Constant.PiOverFour;
            const float B = Constant.PiOverTwo;

            // ACT.
            var delta = Angle.Delta(A, B);

            // ASSERT.
            Assert.AreEqual(-Constant.PiOverFour, delta);
        }

        [Test]
        public static void TestAngleDeltaPositive()
        {
            // ARRANGE.
            const float A = Constant.PiOverTwo;
            const float B = Constant.PiOverFour;

            // ACT.
            var delta = Angle.Delta(A, B);

            // ASSERT.
            Assert.AreEqual(Constant.PiOverFour, delta);
        }

        [Test]
        public static void TestAngleDeltaWrappedAround()
        {
            // ARRANGE.
            const float A = Constant.Pi * 3 / 2;
            const float B = 0;

            // ACT.
            var delta = Angle.Delta(A, B);

            // ASSERT.
            Assert.AreEqual(-Constant.PiOverTwo, delta);
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