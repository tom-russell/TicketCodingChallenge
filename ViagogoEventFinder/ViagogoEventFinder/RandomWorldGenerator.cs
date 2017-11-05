using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    /// <summary>
    /// RandomWorldGenerator - using the GenerateEvents() function generates a World object with events, and tickets for those events.
    /// The constructor allows initialisation of several random parameters for ticket numbers/price, the frequency of events and the world size. 
    /// </summary>
    class RandomWorldGenerator
    {
        private Random random;
        private int maxNumberOfTicketsPerEvent;
        private decimal maxTicketPrice;
        private int nextEventId;        
        private int maxCoordinate;              // The maximum coordinate value for the world (e.g. 10 means x and y go from -10 -> +10)
        private float eventFrequency;           // The average chance that a location is holding an event

        public RandomWorldGenerator(int maxCoordinate = 10, int maxNumberOfTicketsPerEvent = 200, decimal maxTicketPrice = 150m, float eventFrequency = 0.1f)
        {
            random = new Random();
            this.maxNumberOfTicketsPerEvent = maxNumberOfTicketsPerEvent;
            this.maxTicketPrice = maxTicketPrice;
            this.maxCoordinate = maxCoordinate;
            this.eventFrequency = eventFrequency;
        }

        // Generate a new random world with events and tickets for each event, using the given parameters.
        public World GenerateEvents()
        {
            World newWorld = new World(maxCoordinate);

            nextEventId = 0;
            int maxLocations = newWorld.GetWorldXLength() * newWorld.GetWorldYLength();
            int numberOfEvents = (int)(maxLocations * eventFrequency);

            for (int i = 0; i < numberOfEvents; i++)
            {
                LocationVector emptyLocation = RandomEmptyLocation(newWorld);
                GenerateEventWithTickets(newWorld, emptyLocation);
            }

            return newWorld;
        }

        // Create an event at the given world location. A random number of tickets with random prices are also generated for the event.        
        private void GenerateEventWithTickets(World newWorld, LocationVector emptyLocation)
        {
            Event newEvent = new Event(nextEventId++, emptyLocation);

            int totalTickets = random.Next(maxNumberOfTicketsPerEvent + 1);
            for (int i = 0; i < totalTickets; i++)
            {
                decimal ticketPrice = GenerateTicketPrice();
                newEvent.AddTicket(ticketPrice);
            }

            newWorld.AddEventAtLocation(newEvent);
        }

        // Finds a random location in the world no event, by looping until an empty location is found.
        private LocationVector RandomEmptyLocation(World newWorld)
        {
            bool emptyLocationFound = false;
            LocationVector randomLocation;

            do
            {
                int xCoordinate = random.Next(-newWorld.maxCoordinate, newWorld.maxCoordinate + 1);
                int yCoordinate = random.Next(-newWorld.maxCoordinate, newWorld.maxCoordinate + 1);
                randomLocation = new LocationVector(xCoordinate, yCoordinate);
                
                Event randomEvent = newWorld.GetEventFromLocation(randomLocation);

                if (randomEvent == null)
                {
                    emptyLocationFound = true;
                }
            }
            while (emptyLocationFound == false);

            return randomLocation;
        }

        // Generate a random ticket price from a normal distribution with mean half the max value, stdDev at 1/6 the max value,
        // with the result clamped between 0 and max value.
        // (This function is sourced from online: https://stackoverflow.com/questions/218060/random-gaussian-variables)
        private decimal GenerateTicketPrice()
        {

            double maxValue = (double)maxTicketPrice;
            double mean = maxValue / 2;
            double stdDev = maxValue / 6;
            
            double u1 = 1.0 - random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal =  Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

            // Clamp value between 0 and maxValue
            if (randNormal < 1) randNormal = 1;
            else if (randNormal > maxValue) randNormal = maxValue;
            return (decimal)randNormal;
        }
    }
}
