using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoEventFinder;
using System.Collections.Generic;

namespace ViagogoEventFinderTest
{
    [TestClass]
    public class EventFinderTest
    {
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestInvalidInputCoordinates()
        {
            World world = new World(10);
            Event testEvent = new Event(0, new LocationVector(0, 0));
            world.AddEventAtLocation(testEvent);

            EventFinder.FindClosestEvents(world, new LocationVector(11, -5), 1);
        }

        [TestMethod]
        public void TestOneClosestEvent()
        {
            World world = new World(10);
            Event testEvent = new Event(0, new LocationVector(5, -2));
            world.AddEventAtLocation(testEvent);

            List<EventWithDistance> closestEvents = EventFinder.FindClosestEvents(world, new LocationVector(0, 0), 1);

            Assert.AreEqual(1, closestEvents.Count);
            //Assert.AreEqual(testEvent, closestEvents[0]._event);
            Assert.AreEqual(testEvent, closestEvents[0]._event);
        }

        [TestMethod]
        public void TestEventsOrderedByDistance()
        {
            World world = new World(10);
            Event event1 = new Event(0, new LocationVector(0, 1));
            Event event2 = new Event(0, new LocationVector(0, 3));
            Event event3 = new Event(0, new LocationVector(0, 2));
            world.AddEventAtLocation(event1);
            world.AddEventAtLocation(event2);
            world.AddEventAtLocation(event3);

            List<EventWithDistance> closestEvents = EventFinder.FindClosestEvents(world, new LocationVector(0, 0), 3);

            Assert.AreEqual(event1, closestEvents[0]._event);
            Assert.AreEqual(event3, closestEvents[1]._event);
            Assert.AreEqual(event2, closestEvents[2]._event);
        }

        [TestMethod]
        public void TestFind3WithManyEventsAvailable()
        {
            World world = new World(10);
            LocationVector userLocation = new LocationVector(2, 4);
            Event event1 = new Event(0, new LocationVector(-8, 2)); // Distance = 12
            Event event2 = new Event(0, new LocationVector(6, 3));  // Distance = 5
            Event event3 = new Event(0, new LocationVector(-3, 2));  // Distance = 7
            Event event4 = new Event(0, new LocationVector(0, 0));  // Distance = 6
            Event event5 = new Event(0, new LocationVector(4, 2));  // Distance = 4
            world.AddEventAtLocation(event1);
            world.AddEventAtLocation(event2);
            world.AddEventAtLocation(event3);
            world.AddEventAtLocation(event4);
            world.AddEventAtLocation(event5);

            List<EventWithDistance> closestEvents = EventFinder.FindClosestEvents(world, new LocationVector(2, 4), 3);

            Assert.AreEqual(3, closestEvents.Count);
            Assert.AreEqual(event5, closestEvents[0]._event);
            //Assert.AreEqual(event2, closestEvents[1]._event);
            //Assert.AreEqual(event4, closestEvents[2]._event);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestNotEnoughEventsAvailable()
        {
            World world = new World(10);
            Event event1 = new Event(0, new LocationVector(0, 1));
            Event event2 = new Event(0, new LocationVector(0, 3));
            world.AddEventAtLocation(event1);
            world.AddEventAtLocation(event2);

            List<EventWithDistance> closestEvents = EventFinder.FindClosestEvents(world, new LocationVector(0, 0), 3);
        }
    }
}