using System;
using System.Web;

namespace RateMyPlace
{
    public class RateMyPlaceDisplayUtilities
    {
        private static int MaxStars = 10;//Maximum number of stars
        public static string generateStars(int stars)
        {
            string starsString = "";//String to hold output stars
            int iterations;
            for (iterations = 0; stars > iterations; iterations++)
            {
                starsString += "&#x2605";//Shows a full star for each given out of total
            }
            for (; MaxStars > iterations; iterations++)
            {
                starsString += "&#x2606";//Shows an empty star for each remaining out of total
            }
            return starsString;
        }
    }
}
