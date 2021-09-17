using System;

namespace WSVentas
{
    public class WeatherForecast
    {
        public WeatherForecast(int id, string nomnbre)
        {
            this.id = id;
            this.nomnbre = nomnbre;

        }
        public int id { get; set; }
        public string nomnbre { get; set; }


    }
}
