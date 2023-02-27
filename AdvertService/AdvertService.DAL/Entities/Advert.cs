using AdvertService.DAL.Enums;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdvertService.DAL.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public int cost { get; set; }
        public string location { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AdvertStatusEnum status { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string ownerId { get; set; } = string.Empty;
        public string? performerId { get; set; }
        public List<AdvertToRequests> advertToRequest { get; set; }
    }
}
