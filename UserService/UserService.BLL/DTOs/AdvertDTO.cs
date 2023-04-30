using UserService.DAL.Enums;
using System.Text.Json.Serialization;

namespace RequestService.BLL.DTO
{
    public class AdvertDTO
    {
        public int id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AdvertStatusEnum status { get; set; }
        public string? photoFilePath { get; set; } = string.Empty;
        public string? ownerId { get; set; }
        public string name { get; set; }
        public string description { get; set; } = string.Empty;
        public int cost { get; set; }
        public string location { get; set; } = string.Empty;
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
