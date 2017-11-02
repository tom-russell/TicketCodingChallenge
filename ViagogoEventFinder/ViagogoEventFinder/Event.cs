using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    class Event
    {
        public int eventId { get; private set; }
        public LocationVector location { get; private set; }
        public List<Ticket> availableTickets { get; private set; }

        public Event(int eventId, LocationVector location)
        {
            if (eventId < 0)
            {
                throw new ArgumentOutOfRangeException("eventId", "eventId must be a positive number.");
            }
            if (location == null)
            {
                throw new ArgumentNullException("location", "input location must be instantiated.");
            }

            this.eventId = eventId;
            this.location = location;
            availableTickets = new List<Ticket>();
        }

        // Add a new ticket for this event
        public void AddTicket(decimal price)
        {
            availableTickets.Add(new Ticket(price));
        }

        // Return the number of tickets still available for this event
        public int TicketCount()
        {
            return availableTickets.Count();
        }

        // Return the Ticket object of the cheapest ticket still available for this event. Return null if no tickets are available.
        public Ticket CheapestTicket()
        {
            if (TicketCount() == 0)
            {
                return null;
            }

            Ticket cheapestTicket = null;

            foreach (Ticket ticket in availableTickets)
            {
                if (cheapestTicket == null || ticket.price < cheapestTicket.price)
                {
                    cheapestTicket = ticket;
                }
            }

            return cheapestTicket;
        }
    }
}
