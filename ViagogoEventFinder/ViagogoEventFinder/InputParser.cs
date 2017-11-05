using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagogoEventFinder
{
    /// <summary>
    /// Takes an input string and parses it into coordinate form (X, Y). If input is valid return a location vector with 
    /// the coordinates, else throw an exception.
    /// </summary>
    static class InputParser
    {
        public static LocationVector Parse(string input)
        {
            string[] coordinateStr = input.Replace(" ", "").Split(',');
            int[] coordinates = { 0, 0 };

            if (coordinateStr.Length != 2)
            {
                throw new ArgumentException("Input must have 1 comma between the 2 coordinates.");
            }

            for (int i = 0; i < 2; i++)
            {
                bool validInt = Int32.TryParse(coordinateStr[i], out coordinates[i]);
                if (!validInt)
                {
                    throw new ArgumentException("Input must be integer coordinate values.");
                }
            }

            return new LocationVector(coordinates[0], coordinates[1]);
        }
    }
}
