using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class CumulativeViewsParameters
	{
        public DateTime? StartTime { get; set; }
        public DateTime? DueTime { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public int? Top { get; set; }
    }
}
