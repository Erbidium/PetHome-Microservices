using RequestService.DAL.Enums;
using System.Text.Json.Serialization;

namespace RequestService.BLL.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int AdvertId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.applied;
    }
}