using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    /// <summary>
    /// Represents a ticket for a single event in a single location.
    /// </summary>
    class Ticket
    {
        public decimal price { get; private set; }  // Price of this ticket in dollars

        public Ticket(decimal price)
        {
            this.price = price;
        }
    }
}
