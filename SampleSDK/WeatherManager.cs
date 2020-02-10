using Abp.Threading;
using SampleSDK.Common;
using SampleSDK.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSDK
{
    public class WeatherManager
    {
        private WeatherManager()
        {

        }

        public static Weather[] Get()
        {
            using (var client = new ApiCaller())
            {
                var result = AsyncHelper.RunSync(() =>  client.GetAsync<Weather[]>("WeatherForecast", ""));
                return result;
            }
        }

        public Weather Get(DateTime date)
        {
            return new Weather();
        }
    }
}
