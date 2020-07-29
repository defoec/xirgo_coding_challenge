using System;

namespace XirgoDataProcessor.Models
{
    public class Duration
    {
        public Duration(string durationString){
            string[] duration = durationString.Split(',');
            DurationTime = Convert.ToInt32(duration[0]);
            StartTime = Convert.ToDecimal(duration[1]);
            EndTime = Convert.ToDecimal(duration[2]);
        }
        public int DurationTime { get; }
        public decimal StartTime { get; }
        public decimal EndTime { get; }
    }
}