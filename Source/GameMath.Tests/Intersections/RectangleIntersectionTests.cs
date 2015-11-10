namespace GameMath.Tests.Intersections
{
    using NUnit.Framework;

    public class RectangleIntersectionTests
    {
        #region Public Methods and Operators

        [Test]
        public void TestNotRectangleIntersectsCircle()
        {
            // ARRANGE.
            var rectangle = new RectangleF(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            var circle = new CircleF(new Vector2F(2.0f, 2.0f), 0.5f);

            // ASSERT.
            Assert.IsFalse(rectangle.Intersects(circle));
        }

        [Test]
        public void TestNotRectangleIntersectsRectangle()
        {
            // ARRANGE.
            var first = new RectangleF(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            var second = new RectangleF(new Vector2F(2.0f, 0.0f), new Vector2F(1.0f, 1.0f));

            // ASSERT.
            Assert.IsFalse(first.Intersects(second));
        }

        [Test]
        public void TestRectangleIntersectsCircle()
        {
            // ARRANGE.
            var rectangle = new RectangleF(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            var circle = new CircleF(new Vector2F(1.0f, 1.0f), 0.5f);

            // ASSERT.
            Assert.IsTrue(rectangle.Intersects(circle));
        }

        [Test]
        public void TestRectangleIntersectsRectangle()
        {
            // ARRANGE.
            var first = new RectangleF(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            var second = new RectangleF(new Vector2F(1.0f, 1.0f), new Vector2F(2.0f, 2.0f));

            // ASSERT.
            Assert.IsTrue(first.Intersects(second));
        }

        #endregion
    }
}