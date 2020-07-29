using System.Text;
using System.IO;
using System;

namespace XirgoDataProcessor
{
    public class Program
    {
        private static string path = "./ridelog.dat";

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)){
                using (BinaryReader input = new BinaryReader(fs, Encoding.ASCII)){
                    int length = (int)input.BaseStream.Length;

                    sb.Append(input.ReadChars(length));
                }
            }

            var dataProcessor = new DataProcessor(sb.ToString());
            var trips = dataProcessor.Trips;

            Console.WriteLine("Total duration of all trips: {0}\n", dataProcessor.GetTotalTripDurationInSeconds(trips));
            Console.WriteLine("Percentage riders over 40: {0}\n", dataProcessor.GetPercentageRidersOverForty(trips));
            Console.WriteLine("Total number of trips by subscribers: {0}\n", dataProcessor.GetTripsBySubscribers(trips));
            Console.WriteLine("Most popular hour for bike rides: {0}\n", dataProcessor.GetMostPopularTripStartHour(trips));
            Console.WriteLine("Least popular hour for bike rides: {0}\n", dataProcessor.GetLeastPopularTripStartHour(trips));
            Console.WriteLine("Most used bike id: {0}\n", dataProcessor.GetMostPopularBikeId(trips));

            Console.ReadLine();
        }
    }
}
