using RequestService.BLL.DTO;
using System.Text.Json;

namespace AdvertService.Sync
{
    public class HttpSyncClient
    {
        public async Task<AdvertDTO> GetAdvertByAdvertIDAsync(int id)
        {
            using HttpClient client = new();
            var res = await client.GetAsync($"http://advert-service/api/adverts/{id}");
            if (!res.IsSuccessStatusCode) return null;

            var jsonString = await res.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<AdvertDTO>(jsonString, options);
        }
    }
}