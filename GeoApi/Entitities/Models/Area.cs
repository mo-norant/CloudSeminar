using GeoGame.Entitities.POI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoGame.Entitities.Models
{
    public class Area
    {
        private Random r = new Random();
        public int AreaID { get; set; }
        public ICollection<Location> PointofInterests { get; private set; }
        public string Name { get; set; }

        public void GenerateLocations( Location startLocation, int count)
        {
            PointofInterests = new List<Location>();
            for (int i = 0; i < count; i++)
            {
                var location = GenerateLocation(startLocation);
                PointofInterests.Add(location);
            } 
        }

        private GamePoint GenerateLocation(Location startLocation)
        {
            var location = new GamePoint
            {
                IsActive = true,
                ScorePoints = r.Next(0, 100),
                Lat = startLocation.Lat + (float)GetRandomNumber(0.00095, 1.00095),
                Lng = startLocation.Lng + (float)GetRandomNumber(0.00095, 1.00095)
            };
            return location;
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            return r.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
