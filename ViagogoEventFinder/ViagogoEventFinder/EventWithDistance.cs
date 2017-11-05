using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    class EventWithDistance
    {
        public Event _event;
        public int distance;

        public EventWithDistance(LocationVector location, Event _event)
        {
            this._event = _event;
            distance = location.ManhattanDistance(_event.location);
        }
    }
}
