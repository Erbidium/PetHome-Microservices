using AdvertService.BLL.DTOs;

namespace AdvertService.BLL.Services.Interfaces
{
    public interface IAdvertService
    {
        Task<List<AdvertDTO>> getAdverts();
        Task<AdvertDTO> getAdvertById(int advertId);
        Task addAdvert(AdvertCreateRedoDTO advertToAdd);
        Task MarkAsFinished(int advertId);
        Task deleteAdvert(int advertId);
        Task updateAdvert(AdvertCreateRedoDTO newData, int advertId);
    }
}