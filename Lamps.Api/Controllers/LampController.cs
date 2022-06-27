using Classes;
using Microsoft.AspNetCore.Mvc;
using Lamps.Infrastructure.Entities;

namespace Lamps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LampController : ControllerBase
    {
        private readonly ILampsService _lampsService;
        public LampController(ILampsService lampsService)
        {
            _lampsService = lampsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lamps = await _lampsService.GetLamp();
            return Ok(lamps);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll(string? search = null, int index = 0, int size = 10, string? sortBy = nameof(Lamp.Name), string? sortdir = "")
        {
            var lamps = await _lampsService.GetAllLamps(search, index, size, sortBy, sortdir);
            return Ok(lamps);
        }
        [HttpPost]
        public async Task<Lamp> Add(Lamp model)
        {
            return await _lampsService.AddLamp(model);
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _lampsService.DeleteLamp(id);
        }

        [HttpPut]
        public async Task<int> Update(Lamp model)
        {
            return await _lampsService.UpdateLamp(model);
        }
    }
}
