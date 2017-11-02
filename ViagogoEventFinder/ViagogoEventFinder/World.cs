using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    class World
    {
        private int maxCoordinate;
        public Event[,] world;

        public World(int maxCoordinate)
        {
            this.maxCoordinate = maxCoordinate;

            int arrayDimensions = maxCoordinate * 2 + 1; // maxCoordinate of 10 means -10/+10, so world array must be 21 x 21
            world = new Event[arrayDimensions, arrayDimensions];
        }

        // Returns the event at the equivalent world array index to the input coordinates
        public Event GetEventFromLocation(int x, int y)
        {
            return world[x + 10, y + 10];
        }

        public void AddEventAtLocation(Event newEvent)
        {
            world[newEvent.location.x + 10, newEvent.location.y + 10] = newEvent;
        }

        public int GetWorldXLength() { return world.GetLength(0); }
        public int GetWorldYLength() { return world.GetLength(0); }
    }
}
