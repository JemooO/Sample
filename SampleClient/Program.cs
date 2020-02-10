using SampleSDK;
using System;

namespace SampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var weather = WeatherManager.Get();
            foreach (var item in weather)
                Console.WriteLine($"{item.Summary}");


            Console.ReadLine();
        }
    }
}
