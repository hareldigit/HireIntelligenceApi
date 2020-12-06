using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Contracts;
using System;
using Microsoft.AspNetCore.Cors;
using HireIntelligenceService.ExtensionMethods;
using Microsoft.Extensions.Configuration;

namespace HireIntelligence.Controllers
{
    [ApiController]
    [EnableCors("HireIntelligenceAppPolicy")]
    [Route("api/[controller]")]
    public class CumulativeViewsController :ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly ILogger<CumulativeViewsController> _logger;
        private readonly IStorageManager m_storagManager;

        public CumulativeViewsController (IStorageManager storagManager, ILogger<CumulativeViewsController > logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
            m_storagManager = storagManager;
        }



        [HttpPost,Route("Get")]
        public IEnumerable<CumulativeView> Get(CumulativeViewsRequest request)
        {
            request.ValidateParameters();
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                var parameters = MapParameters(request);
                var response = m_storagManager.GetCumulativeViews(parameters);
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

        private CumulativeViewsParameters MapParameters(CumulativeViewsRequest request)
        {
            var parameters = new CumulativeViewsParameters();
            var startTime = request.Start;
            var dueTime = request.Due;
            if (startTime.HasValue)
            {
                parameters.StartTime = startTime.Value.UnixTimeStampToDateTime().StartOfDay();
            }
            if (dueTime.HasValue)
            {
                parameters.DueTime = dueTime.Value.UnixTimeStampToDateTime().EndOfDay();
            }
            return parameters;
        }
    }
}
