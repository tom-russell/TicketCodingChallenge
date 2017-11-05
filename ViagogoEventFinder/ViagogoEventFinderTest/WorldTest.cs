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
            LocationVector location = new LocationVector(0, 0);

            Assert.AreEqual(null, testWorld.GetEventFromLocation(location));
        }

        [TestMethod]
        public void TestAddAndRetrieveNewEvent()
        {
            World testWorld = new World(10);
            LocationVector location = new LocationVector(-6, 8);
            Event testEvent = new Event(52, location);

            testWorld.AddEventAtLocation(testEvent);
            Event returnedEvent = testWorld.GetEventFromLocation(location);

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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGettingEventOutOfBounds()
        {
            World testWorld = new World(10);
            LocationVector location = new LocationVector(4, -15);

            testWorld.GetEventFromLocation(location);
        }

        [TestMethod]
        public void TestGetAllEvents()
        {
            World testWorld = new World(10);
            Assert.AreEqual(0, testWorld.GetEventList().Count);

            for (int i=0; i < 10; i++)
            {
                LocationVector loc = new LocationVector(i, i);
                testWorld.AddEventAtLocation(new Event(0, loc));
            }

            Assert.AreEqual(10, testWorld.GetEventList().Count);
        }
    }
}
