using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    class ViagogoEventFinderApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The current world:");

            // Generate a random world with events and tickets, then print to console
            RandomWorldGenerator rwg = new RandomWorldGenerator();
            World world = rwg.GenerateEvents();
            WorldPrinter.PrintWorldBasic(world);

            // Take the users location as input
            Console.Write("Please input your location coordinates:\n>");
            string input = Console.ReadLine();
            Console.WriteLine();

            // Parse the users input and quit if the input is invalid
            LocationVector userLocation;
            try {
                userLocation = InputParser.Parse(input);
            }
            catch (ArgumentException) {
                Console.WriteLine("Invalid input, please try again.");
                return;
            };

            // Find the closest events to the user
            List<EventWithDistance> closestEvents = EventFinder.FindClosestEvents(world, userLocation, 5);

            // Print the details about each of the closest events to the user
            foreach (EventWithDistance ewd in closestEvents)
            {
                Event _event = ewd._event;
                string priceString = String.Format("{0:0.00}", _event.CheapestTicket().price);
                string eventIdStr = _event.eventId.ToString().PadLeft(3, '0');
                Console.WriteLine("Event " + eventIdStr + " - $" + priceString + ", Distance " + ewd.distance);
            }

            // Print the map, showing locations of closest events to the user 
            WorldPrinter.PrintWithClosestEvents(closestEvents, userLocation, world);
            Console.ReadLine();
        }
    }
}
