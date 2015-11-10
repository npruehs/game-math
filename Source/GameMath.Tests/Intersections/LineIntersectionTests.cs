namespace GameMath.Tests.Intersections
{
    using NUnit.Framework;

    public class LineIntersectionTests
    {
        #region Public Methods and Operators

        [Test]
        public void TestLineIntersectsCircle()
        {
            // ARRANGE.
            var line = new LineSegment2F(new Vector2F(-2.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            var circle = CircleF.UnitCircle;

            Vector2F? first;
            Vector2F? second;

            // ACT.
            var intersects = line.Intersects(circle, out first, out second);

            // ASSERT.
            Assert.IsTrue(intersects);
            Assert.IsNotNull(first);
            Assert.IsNotNull(second);
            Assert.AreEqual(new Vector2F(1.0f, 0.0f), first);
            Assert.AreEqual(new Vector2F(-1.0f, 0.0f), second);
        }

        #endregion
    }
}