using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagogoEventFinder;

namespace ViagogoEventFinderTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void TestValidInitialisation()
        {
            Event testEvent = new Event(3, new LocationVector(0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidEventIdInitialisation()
        {
            Event testEvent = new Event(-1, new LocationVector(0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullEventLocationInitialisation()
        {
            Event testEvent = new Event(0, null);
        }

        [TestMethod]
        public void TestAddTicketToEvent()
        {
            Event testEvent = new Event(0, new LocationVector(0, 0));

            Assert.AreEqual(0, testEvent.TicketCount());
            testEvent.AddTicket(30.20m);
            Assert.AreEqual(1, testEvent.TicketCount());
            testEvent.AddTicket(35.42m);
            testEvent.AddTicket(14.20m);
            Assert.AreEqual(3, testEvent.TicketCount());
        }

        [TestMethod]
        public void TestFindLowestTicketPriceNoneAvailable()
        {
            Event testEvent = new Event(5, new LocationVector(0, 0));
            Assert.AreEqual(null, testEvent.CheapestTicket());
        }

        [TestMethod]
        public void TestFindLowestAvailableTicketPrice()
        {
            Event testEvent = new Event(5, new LocationVector(0, 0));
            testEvent.AddTicket(30.20m);
            Assert.AreEqual(30.20m, testEvent.CheapestTicket().price);
            testEvent.AddTicket(35.42m);
            testEvent.AddTicket(14.20m);
            Assert.AreEqual(14.20m, testEvent.CheapestTicket().price);
        }
    }
}
