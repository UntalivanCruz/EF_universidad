using System.Net;
using Microsoft.AspNetCore.Mvc;
using universidades.Models;

namespace universidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class countryController: ControllerBase
    {
        IcountryService countryService;
        public countryController(IcountryService _countryService){
            countryService=_countryService;
        }

        [HttpPost]
        public IActionResult postCountry([FromBody] country newCountry){
            countryService.CreateAsync(newCountry);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(countryService.Get());
        }
    }
}