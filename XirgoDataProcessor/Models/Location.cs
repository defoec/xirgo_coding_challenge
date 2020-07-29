using System;

namespace XirgoDataProcessor.Models
{
    public class Location
    {
        public Location(string locationString){
            string[] location = locationString.Split(',');
            Latitude = Convert.ToDecimal(location[0]);
            Longitude = Convert.ToDecimal(location[1]);
        }
        
        public decimal Latitude { get; }
        public decimal Longitude { get; }
    }
}