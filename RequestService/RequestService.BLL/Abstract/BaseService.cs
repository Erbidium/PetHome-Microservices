using AutoMapper;
using RequestService.DAL.Interfaces;

namespace RequestService.BLL.Abstract
{
    public class BaseService
    {
        private protected readonly IRequestRepository _requestRepository;
        private protected readonly IMapper _mapper;

        public BaseService(IRequestRepository repo, IMapper mapper)
        {
            _requestRepository = repo;
            _mapper = mapper;
        }
    }
}