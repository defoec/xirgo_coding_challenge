using XirgoDataProcessor.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace XirgoDataProcessor
{
    public class DataProcessor
    {
        public IEnumerable<Trip> Trips;

        public DataProcessor(string data) {
            Trips = GetParsedData(data);
        }

        public int GetTotalTripDurationInSeconds(IEnumerable<Trip> trips) {
            int totalDuration = 0;
            foreach (var trip in trips){
                totalDuration += trip.Duration.DurationTime;
            }
            return totalDuration;
        }

        public decimal GetPercentageRidersOverForty(IEnumerable<Trip> trips) {
            int currentYear = DateTime.Today.Year;
            int ridersOverForty = trips.Where(t => t.User.UserBirthYear < (currentYear - 40)).Count();
            int totalRiders = trips.Select(t => t.User).Distinct().Count();
            
            return Convert.ToDecimal((double)ridersOverForty / (double)totalRiders);
        }

        public int GetTripsBySubscribers(IEnumerable<Trip> trips) {
            return trips.Where(t => t.User.UserType == 01).Count();
        }

        public int GetMostPopularBikeId(IEnumerable<Trip> trips) {
            var bikes = trips.Select(t => t.Bike);
            var sortedBikes = bikes.GroupBy(b => b.BikeId).OrderByDescending(x => x.Count()).FirstOrDefault();
            var mostPopularBike = sortedBikes.Key;
            return mostPopularBike;
        }

        public int GetMostPopularTripStartHour(IEnumerable<Trip> trips) {
            var tripStartTimes = trips.Select(t => GetTrimmedHour(t.Duration.StartTime));
            return tripStartTimes.GroupBy(h => h).OrderByDescending(grp => grp.Count()).FirstOrDefault().Key;
        }

        public int GetLeastPopularTripStartHour(IEnumerable<Trip> trips) {
            var tripStartTimes = trips.Select(t => GetTrimmedHour(t.Duration.StartTime));
            return tripStartTimes.GroupBy(h => h).OrderByDescending(grp => grp.Count()).LastOrDefault().Key;
        }

        private int GetTrimmedHour(decimal startTime) {
            var dateTime = new DateTime(1899, 12, 31).AddDays(Convert.ToDouble(startTime));
            return dateTime.Hour;
        }

        private IEnumerable<Trip> GetParsedData(string data) {
            List<Trip> trips = new List<Trip>();
            // parse all data into trips as strings
            char[] charsToTrim = { '!', '%' };
            string[] tripsAsStrings = data.Split('%');

            // convert trip strings collection into trip object collection
            foreach (var tripString in tripsAsStrings) {
                var trimmedTripString = tripString.Trim(charsToTrim);
                if (trimmedTripString == "" || trimmedTripString == " ")
                {
                    continue;
                }
                string[] splitTripString = trimmedTripString.Split('|');

                // new up trip
                Duration duration = new Duration(splitTripString[0]);
                Station startStation = new Station(splitTripString[1]);
                Location startLocation = new Location(splitTripString[2]);
                Station endStation = new Station(splitTripString[3]);
                Location endLocation = new Location(splitTripString[4]);
                Bike bike = new Bike(splitTripString[5]);
                User user = new User(splitTripString[6]);

                Trip trip = new Trip()
                {
                    Bike = bike,
                    Duration = duration,
                    StartStation = startStation,
                    StartLocation = startLocation,
                    EndStation = endStation,
                    EndLocation = endLocation,                    
                    User = user
                };

                trips.Add(trip);
            }

            return trips;
        }
    }
}