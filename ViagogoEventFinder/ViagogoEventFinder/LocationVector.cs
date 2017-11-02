using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    /// <summary>
    /// Stores the x and y coordinates of a location (limiting them within bounds) and provides methods for vector distance calculation.
    /// </summary>
    class LocationVector
    {
        public int x { get; private set; } 
        public int y { get; private set; }
        private int coordinateLimit = 10;   // This maximum/minimum coordinate value allowed within this 'world'

        public LocationVector(int x, int y)
        {
            if (x < -coordinateLimit || x > coordinateLimit || y < -coordinateLimit || y > coordinateLimit)
            {
                throw new ArgumentOutOfRangeException("x/y", "Input coordinate outside coordinate limits.");
            }

            this.x = x;
            this.y = y;
        }
    }
}
