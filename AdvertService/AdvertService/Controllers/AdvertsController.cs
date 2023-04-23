using AdvertService.BLL.DTOs.Advert;
using AdvertService.BLL.DTOs.User;
using AdvertService.BLL.Services.Interfaces;
using AdvertService.Sync;
using Microsoft.AspNetCore.Mvc;

namespace AdvertService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly HttpSyncClient _syncClient;
        public AdvertsController(IAdvertService advertService, HttpSyncClient syncClient)
        {
            _advertService = advertService;
            _syncClient = syncClient;
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


        [HttpGet("with-owner/{id}")] //here
        public async Task<ActionResult<AdvertWithOwnerDTO>> GetWithOwner(int id)
        {
            AdvertWithOwnerDTO advertWithOwner = await _advertService.getAdvertById(id);

            UserDTO ownerDTO = await _syncClient.GetUserByUserIDAsync(Guid.Parse(advertWithOwner.ownerId));
            advertWithOwner.owner = ownerDTO;

            return Ok(advertWithOwner);
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
