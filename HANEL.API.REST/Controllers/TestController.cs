using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers
{
    public class City
    {
        public string CityName { get; set; }
        public int Latitude { get; set; }
        public int Longtitude { get; set; }

    }
    public class TestController : BaseController
    {
        [HttpGet("CitiesOnMap")]
        public IActionResult CitiesOnMap()
        {
            List<City> cities = new List<City>();

            cities.Add(new City { CityName = "Hatay", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Konya", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "İstanbul", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "İzmir", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Muğla", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Antalya", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Bursa", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Manisa", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Mersin", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Ankara", Latitude = 123, Longtitude = 435 });

            TempData["cities"] = cities;
            return Ok();
        }

        [HttpPost("CitiesOnMap")]
        public IActionResult CitiesOnMap(string SelectedCity)
        {
            List<City> cities = new List<City>();

            cities.Add(new City { CityName = "Hatay", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Konya", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "İstanbul", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "İzmir", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Muğla", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Antalya", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Bursa", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Manisa", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Mersin", Latitude = 123, Longtitude = 435 });
            cities.Add(new City { CityName = "Ankara", Latitude = 123, Longtitude = 435 });

            TempData["cities"] = cities;

            var res = TempData["cities"];
            foreach (var redirectedCity in TempData["cities"] as List<City>)
            {
                Console.WriteLine("bumbum");
                if (String.Equals(redirectedCity.CityName, SelectedCity))
                {
                    TempData["selectedCity"] = redirectedCity;
                    return RedirectToAction(redirectedCity.CityName, "City");
                }
            }
            return RedirectToAction(SelectedCity, "City"); ;
        }
    }
}
