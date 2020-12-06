using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class CumulativeViewsRequest : IParameters
    {
        public double? Start { get; set; }
        public double? Due { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public int? Top { get; set; }

        public void ValidateParameters()
        {
            var isValid = true;
            if (Start.HasValue && Due.HasValue)
            {
                if (Start.Value > Due.Value)
                {

                    isValid = false;
                }
            }

            if (!isValid)
            {
                throw new ArgumentException("invalid request parameters");
            }
        }
    }
}
