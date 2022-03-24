using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Perf.Counters
{
    [EventSource(Name = "Demo.EventSource")]
    public class EventSourceMethodPerformance : EventSource
    {
        private EventCounter _counter;
        private EventCounter _countCounter;
        private int eventCounter = 0;

        public EventSourceMethodPerformance()
        {
            _counter = new EventCounter("request-time",this)
            {
                DisplayName = "ElapesTime",
                DisplayUnits = "Ms"
            };

            _countCounter = new EventCounter("executed-times", this)
            {
                DisplayName = "Executed Time",
                DisplayUnits = "Times"
            };
        }

        public void Log(string nameMethod, float elapsedTime) {
            Interlocked.Increment(ref eventCounter);

            WriteEvent(1, nameMethod, elapsedTime);

            _countCounter.WriteMetric(eventCounter);
            _counter.WriteMetric(elapsedTime);
        }

        protected override void Dispose(bool disposing)
        {
            _counter?.Dispose();
            _counter = null;
            base.Dispose(disposing);
        }
    }
}
