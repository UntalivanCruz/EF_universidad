using System.Net;
using Microsoft.AspNetCore.Mvc;
using universidades.Models;

namespace universidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class countryController : ControllerBase
    {
        IcountryService countryService;
        public countryController(IcountryService _countryService)
        {
            countryService = _countryService;
        }

        [HttpPost]
        public async Task<IActionResult> postCountry([FromBody] country newCountry)
        {
            await countryService.CreateAsync(newCountry);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(countryService.Get());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] country updCountry)
        {
            await countryService.Update(id, updCountry);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await countryService.Delete(id);
            return Ok();
        }
    }
}