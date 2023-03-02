using AutoMapper;
using RequestService.BLL.DTO;
using RequestService.DAL.Entities;

namespace RequestService.BLL.MappingProfile
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<Request, RequestDTO>();
            CreateMap<RequestDTO, Request>();
        }
    }
}
