using AdvertService.BLL.DTOs;
using AdvertService.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        public AdvertsController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvertDTO>>> GetAdverts()
        {
            var adverts = await _advertService.getAdverts();
            return Ok(adverts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertDTO>> Get(int id)
        {
            return Ok(await _advertService.getAdvertById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] AdvertCreateRedoDTO advertToAdd)
        {
            await _advertService.addAdvert(advertToAdd);
            return Ok();
        }

        [HttpPut("finish/{advertId}")]
        public async Task<ActionResult> MarkAsFinished(int advertId)
        {
            await _advertService.MarkAsFinished(advertId);
            return Ok();
        }

        [HttpDelete("{advertId}")]
        public async Task<ActionResult> deleteAdvert(int advertId)
        {
            await _advertService.deleteAdvert(advertId);
            return Ok();
        }
        [HttpPut("{advertId}")]
        public async Task<ActionResult> UpdateAdvert([FromForm] AdvertCreateRedoDTO data,int advertId)
        {
            await _advertService.updateAdvert(data, advertId);
            return Ok();
        }
    }
}
