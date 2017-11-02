using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    class RandomWorldGenerator
    {
        private Random random;
        private int maxNumberOfTicketsPerEvent;
        private decimal maxTicketPrice;

        public RandomWorldGenerator(int maxNumberOfTicketsPerEvent = 1000, decimal maxTicketPrice = 150m)
        {
            random = new Random();
            this.maxNumberOfTicketsPerEvent = maxNumberOfTicketsPerEvent;
            this.maxTicketPrice = maxTicketPrice;
        }

        // Generate a new random world with events and tickets for each event, using the given parameters.
        public Event[,]  GenerateEvents(Event[,] newWorld)
        {
            Event thisEvent = GenerateTicketsForEvent(newWorld[0, 0]);
            
            return newWorld;
        }

        private Event GenerateTicketsForEvent(Event thisEvent)
        {
            return thisEvent;
        }

        private LocationVector RandomEmptyLocation()
        {
            return new LocationVector(0, 0);
        }
    }
}
