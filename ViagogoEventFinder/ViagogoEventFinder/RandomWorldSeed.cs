using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    class RandomWorldSeed
    {
        private int minNumberOfEvents = 0;
        private int maxNumberOfEvents = 0;
        private int minNumberOfTicketsPerEvent = 0;
        private int maxNumberOfTicketsPerEvent = 1000;
        private decimal maxTicketPrice = 100;
        private Random random;

        public RandomWorldSeed(int minMaxCoords = 10, int maxNumberOfEvents = 0, int maxNumberOfTicketsPerEvent = 1000)
        {
            Event[,] world = GenerateEmptyWorld(minMaxCoords);

            random = new Random();
            GenerateEvents(world);
            random.Next(-minMaxCoords, minMaxCoords + 1);
        }

        // Generate a world with no events with size coordinates provided
        private Event[,]  GenerateEmptyWorld(int minMaxCoords)
        {
            Event[,] world = new Event[minMaxCoords * 2, minMaxCoords * 2];
            return world;
        }

        private void GenerateEvents(Event[,] world)
        {
             
        }

        private void GenerateTickets(Event thisEvent)
        {

        }
    }
}
