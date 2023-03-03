using RequestService.BLL.DTO;
using RequestService.DAL.Enums;

namespace RequestService.BLL.Interfaces
{
    public interface IRequestsService
    {
        Task<RequestDTO> AddRequest(string userId, int advertId, RequestStatusEnum status);
        Task<(List<RequestDTO> requestsToRejectDTO, RequestDTO requestDTO)> ConfirmRequest(int requestId, string userId);
        Task<RequestDTO> ApplyGeneratedRequest(int requestId, string userId);
        Task<RequestDTO> DeleteRequest(int requestId, string userId);
        Task<RequestDTO> RejectRequest(int requestId, string userId);
    }
}