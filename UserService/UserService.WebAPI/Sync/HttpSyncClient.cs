using Newtonsoft.Json;
using RequestService.BLL.DTO;

namespace UserService.WebAPI.Sync
{
    public class HttpSyncClient
    {
        public async Task<List<AdvertDTO>> GetAdvertsByOwnerIDAsync(string id)
        {
            using HttpClient client = new();
            var res = await client.GetAsync($"http://advert-service/api/adverts/owner-adverts/{id}");
            if (!res.IsSuccessStatusCode) return null;

            var jsonString = await res.Content.ReadAsStringAsync();

            List<AdvertDTO> adverts = JsonConvert.DeserializeObject<List<AdvertDTO>>(jsonString);
            return adverts;
        }
    }
}
