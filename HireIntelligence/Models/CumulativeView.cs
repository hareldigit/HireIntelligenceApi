using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireIntelligence.Models
{
    public class CumulativeView
    {
        public DateTime PublishedAt { get; set; }
        public int ActuallyDailyViews { get; set; }
        public int PredictedDailyViews { get; set; }
        public int ActiveJobs { get; set; }
    }
}
