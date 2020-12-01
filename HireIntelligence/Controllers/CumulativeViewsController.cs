using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Contracts;
using System;

namespace HireIntelligence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CumulativeViewsController :ControllerBase
    {

        private readonly ILogger<CumulativeViewsController> _logger;
        private readonly IStorageManager m_storagManager;

        public CumulativeViewsController (IStorageManager storagManager, ILogger<CumulativeViewsController > logger)
        {
            _logger = logger;
            m_storagManager = storagManager;
        }



        [HttpGet]
        public IEnumerable<CumulativeView> Get()
        {
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                var response = default(IEnumerable<CumulativeView>);
                var parameters = new CumulativeViewsParameters();
                response = m_storagManager.GetCumulativeViews(parameters);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred: {ex.Message}");
                throw;
            }
            finally
            {
                watch.Stop();
                _logger.LogInformation($"Requset Time: {watch.ElapsedMilliseconds}");
            }
            
        }
    }
}
