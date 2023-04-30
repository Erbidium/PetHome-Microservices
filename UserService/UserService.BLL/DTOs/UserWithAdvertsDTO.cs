using RequestService.BLL.DTO;

namespace UserService.BLL.DTOs
{
    public class UserWithAdvertsDTO: UserDto
    {
        public List<AdvertDTO>? PublishedAdverts { get; set; }
    }
}
