using Microsoft.AspNetCore.Mvc;

namespace BackendApi1.Controllers
{ 

    public class WeatherData
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public int Degree { get; set; }

        public string Location { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<WeatherData> weatherDatas = new()
        {
            new WeatherData() { Id = 1, Data = "21.01.2022", Degree = 10, Location = "Мурманск" },
            new WeatherData() { Id = 23, Data = "10.08.20219", Degree = 20, Location = "Пермь" },
            new WeatherData() { Id = 24, Data = "05.11.2020", Degree = 15, Location = "Омск" },
            new WeatherData() { Id = 25, Data = "07.02.2021", Degree = 0, Location = "Томск" },
            new WeatherData() { Id = 30, Data = "30.005.2022", Degree = 13, Location = "Калининград" },
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<WeatherData> Get()
        {
            return weatherDatas;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    return Ok(weatherDatas[i]);
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    return BadRequest("Запись с таким Id уже есть");
                }
            }
            weatherDatas.Add(data);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(WeatherData data)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    weatherDatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpGet("find-by-ciity")]

        public IActionResult GetByCityName(string location)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Location == location)
                {
                    return Ok(weatherDatas[i]);
                }
            }
            return BadRequest("Запись с указанным городом не обнаружена");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    weatherDatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }
    }     
}