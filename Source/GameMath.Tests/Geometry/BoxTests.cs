namespace GameMath.Tests.Geometry
{
    using NUnit.Framework;

    public class BoxTests
    {
        #region Public Methods and Operators

        [Test]
        public void TestBoxFCenter()
        {
            // ARRANGE.
            var box = new BoxF(new Vector3F(2, 3, 4), new Vector3F(6, 8, 10));
            var center = new Vector3F(5, 7, 9);

            // ASSERT.
            Assert.AreEqual(center, box.Center);
        }

        [Test]
        public void TestBoxICenter()
        {
            // ARRANGE.
            var box = new BoxI(new Vector3I(2, 3, 4), new Vector3I(6, 8, 10));
            var center = new Vector3I(5, 7, 9);

            // ASSERT.
            Assert.AreEqual(center, box.Center);
        }

        #endregion
    }
}