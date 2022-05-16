using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpService.Controllers
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

        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet]
        [Route("event")]
        public async Task GetEvent(CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            httpContext.Response.ContentType = "text/event-stream; charset=utf-8";

            var data =
            $"id:{Guid.NewGuid().ToString("N")}\n" +
            $"retry:1000\n" +
            $"event:message\n" +
            $"data:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n";

            var bytes = Encoding.UTF8.GetBytes(data);

            await httpContext.Response.Body.WriteAsync(bytes);
            await httpContext.Response.Body.FlushAsync();

            using (var consumer = new BlockingCollection<string>())
            {
                var eventGeneratorTask = EventGeneratorAsync(consumer, cancellationToken);
                foreach (var @event in consumer.GetConsumingEnumerable(cancellationToken))
                {
                    var payload =
                       $"id:{Guid.NewGuid().ToString("N")}\n" +
                       $"retry:1000\n" +
                       $"event:message\n" +
                       $"data:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n";

                    bytes = Encoding.UTF8.GetBytes(payload);

                    await httpContext.Response.Body.WriteAsync(bytes);
                    await httpContext.Response.Body.FlushAsync(cancellationToken);
                }
                await eventGeneratorTask;
            }
        }

        private async Task EventGeneratorAsync(BlockingCollection<string> eventData, CancellationToken cacellationToken)
        {
            try
            {
                if (!cacellationToken.IsCancellationRequested)
                {
                    while (!eventData.IsCompleted)
                    {
                        var payload =
                         $"id:{Guid.NewGuid().ToString("N")}\n" +
                         $"retry:1000\n" +
                         $"event:message\n" +
                         $"data:{eventData}\n\n";

                        eventData.Add(payload);

                        await Task.Delay(1000, cacellationToken).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                eventData.CompleteAdding();
            }
        }





    }
}
