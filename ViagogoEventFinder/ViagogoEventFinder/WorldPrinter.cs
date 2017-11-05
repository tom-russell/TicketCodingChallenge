using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    static class WorldPrinter
    {
        // Prints out the world to console, where 'X' = event at location, '-' = no event 
        public static void PrintWorldBasic(World world)
        {
            Event[,] worldArray = world.GetEventArray();

            Console.WriteLine();

            for (int j = world.GetWorldYLength() - 1; j >= 0; j--)
            {
                StringBuilder line = new StringBuilder();

                for (int i = 0; i < world.GetWorldXLength(); i++)
                {
                    string isEvent = worldArray[i, j] != null ? "X " : "- ";
                    line.Append(isEvent);
                }

                Console.WriteLine(line.ToString());
                line.Clear();
            }
            Console.WriteLine("(X = Event at Location)\n");
        }

        // Prints out the world to console, where 'U' = user location, 'C' = close events', 'X' = other events, '-' = no event 
        public static void PrintWithClosestEvents(List<EventWithDistance> closestEvents, LocationVector userLocation, World world)
        {
            Event[,] worldArray = world.GetEventArray();

            Console.WriteLine();

            // Loop through each location in the world array, printing the relevant character 
            for (int j = world.GetWorldYLength() - 1; j >= 0; j--)
            {
                StringBuilder line = new StringBuilder();

                for (int i = 0; i < world.GetWorldXLength(); i++)
                {
                    if (i == userLocation.x + 10 && j == userLocation.y + 10)
                    {
                        line.Append("U ");
                    }
                    else if (worldArray[i, j] != null)
                    {
                        if (IsCloseEvent(new LocationVector(i - 10, j - 10), closestEvents))
                        {
                            line.Append("C ");
                        }
                        else
                        {
                            line.Append("X ");
                        }
                    }
                    else
                    {
                        line.Append("- ");
                    }
                }

                Console.WriteLine(line.ToString());
                line.Clear();
            }

            Console.WriteLine("(X = event at Location, U = user location, C = closest events)\n");
        }

        // Return true if the input location is contained within the list of closest events
        private static bool IsCloseEvent(LocationVector thisLocation, List<EventWithDistance> closestEvents)
        {
            foreach (EventWithDistance ewd in closestEvents)
            {
                LocationVector eventLocation = ewd._event.location;
                if (thisLocation.x == eventLocation.x && thisLocation.y == eventLocation.y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
