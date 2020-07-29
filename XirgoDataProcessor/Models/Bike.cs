using System;

namespace XirgoDataProcessor.Models
{
    public class Bike
    {
        public Bike(string bikeString) {
            string[] bike = bikeString.Split(',');
            BikeId = Convert.ToInt32(bike[0]);
            BikeType = Convert.ToChar(bike[1]);
        }
        
        public int BikeId { get; }
        public char BikeType { get; }
    }
}