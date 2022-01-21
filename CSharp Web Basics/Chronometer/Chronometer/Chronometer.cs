﻿namespace ChronometerAsync
{
    using System.Diagnostics;

    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private List<string> laps;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => this.stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => this.Laps;

        public string Lap()
        {
            var lap = GetTime;
            this.laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            this.stopwatch.Reset();
            this.laps = new List<string>();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}
