using System;
using MakingWavesApp.Converters;
using MakingWavesApp.Renderers;

namespace MakingWavesApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var converter = new DateInputConverter(DatePeriodRenderer.FullDateFormat);
            converter.InitializeDates(args);
            if (converter.DateFrom == null || converter.DateTo == null) return;
            
            var datePeriodRenderer = new DatePeriodRenderer();
            var renderedPeriod = datePeriodRenderer.RenderPeriod(converter.DateFrom.Value, converter.DateTo.Value);
            
            Console.WriteLine(renderedPeriod);
        }
    }
}