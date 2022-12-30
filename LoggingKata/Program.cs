﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            //logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            //logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // Done -TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Done - Create a `double` variable to store the distance
            
            ITrackable tacoBell_A;
            ITrackable tacoBell_B;
            ITrackable pointA = null;
            ITrackable pointB= null;
            double furthestdistance = 0;
            double distance;


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)

            {
                tacoBell_A = locations[i];
                double latitudeA = tacoBell_A.Location.Latitude;
                double longitudeA = tacoBell_A.Location.Longitude;
                var corA = new GeoCoordinate(latitudeA, longitudeA);
                for (int j = 0 ; j < locations.Length; j++)
                {
                    tacoBell_B= locations[j];
                    double latitudeB = tacoBell_B.Location.Latitude;
                    double longitudeB = tacoBell_B.Location.Longitude;
                    var corb = new GeoCoordinate(latitudeB, longitudeB);
                    distance = corA.GetDistanceTo(corb);
                    if (furthestdistance < distance)
                    {
                        pointA= tacoBell_A;
                        pointB= tacoBell_B;
                        furthestdistance= distance;

                        
                    }
                }
            }

            Console.WriteLine($"So, you're telling me you want to find two Taco Bells that are the furthist from each other in Alabama? " +
                $"Well OK. Looks like the {pointA.Name.Replace("Tacobell ", ",and the one in ")}" +
                $" and the {pointB.Name.Replace("Tacobell ", ",")}" +
                $"are the furthest from one another.The distance between these two is {furthestdistance} meters! That's like 367.82 miles. Just thinking about how far apart " +
                $"they are is making me thirsty! I could use a Baja Blast right about now, and a Crunchwrap wouldn't hurt either, ya know?");

            // Create a new corA Coordinate with your locA's lat and long
            
            
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            
            // Create a new Coordinate with your locB's lat and long
           
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
           
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }
    }
}



/// for each loop for each data point
/// a method to compare the distances
/// 