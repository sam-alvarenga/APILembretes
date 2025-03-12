using Microsoft.AspNetCore.Mvc;

namespace PrjAPILembretes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public WeatherForecast Get()
        {
            //modificador | tipo retorno | nome do metodo | parametros
            WeatherForecast previsaoTempo = new WeatherForecast();
            previsaoTempo.Date = new DateOnly(2025,02,17);
            previsaoTempo.TemperatureC = 32;
            previsaoTempo.Summary = "Escaldante";
            return previsaoTempo;
            //.ToArray();
        }
        [HttpGet("versao")]//nome exposto da rota (vai para internet)
        public string GetVersao() //nome interno
        {
            return "API Weather Forecast - versão 1.0";
        }


        [HttpGet("hello/{name}")]
        public string GetSaudacao(string name) 
        {
            return "Hello, "+name;
        }

    }
}