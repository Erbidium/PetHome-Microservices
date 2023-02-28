using Newtonsoft.Json;
using RequestService.DAL.Enums;
using Newtonsoft.Json.Converters;

namespace RequestService.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int AdvertId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestStatusEnum Status { get; set; }
    }
}