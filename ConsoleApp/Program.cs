using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.Write("\nPress any key to close this screen");
            Console.ReadKey();
        }

        public static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Sequencial awaits");
            var sw = new Stopwatch();
            sw.Start();
            var int1 = await WaitSeconds(2);
            var int2 = await WaitSeconds(5);
            sw.Stop();
            Console.WriteLine($"Completed and the returned values are {int1} and {int2}. Time lapse: {Math.Round(sw.ElapsedMilliseconds / 1000d, 2)} seconds");
            Console.WriteLine("\n Parallel awaits");
            sw.Reset();
            sw.Start();
            var int3 = WaitSeconds(2);
            var int4 = WaitSeconds(5);
            await int3;
            await int4;
            sw.Stop();
            Console.WriteLine($"Completed and the returned values are {int3.Result} and {int4.Result}. Time lapse: {Math.Round(sw.ElapsedMilliseconds / 1000d, 2)} seconds");
        }
        private static async Task<int> WaitSeconds(int numberOfSeconds)
        {
            Console.WriteLine($"Waiting {numberOfSeconds} seconds...");
            await Task.Delay(numberOfSeconds * 1000);
            Console.WriteLine("Time completed!");
            return numberOfSeconds;
        }

    }
}
