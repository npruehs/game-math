namespace GameMath.Tests.Geometry
{
    using System.Collections.Generic;

    using NUnit.Framework;

    public class PolygonTests
    {
        #region Fields

        private Polygon2F polygon;

        #endregion

        #region Public Methods and Operators

        [SetUp]
        public void SetUp()
        {
            this.polygon =
                new Polygon2F(
                    new List<Vector2F>
                    {
                        new Vector2F(1, 3),
                        new Vector2F(3, 1),
                        new Vector2F(5, 3),
                        new Vector2F(4, 5),
                        new Vector2F(2, 5)
                    });
        }

        [Test]
        public void TestPolygonContainsLineSegment()
        {
            // ARRANGE.
            var line = new LineSegment2F(new Vector2F(2, 3), new Vector2F(4, 3));

            // ASSERT.
            Assert.IsTrue(this.polygon.Contains(line));
        }

        [Test]
        public void TestPolygonContainsPoint()
        {
            // ARRANGE.
            var point = new Vector2F(3, 3);

            // ASSERT.
            Assert.IsTrue(this.polygon.Contains(point));
        }

        [Test]
        public void TestPolygonContainsPolygon()
        {
            // ARRANGE.
            var other =
                new Polygon2F(
                    new List<Vector2F>
                    {
                        new Vector2F(2.5f, 3),
                        new Vector2F(3.5f, 4),
                        new Vector2F(3.5f, 4),
                        new Vector2F(2.5f, 3)
                    });

            // ASSERT.
            Assert.IsTrue(this.polygon.Contains(other));
        }

        [Test]
        public void TestPolygonDoesNotContainIntersectingLineSegment()
        {
            // ARRANGE.
            var line = new LineSegment2F(new Vector2F(2, 3), new Vector2F(6, 3));

            // ASSERT.
            Assert.IsFalse(this.polygon.Contains(line));
        }

        [Test]
        public void TestPolygonDoesNotContainIntersectingPolygon()
        {
            // ARRANGE.
            var other =
                new Polygon2F(
                    new List<Vector2F>
                    {
                        new Vector2F(2.5f, 4),
                        new Vector2F(3.5f, 6),
                        new Vector2F(3.5f, 6),
                        new Vector2F(2.5f, 4)
                    });

            // ASSERT.
            Assert.IsFalse(this.polygon.Contains(other));
        }

        [Test]
        public void TestPolygonDoesNotContainOutsideLineSegment()
        {
            // ARRANGE.
            var line = new LineSegment2F(new Vector2F(2, 7), new Vector2F(4, 7));

            // ASSERT.
            Assert.IsFalse(this.polygon.Contains(line));
        }

        [Test]
        public void TestPolygonDoesNotContainOutsidePoint()
        {
            // ARRANGE.
            var point = new Vector2F(3, 7);

            // ASSERT.
            Assert.IsFalse(this.polygon.Contains(point));
        }

        [Test]
        public void TestPolygonDoesNotContainOutsidePolygon()
        {
            // ARRANGE.
            var other =
                new Polygon2F(
                    new List<Vector2F>
                    {
                        new Vector2F(2.5f, 6),
                        new Vector2F(3.5f, 8),
                        new Vector2F(3.5f, 8),
                        new Vector2F(2.5f, 6)
                    });

            // ASSERT.
            Assert.IsFalse(this.polygon.Contains(other));
        }

        [Test]
        public void TestPolygonIsClockwise()
        {
            // ASSERT.
            Assert.IsFalse(this.polygon.IsClockwise());
        }

        [Test]
        public void TestTriangulatePolygon()
        {
            // ACT.
            var triangles = this.polygon.Triangulate();

            // ASSERT.
            Assert.AreEqual(3, triangles.Count);

            // Note: This is one possible triangulation, but there are others.
            // If this test fails, check actual triangulation. It might be correct.
            Assert.Contains(
                new Polygon2F(new List<Vector2F> { new Vector2F(2, 5), new Vector2F(1, 3), new Vector2F(3, 1) }),
                triangles);
            Assert.Contains(
                new Polygon2F(new List<Vector2F> { new Vector2F(2, 5), new Vector2F(3, 1), new Vector2F(5, 3) }),
                triangles);
            Assert.Contains(
                new Polygon2F(new List<Vector2F> { new Vector2F(5, 3), new Vector2F(4, 5), new Vector2F(2, 5) }),
                triangles);
        }

        #endregion
    }
}