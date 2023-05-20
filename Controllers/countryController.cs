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

         [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] country updCountry){
            countryService.Update(id,updCountry);
            return Ok();
        }

         [HttpDelete("{id}")]
         public IActionResult Delete(Guid id){
            countryService.Delete(id);
            return Ok();
         }
    }
}