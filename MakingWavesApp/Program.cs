using System;
using System.Globalization;
using System.Linq;

namespace MakingWavesApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong arguments count.");
                return;
            }

            var dateFrom = DateTime.ParseExact(args.First(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var dateTo = DateTime.ParseExact(args.Last(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Console.ReadKey();
        }
    }
}