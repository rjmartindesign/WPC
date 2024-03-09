using CrimeReporter.Model;
using CrimeReporter.Model.Query;
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
        private readonly ICrimeDataService _crimeDataService;
        private readonly ApiResponse _response = new ApiResponse();

        // Inject the ICrimeDataService through the constructor
        public CrimeDataController(ICrimeDataService crimeDataService)
        {
            _crimeDataService = crimeDataService ?? throw new ArgumentNullException(nameof(crimeDataService));
        }

        [HttpGet(Name = "CrimeData/{month}/{latitude}/{longitude}")]
        public async Task<IActionResult> Get([FromQuery] int month, [FromQuery] double latitude, [FromQuery] double longitude)
        {
            try
            {
                if (!IsValidLatitude(latitude) || !IsValidLongitude(longitude) || !IsValidMonth(month))
                {
                    _response.IsSuccess = false;
                    _response.Message = "Invalid data";
                    return BadRequest(_response);
                }

                var response = await _crimeDataService.Get(new CrimeDataQuery
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
                // Log the exception or handle it in a way appropriate for your application
                return BadRequest(new ApiResponse { IsSuccess = false, Message = ex.Message, Result = null });
            }
        }

        private static bool IsValidMonth(int month)
        {
            return month >= 0 && month <= 11;
        }

        private static bool IsValidLatitude(double latitude)
        {
            // Validate latitude range for the UK
            return latitude >= 49.5 && latitude <= 61.0;
        }

        private static bool IsValidLongitude(double longitude)
        {
            // Validate longitude range for the UK
            return longitude >= -7.5 && longitude <= 1.8;
        }
    }
}
