using AutoMapper;
using RequestService.BLL.DTO;
using RequestService.DAL.Entities;

namespace RequestService.BLL.MappingProfile
{
    public class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            CreateMap<Request, RequestDTO>();
            CreateMap<RequestDTO, Request>();
        }
    }
}
