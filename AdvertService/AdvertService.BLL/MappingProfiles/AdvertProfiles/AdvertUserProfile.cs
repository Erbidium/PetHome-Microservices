using AdvertService.BLL.DTOs;
using AdvertService.DAL.Entities;
using AutoMapper;

namespace AdvertService.BLL.MappingProfiles.AdvertProfiles
{
    public class AdvertUserProfile : Profile
    {
        public AdvertUserProfile()
        {
            CreateMap<Advert, AdvertUserDTO>();
                //.ForMember(destination => destination.ifHaveAppliedRequests, opt => opt.MapFrom(source => source.requests.Any(el => el.status == DAL.Enums.RequestStatusEnum.applied)));
            CreateMap<AdvertUserDTO, Advert>();
        }
    }
}
