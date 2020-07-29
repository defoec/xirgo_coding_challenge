using System;

namespace XirgoDataProcessor.Models
{
    public class Station
    {
        public Station(string stationString){
            string[] station = stationString.Split(',');
            if (station[0] != "NULL") {
                StationId = Convert.ToInt32(station[0]);
            }
            else {
                StationId = null;
            }
            StationName = station[1] ?? null;
        }
        
        public int? StationId { get; }
        public string? StationName { get; }
    }
}