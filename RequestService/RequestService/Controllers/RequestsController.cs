using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestService.BLL.DTO;
using RequestService.BLL.Interfaces;
using RequestService.Attributes;

namespace RequestService.Controllers
{
    [UserId]
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] int advertId)
        {
            RequestDTO requestDTO = await _requestService.AddRequest(UserId, advertId, DAL.Enums.RequestStatusEnum.applied);
            return Ok();
        }

        [HttpPut("confirm/{id}")]
        public async Task<IActionResult> ConfirmRequest(int id)
        {
            var requestsToRejectAndConfirmedRequest = await _requestService.ConfirmRequest(id, UserId);
            return Ok();
        }

        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            RequestDTO requestDTO = await _requestService.RejectRequest(id, UserId);
            return Ok();
        }

        [HttpPut("apply/{id}")]
        public async Task<IActionResult> applyGeneratedRequest(int id)
        {
            RequestDTO requestDTO = await _requestService.ApplyGeneratedRequest(id, UserId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteRequest(int id)
        {
            RequestDTO requestDTO = await _requestService.DeleteRequest(id, UserId);
            return Ok();
        }
    }
}
