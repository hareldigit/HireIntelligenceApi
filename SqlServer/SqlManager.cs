using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SqlServer
{
    public class SqlManager : IStorageManager
    {
        private readonly IStorageEngine m_storageEngine;
        public SqlManager(IStorageEngine storageEngine)
        {
            m_storageEngine = storageEngine;
        }

        public IEnumerable<CumulativeView> Map(DataTable dataTable)
        {
            var result = default(IEnumerable<CumulativeView>);
            if (dataTable.Rows.Count > 0)
            {
                result = (from rw in dataTable.AsEnumerable()
                              select new CumulativeView
                              {
                                  ActiveJobs = Convert.ToInt32(rw["ActiveJobs"]),
                                  ActuallyDailyViews = Convert.ToInt32(rw["ActuallyJobViews"]),
                                  PredictedDailyViews = Convert.ToInt32(rw["PredictedJobViews"]),
                                  PublishedAt = Convert.ToDateTime(rw["PublishedAt"])
                              }).ToList();
            }
            return result;
        }

        public IEnumerable<CumulativeView> GetCumulativeViews(CumulativeViewsParameters parameters)
        {
            var dt = m_storageEngine.GetCumulativeViews(parameters);
            var result = Map(dt);
            return result;
        }
    }
}
