using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoEventFinder;
using System.Collections.Generic;

namespace ViagogoEventFinderTest
{
    [TestClass]
    public class RandomWorldGeneratorTest
    {
        [TestMethod]
        public void TestCorrectNumberOfEvents()
        {
            RandomWorldGenerator rgTest = new RandomWorldGenerator(maxCoordinate: 10, eventFrequency: 0.1f);
            World world = rgTest.GenerateEvents();
            int correctNumberOfEvents = (int)(21 * 21 * 0.1f);

            Assert.AreEqual(correctNumberOfEvents, world.GetEventList().Count);
        }

        [TestMethod]
        public void TestEventsHaveZeroToMaxTickets()
        {
            int maxTickets = 500;
            RandomWorldGenerator rgTest = new RandomWorldGenerator(maxNumberOfTicketsPerEvent: maxTickets);
            World world = rgTest.GenerateEvents();
            List<Event> allEvents = world.GetEventList();

            foreach (Event _event in allEvents)
            {
                int tickets = _event.availableTickets.Count;
                Assert.IsTrue(tickets >= 0 && tickets <= maxTickets);
            }
        }
    }
}