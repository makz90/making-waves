using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace MakingWavesApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {   
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong arguments count.");
                return;
            }
            
            var dateFrom = GetDateFromString(args.FirstOrDefault(), DatePeriodRenderer.FullDateFormat);
            var dateTo = GetDateFromString(args.LastOrDefault(), DatePeriodRenderer.FullDateFormat);

            if (dateFrom == null || dateTo == null)
            {
                Console.WriteLine("Date input could not be parsed.");
                return;
            }
            
            if (dateFrom >= dateTo)
            {
                Console.WriteLine("First date must be earlier than second one!");
                return;
            }
            
            var datePeriodRenderer = new DatePeriodRenderer();
            datePeriodRenderer.RenderPeriod(dateFrom.Value, dateTo.Value);
        }

        private static DateTime? GetDateFromString(string dateString, string format)
        {
            try
            {
                return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Wrong date format provided ({dateString}). Make sure date format is [{format}]");
                Debug.Print(fe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while trying to parse date ({dateString}). Please try again.");
                Debug.Print(e.Message);
            }

            return null;
        }
    }
}