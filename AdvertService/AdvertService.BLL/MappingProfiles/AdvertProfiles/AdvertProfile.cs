using AdvertService.BLL.DTOs.Advert;
using AdvertService.DAL.Entities;
using AutoMapper;

namespace AdvertService.BLL.MappingProfiles.AdvertProfiles
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            CreateMap<Advert, AdvertDTO>();
            CreateMap<AdvertDTO, Advert>();
        }
    }
}
