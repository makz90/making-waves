using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using MakingWavesApp.Renderers;

namespace MakingWavesApp.Converters
{
    public class DateInputConverter
    {
        private readonly string _dateFormat;

        public DateInputConverter()
        {
            _dateFormat = DatePeriodRenderer.FullDateFormat;
        }
        
        public DateInputConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public DateTime? DateFrom { get; private set; }
        
        public DateTime? DateTo { get; private set; }
        
        public void InitializeDates(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong arguments count.");
                return;
            }
            
            var dateFrom = GetDateFromString(args.FirstOrDefault());
            var dateTo = GetDateFromString(args.LastOrDefault());

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

            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        private DateTime? GetDateFromString(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, _dateFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Wrong date format provided ({dateString}). Make sure date format is [{_dateFormat}]");
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