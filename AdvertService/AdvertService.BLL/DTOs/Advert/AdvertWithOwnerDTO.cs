using AdvertService.BLL.DTOs.User;

namespace AdvertService.BLL.DTOs.Advert
{
    public class AdvertWithOwnerDTO : AdvertDTO
    {
        public UserDTO? owner { get; set; }
    }
}
