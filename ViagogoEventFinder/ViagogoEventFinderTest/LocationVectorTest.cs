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
            LocationVector testVector1 = new ViagogoEventFinder.LocationVector(0, 0);
            LocationVector testVector2 = new ViagogoEventFinder.LocationVector(5, -2);
            LocationVector testVector3 = new ViagogoEventFinder.LocationVector(-10, 0);
            LocationVector testVector4 = new ViagogoEventFinder.LocationVector(0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestVector2InvalidInputCoordinates()
        {
            LocationVector testVector = new ViagogoEventFinder.LocationVector(-11, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestVector1InvalidInputCoordinate()
        {
            LocationVector testVector = new ViagogoEventFinder.LocationVector(15, 12);
        }
    }
}
