using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    static class EventFinder
    {
        public static List<EventWithDistance> FindClosestEvents(World world, LocationVector location, int eventsToFind)
        {
            List<Event> allEvents = world.GetEventList();
            List<EventWithDistance> eventDistances = new List<EventWithDistance>();

            foreach (Event _event in allEvents)
            {
                eventDistances.Add(new EventWithDistance(location, _event));
            }

            eventDistances = eventDistances.OrderBy(i => i.distance).ToList();

            return eventDistances.GetRange(0, eventsToFind);
        }
    }
}
