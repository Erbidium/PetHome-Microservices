using AdvertService.BLL.DTOs.Advert;
using AdvertService.DAL.Entities;
using AutoMapper;

namespace AdvertService.BLL.MappingProfiles.AdvertProfiles
{
    public class AdvertWithOwnerProfile: Profile
    {
        public AdvertWithOwnerProfile()
        {
            CreateMap<Advert, AdvertWithOwnerDTO>();
            CreateMap<AdvertWithOwnerDTO, Advert>();
        }
    }
}
