using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    /// <summary>
    /// Represents a world as an array of events. Provides access to adding and getting events using the coordinate system.
    /// </summary>
    class World
    {
        public int maxCoordinate { get; private set; }
        private Event[,] world;
        public int totalEvents { get; set; }

        public World(int maxCoordinate)
        {
            this.maxCoordinate = maxCoordinate;

            int arrayDimensions = maxCoordinate * 2 + 1; // maxCoordinate of 10 means -10/+10, so world array must be 21 x 21
            world = new Event[arrayDimensions, arrayDimensions];
            totalEvents = 0;
        }

        // Returns the event in the world at the given location. If no event is present, null is returned
        public Event GetEventFromLocation(LocationVector location)
        {
            return world[location.x + 10, location.y + 10];
        }

        // Adds the input event to this world 
        public void AddEventAtLocation(Event newEvent)
        {
            world[newEvent.location.x + 10, newEvent.location.y + 10] = newEvent;
            totalEvents++;
        }
        
        public List<Event> GetEventList()
        {
            List<Event> allEvents = new List<Event>();

            for (int i = 0; i < GetWorldXLength(); i++)
            {
                for (int j = 0; j < GetWorldYLength(); j++)
                {
                    if (world[i, j] != null)
                    {
                        allEvents.Add(world[i, j]);
                    }
                }
            }

            return allEvents;
        }

        public Event[,] GetEventArray()
        {
            return world;
        }

        public int GetWorldXLength() { return world.GetLength(0); }
        public int GetWorldYLength() { return world.GetLength(1); }
    }
}
