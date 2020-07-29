namespace XirgoDataProcessor.Models
{
    public class Trip
    {
        public User User { get; set; }
        public Bike Bike { get; set; }
        public Station StartStation { get; set; }
        public Location StartLocation { get; set; }
        public Station EndStation { get; set; }
        public Location EndLocation { get; set; }
        public Duration Duration { get; set; }
    }
}