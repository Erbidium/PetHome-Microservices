using AdvertService.BLL.DTOs.User;
using System.Text.Json;

namespace AdvertService.Sync
{
    public class HttpSyncClient
    {
        public async Task<UserDTO> GetUserByUserIDAsync(Guid id)
        {
            using HttpClient client = new();
            var res = await client.GetAsync($"http://user-service/api/{id}");
            if (!res.IsSuccessStatusCode) return null;

            var jsonString = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<UserDTO>(jsonString);
        }
    }
}
