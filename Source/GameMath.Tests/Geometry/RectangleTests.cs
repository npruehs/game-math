namespace GameMath.Tests.Geometry
{
    using NUnit.Framework;

    public class RectangleTests
    {
        #region Public Methods and Operators

        [Test]
        public void TestRectangleFCenter()
        {
            // ARRANGE.
            var rectangle = new RectangleF(new Vector2F(2, 3), new Vector2F(6, 8));
            var center = new Vector2F(5, 7);

            // ASSERT.
            Assert.AreEqual(center, rectangle.Center);
        }

        [Test]
        public void TestRectangleICenter()
        {
            // ARRANGE.
            var rectangle = new RectangleI(new Vector2I(2, 3), new Vector2I(6, 8));
            var center = new Vector2I(5, 7);

            // ASSERT.
            Assert.AreEqual(center, rectangle.Center);
        }

        #endregion
    }
}