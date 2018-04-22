using System;

namespace MakingWavesApp.Renderers
{
    public class DatePeriodRenderer
    {
        public const string FullDateFormat = "dd.MM.yyyy";
        public const string MonthDateFormat = "dd.MM";
        public const string DayDateFormat = "dd";
        
        public string RenderPeriod(DateTime dateFrom, DateTime dateTo)
        {
            string format;

            if (dateFrom.Year != dateTo.Year)
                format = FullDateFormat;
            else if (dateFrom.Month != dateTo.Month)
                format = MonthDateFormat;
            else
                format = DayDateFormat;
            
            return $"{dateFrom.ToString(format)} - {dateTo.ToString(FullDateFormat)}";
        }
    }
}