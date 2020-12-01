using System;

namespace Contracts
{
    public class CumulativeView
    {
        public DateTime PublishedAt { get; set; }
        public int ActuallyDailyViews { get; set; }
        public int PredictedDailyViews { get; set; }
        public int ActiveJobs { get; set; }
    }
}
