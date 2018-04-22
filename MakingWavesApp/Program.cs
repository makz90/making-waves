using MakingWavesApp.Converters;
using MakingWavesApp.Renderers;

namespace MakingWavesApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var converter = new DateInputConverter(args);
            if (converter.DateFrom == null || converter.DateTo == null) return;
            
            var datePeriodRenderer = new DatePeriodRenderer();
            datePeriodRenderer.RenderPeriod(converter.DateFrom.Value, converter.DateTo.Value);
        }
    }
}