namespace GameMath.Tests
{
    using NUnit.Framework;

    public class InRangeTests
    {
        #region Public Methods and Operators

        [Test]
        public static void TestIsInRange()
        {
            // ARRANGE.
            const int X = 3;
            const int Min = 1;
            const int Max = 5;

            // ACT.
            var inRange = X.IsWithinBounds(Min, Max);

            // ASSERT.
            Assert.True(inRange);
        }

        [Test]
        public static void TestLargerThanMax()
        {
            // ARRANGE.
            const int X = 7;
            const int Min = 1;
            const int Max = 5;

            // ACT.
            var inRange = X.IsWithinBounds(Min, Max);

            // ASSERT.
            Assert.False(inRange);
        }

        [Test]
        public static void TestSmallerThanMin()
        {
            // ARRANGE.
            const int X = 0;
            const int Min = 1;
            const int Max = 5;

            // ACT.
            var inRange = X.IsWithinBounds(Min, Max);

            // ASSERT.
            Assert.False(inRange);
        }

        #endregion
    }
}