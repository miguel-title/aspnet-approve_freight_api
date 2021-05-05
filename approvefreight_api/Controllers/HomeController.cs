using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Controllers
{
    [ApiController]
    [Route("v1/[controller]/get-totals")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<getTotalResponse> Get()
        {
            getTotalResponse responseData = new getTotalResponse();
            getTotal _totalData = new getTotal();
            _totalData.totalRedChannels = 1;
            _totalData.totalOcurrences = 2;
            _totalData.totalExpensivesShipping = 3;
            _totalData.totalRevalidations = 4;
            _totalData.totalUnsuccessfulCollection = 5;
            responseData.data = _totalData;
            return responseData;
        }
    }
}
