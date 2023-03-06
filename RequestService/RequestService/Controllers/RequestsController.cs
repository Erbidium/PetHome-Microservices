using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestService.BLL.DTO;
using RequestService.BLL.Interfaces;
using RequestService.Attributes;

namespace RequestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsService _requestService;
        public string UserId { get; set; } = "userID"; //TEMP: HARD CODE

        public RequestsController(IRequestsService requestService)
        {
            _requestService = requestService;
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

        [HttpPost]
        public async Task<IActionResult> Post(int advertId)
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
