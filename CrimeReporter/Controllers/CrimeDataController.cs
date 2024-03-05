using CrimeReporter.Model;
using CrimeReporter.Services;
using CrimeReporter.Services.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CrimeReporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrimeDataController : ControllerBase
    {
        private readonly ILogger<CrimeDataController> _logger;
        protected ApiResponse _response = new ApiResponse();

        public CrimeDataController(ILogger<CrimeDataController> logger, ICrimeDataService crimeDataService)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "CrimeData/{month}/{latitude}/{longitude}")]
        [HttpGet]
        public async Task<IActionResult> Get(int month, double latitude, double longitude)
        {

            try
            {
                var response = await ServiceManager.CrimeDataService.Get(new Model.Query.CrimeDataQuery
                {
                    Lat = latitude,
                    Long = longitude,
                    Month = month
                });
                if (response == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Something Went Wrong";
                    return BadRequest(_response);
                }
                _response.IsSuccess = true;
                _response.Result = response;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
