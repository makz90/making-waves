using System;

namespace MakingWavesApp
{
    public class DatePeriodRenderer
    {
        public const string FullDateFormat = "dd.MM.yyyy";
        public const string MonthDateFormat = "dd.MM";
        public const string DayDateFormat = "dd";
        
        public void RenderPeriod(DateTime dateFrom, DateTime dateTo)
        {
            string format;

            if (dateFrom.Year != dateTo.Year)
                format = FullDateFormat;
            else if (dateFrom.Month != dateTo.Month)
                format = MonthDateFormat;
            else
                format = DayDateFormat;
            
            Console.WriteLine($"{dateFrom.ToString(format)} - {dateTo.ToString(FullDateFormat)}");
        }
    }
}