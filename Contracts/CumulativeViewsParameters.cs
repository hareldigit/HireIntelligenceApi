﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class CumulativeViewsParameters: IParameters
    {
        public DateTime? StartTime { get; set; }
        public DateTime? DueTime { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public int? Top { get; set; }

        public void ValidateParameters()
        {
            var isValid = true;
            if (StartTime.HasValue && DueTime.HasValue)
            {
                if (StartTime.Value > DueTime.Value)
                {

                    isValid = false;
                }
            }

            if (!isValid)
            {
                throw new ArgumentException("invalid parameters");
            }
        }
    }
}
