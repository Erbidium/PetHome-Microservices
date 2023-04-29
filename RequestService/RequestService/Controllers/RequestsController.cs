using AdvertService.Sync;
using RequestService.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using RequestService.BLL.Interfaces;

namespace RequestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsService _requestService;
        private readonly HttpSyncClient _syncClient;
        public string UserId { get; set; } = "userID"; //TEMP: HARD CODE

        public RequestsController(IRequestsService requestService, HttpSyncClient syncClient)
        {
            _requestService = requestService;
            _syncClient = syncClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _requestService.GetAll());
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _requestService.GetById(id));
        }

        [HttpGet("with-owner/{id}")]
        public async Task<ActionResult<RequestWithAdvertDto>> GetWithAdvert(int id)
        {
            RequestDTO requestDto = await _requestService.GetById(id);
            AdvertDTO advertDto = await _syncClient.GetAdvertByAdvertIDAsync(requestDto.AdvertId);
            RequestWithAdvertDto requestWithAdvert = new()
            {
                Id = requestDto.Id,
                UserId = requestDto.UserId,
                AdvertId = requestDto.AdvertId,
                Status = requestDto.Status,
                Advert = advertDto
            };
            return Ok(requestWithAdvert);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]int advertId)
        {
            return Ok(await _requestService.AddRequest(UserId, advertId, DAL.Enums.RequestStatusEnum.applied));
        }

        [HttpPut("confirm/{id}")]
        public async Task<IActionResult> ConfirmRequest(int id)
        {
            return Ok(await _requestService.ConfirmRequest(id, UserId));
        }

        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            return Ok(await _requestService.RejectRequest(id, UserId));
        }

        [HttpPut("apply/{id}")]
        public async Task<IActionResult> applyGeneratedRequest(int id)
        {
            return Ok(await _requestService.ApplyGeneratedRequest(id, UserId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteRequest(int id)
        {
            return Ok(await _requestService.DeleteRequest(id, UserId));
        }
    }
}
