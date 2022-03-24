using System;
using System.Diagnostics;
using System.Timers;

namespace Perf.Counters
{
    public class StopWatchWrapper
    {

        private static Stopwatch timer;
        private static EventSourceMethodPerformance eventSourceMethodPerformance;

        public StopWatchWrapper()
        {
            timer = new Stopwatch();
            eventSourceMethodPerformance = new EventSourceMethodPerformance();
        }

        public static void StartWatch() => timer.Start();
        public static void StopWatch(string name)
        {
            timer.Stop();
            eventSourceMethodPerformance.Log(name, timer.ElapsedMilliseconds);
        }
    }
}
