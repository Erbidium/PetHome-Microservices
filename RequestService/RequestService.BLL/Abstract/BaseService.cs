using AutoMapper;
using RequestService.DAL.Interfaces;

namespace RequestService.BLL.Abstract
{
    public class BaseService
    {
        private protected readonly IRequestsRepository _requestRepository;
        private protected readonly IMapper _mapper;

        public BaseService(IRequestsRepository repo, IMapper mapper)
        {
            _requestRepository = repo;
            _mapper = mapper;
        }
    }
}