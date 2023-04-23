using AdvertService.BLL.DTOs.Advert;
using AdvertService.DAL.Entities;
using AutoMapper;


namespace AdvertService.BLL.MappingProfiles.AdvertProfiles
{
    public class AdvertCreateRedoProfile : Profile
    {
        public AdvertCreateRedoProfile()
        {
            CreateMap<Advert, AdvertCreateRedoDTO>();
            CreateMap<AdvertCreateRedoDTO, Advert>();
        }
    }
}
