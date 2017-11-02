using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoEventFinder;

namespace ViagogoEventFinderTest
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public void TestNewWorldDimensions()
        {
            World testWorld = new World(10);

            Assert.AreEqual(21, testWorld.GetWorldXLength());
            Assert.AreEqual(21, testWorld.GetWorldYLength());
        }

        [TestMethod]
        public void TestGetEventWhereNoEventExists()
        {
            World testWorld = new World(10);
            Assert.AreEqual(null, testWorld.GetEventFromLocation(0, 0));
        }

        [TestMethod]
        public void TestAddAndRetrieveNewEvent()
        {
            World testWorld = new World(10);
            Event testEvent = new Event(52, new LocationVector(-6, 8));

            testWorld.AddEventAtLocation(testEvent);
            Event returnedEvent = testWorld.GetEventFromLocation(-6, 8);

            Assert.AreEqual(testEvent, returnedEvent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddNewEventOutOfBounds()
        {
            World testWorld = new World(10);
            testWorld.AddEventAtLocation(new Event(0, new LocationVector(11, -5)));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestGettingEventOutOfBounds()
        {
            World testWorld = new World(10);
            testWorld.GetEventFromLocation(4, -15);
        }
    }
}
