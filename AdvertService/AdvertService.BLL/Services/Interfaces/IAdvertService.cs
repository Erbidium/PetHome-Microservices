using AdvertService.BLL.DTOs.Advert;

namespace AdvertService.BLL.Services.Interfaces
{
    public interface IAdvertService
    {
        Task<List<AdvertDTO>> getAdverts();
        Task<AdvertWithOwnerDTO> getAdvertById(int advertId);
        Task<List<AdvertDTO>> getAdvertByOwnerId(string ownerId);
        Task addAdvert(AdvertCreateRedoDTO advertToAdd);
        Task MarkAsFinished(int advertId);
        Task deleteAdvert(int advertId);
        Task updateAdvert(AdvertCreateRedoDTO newData, int advertId);
    }
}