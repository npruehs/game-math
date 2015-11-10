namespace GameMath.Tests.Intersections
{
    using NUnit.Framework;

    public class BoxIntersectionTests
    {
        #region Public Methods and Operators

        [Test]
        public void TestBoxIntersectsBox()
        {
            // ARRANGE.
            var first = new BoxF(new Vector3F(0.0f, 0.0f, 0.0f), new Vector3F(2.0f, 2.0f, 2.0f));
            var second = new BoxF(new Vector3F(1.0f, 1.0f, 1.0f), new Vector3F(2.0f, 2.0f, 2.0f));

            // ASSERT.
            Assert.IsTrue(first.Intersects(second));
        }

        [Test]
        public void TestNotBoxIntersectsBox()
        {
            // ARRANGE.
            var first = new BoxF(new Vector3F(0.0f, 0.0f, 0.0f), new Vector3F(1.0f, 1.0f, 1.0f));
            var second = new BoxF(new Vector3F(2.0f, 0.0f, 0.0f), new Vector3F(1.0f, 1.0f, 1.0f));

            // ASSERT.
            Assert.IsFalse(first.Intersects(second));
        }

        #endregion
    }
}