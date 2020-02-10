using System;

namespace SampleSDK.Entities
{
    /// <summary>
    /// Sample entity for testing.
    /// </summary>
    public class Weather
    {
        public DateTime Date { get; set; }

        public float TemperatureC { get; set; }

        public float TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}
