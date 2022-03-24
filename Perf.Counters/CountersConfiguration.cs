using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perf.Counters
{
    public static class CountersConfiguration
    {
        public static void ConfigureCounters(this IServiceCollection service)
        {
            service.AddSingleton(new StopWatchWrapper());
        }
    }
}
