using AutoMapper;
using RequestService.BLL.DTO;
using RequestService.DAL.Entities;
using RequestService.BLL.Abstract;
using RequestService.BLL.Interfaces;
using RequestService.DAL.Interfaces;

namespace RequestService.BLL.Services
{
    public class RequestsService : BaseService, IRequestsService
    {
        public RequestsService(IRequestsRepository requestRepository, IMapper mapper) : base(requestRepository, mapper) { }

        public async Task<RequestDTO> GetById(int id)
        {
            Request request = await _requestRepository.GetById(id) ?? throw new KeyNotFoundException("Request not found.");
            return _mapper.Map<RequestDTO>(request);
        }

        public async Task<ICollection<RequestDTO>> GetAll()
        {
            List<Request> requests = await _requestRepository.GetAll();
            return requests.Select(r => _mapper.Map<RequestDTO>(r)).ToList();
        }

        public async Task<RequestDTO> AddRequest(string userId, int advertId, DAL.Enums.RequestStatusEnum status)
        {
            //AFTER: check is user or adverb exists at all
            //AFTER: check is user id is the same as adverb owner (then error)

            List<Request> requestToAdvert = await _requestRepository.GetByAdvertId(advertId);
            if (requestToAdvert.Any(r => r.UserId == userId)) throw new ArgumentException("User already added request to this advert");

            Request newRequest = new()
            {
                UserId = userId,
                AdvertId = advertId,
                Status = status
            };

            await _requestRepository.Add(newRequest);
            await _requestRepository.SaveChangesAsync();

            return _mapper.Map<RequestDTO>(newRequest);
        }

        public async Task<(List<RequestDTO> requestsToRejectDTO, RequestDTO requestDTO)> ConfirmRequest(int requestId, string userId)
        {
            Request request = await _requestRepository.GetById(requestId) ?? throw new KeyNotFoundException("Request not found.");
            //AFTER: check is user id is the same as adverb owner (if not, then error)

            //AFTER: change advert status and performer id
            request.Status = DAL.Enums.RequestStatusEnum.confirmed;

            List<Request> requestsToReject = await _requestRepository.GetByAdvertId(request.AdvertId);
            requestsToReject.RemoveAll(r => r.UserId == userId);
            requestsToReject.ForEach(r =>
            {
                r.Status = DAL.Enums.RequestStatusEnum.rejected;
                _requestRepository.Update(r);
            });

            await _requestRepository.SaveChangesAsync();

            RequestDTO requestDTO = _mapper.Map<RequestDTO>(request);
            List<RequestDTO> requestsToRejectDTO = _mapper.Map<List<RequestDTO>>(requestsToReject);
            return (requestsToRejectDTO, requestDTO);
        }

        public async Task<RequestDTO> ApplyGeneratedRequest(int requestId, string userId)
        {
            Request request = await _requestRepository.GetById(requestId) ?? throw new KeyNotFoundException("Request not found");
            if (request.UserId != userId) throw new ArgumentException("You do not have the access.");

            request.Status = DAL.Enums.RequestStatusEnum.applied;
            _requestRepository.Update(request);

            await _requestRepository.SaveChangesAsync();

            return _mapper.Map<RequestDTO>(request);
        }

        public async Task<RequestDTO> DeleteRequest(int requestId, string userId)
        {
            Request request = await _requestRepository.GetById(requestId) ?? throw new KeyNotFoundException("Request not found");
            if (request.UserId != userId) throw new ArgumentException("You do not have the access.");

            _requestRepository.Delete(request);
            await _requestRepository.SaveChangesAsync();

            return _mapper.Map<RequestDTO>(request);
        }

        public async Task<RequestDTO> RejectRequest(int requestId, string userId)
        {
            Request request = await _requestRepository.GetById(requestId) ?? throw new KeyNotFoundException("Request not found");
            //AFTER: check is user id is the same as adverb owner (if not, then error)

            request.Status = DAL.Enums.RequestStatusEnum.rejected;
            _requestRepository.Update(request);

            await _requestRepository.SaveChangesAsync();

            return _mapper.Map<RequestDTO>(request);
        }
    }
}
