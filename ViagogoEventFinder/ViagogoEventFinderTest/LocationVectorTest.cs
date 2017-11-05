using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoEventFinder;

namespace ViagogoEventFinderTest
{
    [TestClass]
    public class LocationVectorTest
    {
        [TestMethod]
        public void TestVectorCorrectInitialisation()
        {
            LocationVector testVector1 = new LocationVector(0, 0);
            LocationVector testVector2 = new LocationVector(5, -2);
            LocationVector testVector3 = new LocationVector(-10, 0);
            LocationVector testVector4 = new LocationVector(0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestVector2InvalidInputCoordinates()
        {
            LocationVector testVector = new LocationVector(-11, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestVector1InvalidInputCoordinate()
        {
            LocationVector testVector = new LocationVector(15, 12);
        }

        [TestMethod]
        public void TestManhattanDistanceWithSelfIsZero()
        {
            LocationVector testVector = new LocationVector(0, 0);

            Assert.AreEqual(0, testVector.ManhattanDistance(testVector));
        }

        [TestMethod]
        public void TestManhattanDistanceHorizontal()
        {
            LocationVector testVector1 = new LocationVector(-2, 5);
            LocationVector testVector2 = new LocationVector(6, 5);

            Assert.AreEqual(8, testVector1.ManhattanDistance(testVector2));
        }

        [TestMethod]
        public void TestManhattanDistanceDiagonal()
        {
            LocationVector testVector1 = new LocationVector(-10, -10);
            LocationVector testVector2 = new LocationVector(10, 10);
            LocationVector testVector3 = new LocationVector(-10, 10);
            LocationVector testVector4 = new LocationVector(10, -10);

            Assert.AreEqual(40, testVector1.ManhattanDistance(testVector2));
            Assert.AreEqual(40, testVector3.ManhattanDistance(testVector4));
        }

        [TestMethod]
        public void TestManhattanDistanceComplex()
        {
            LocationVector testVector1 = new LocationVector(-2, 3);
            LocationVector testVector2 = new LocationVector(6, -8);

            Assert.AreEqual(19, testVector1.ManhattanDistance(testVector2));
        }
    }
}
