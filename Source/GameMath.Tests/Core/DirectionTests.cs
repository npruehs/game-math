namespace GameMath.Tests.Core
{
    using NUnit.Framework;

    public class DirectionTests
    {
        #region Public Methods and Operators

        [Test]
        public void TestIsDiagonal()
        {
            Assert.IsTrue(Direction.SouthEast.IsDiagonal());
        }

        [Test]
        public void TestIsHorizontal()
        {
            Assert.IsTrue(Direction.West.IsHorizontal());
        }

        [Test]
        public void TestIsNotDiagonal()
        {
            Assert.IsFalse(Direction.South.IsDiagonal());
        }

        [Test]
        public void TestIsNotHorizontal()
        {
            Assert.IsFalse(Direction.South.IsHorizontal());
        }

        [Test]
        public void TestIsNotVertical()
        {
            Assert.IsFalse(Direction.West.IsVertical());
        }

        [Test]
        public void TestIsVertical()
        {
            Assert.IsTrue(Direction.North.IsVertical());
        }

        [Test]
        public void TestOppositeDirection()
        {
            Assert.AreEqual(Direction.West, Direction.East.Opposite());
            Assert.AreEqual(Direction.NorthEast, Direction.SouthWest.Opposite());
        }

        #endregion
    }
}