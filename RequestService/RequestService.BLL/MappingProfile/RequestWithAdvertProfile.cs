using AutoMapper;
using RequestService.BLL.DTO;
using RequestService.DAL.Entities;

namespace RequestService.BLL.MappingProfile
{
    public class RequestWithAdvertProfile : Profile
    {
        public RequestWithAdvertProfile()
        {
            CreateMap<Request, RequestWithAdvertDto>();
            CreateMap<RequestWithAdvertDto, Request>();
        }
    }
}
