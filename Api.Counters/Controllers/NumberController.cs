using Microsoft.AspNetCore.Mvc;
using Perf.Counters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Counters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {

        [HttpGet("{maxNumber}")]
        public async Task<IEnumerable<int>> Get(int maxNumber) 
        {
            var x = 0;
            while(x < maxNumber)
            {
                StopWatchWrapper.StartWatch();
                await Await();
                StopWatchWrapper.StopWatch("Await");
                x++;
                
            }

            return Enumerable.Range(0, maxNumber).ToList(); ;
        }

        private async Task Await()
        {
            await Task.Delay(1000);
        }
    }
}
