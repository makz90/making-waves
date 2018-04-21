using System;
using System.Globalization;
using System.Linq;

namespace MakingWavesApp
{
    internal class Program
    {
        private const string DateFormat = "dd.MM.yyyy";

        public static void Main(string[] args)
        {   
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong arguments count.");
                return;
            }

            SetDateFromString(args.First(), DateFormat, out var dateFrom);
            SetDateFromString(args.Last(), DateFormat, out var dateTo);

            using (var datePeriodRenderer= new DatePeriodRenderer())
            {
                datePeriodRenderer.RenderPeriod(dateFrom, dateTo);
            }
        }

        private static void SetDateFromString(string dateString, string format, out DateTime date)
        {
            try
            {
                date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not parse date. Make sure date format is {format}.");
            }
        }
    }

    internal class DatePeriodRenderer : IDisposable
    {
        public void Dispose()
        {
            
        }

        public void RenderPeriod(DateTime dateFrom, DateTime dateTo)
        {
            var timeSpan = dateTo - dateFrom;
            
            if (timeSpan < TimeSpan.FromDays(1))
            
            Console.WriteLine($"{dateFrom} - {dateTo}");
        }
    }
}