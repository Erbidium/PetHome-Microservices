﻿using AdvertService.DAL.Entities;
using AdvertService.DAL.Enums;
using System.Text.Json.Serialization;

namespace AdvertService.BLL.DTOs
{
    public class AdvertUserDTO
    {
        public int id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AdvertStatusEnum status { get; set; }
        public string? ownerId { get; set; }
        public string name { get; set; }
        public string description { get; set; } = string.Empty;
        public int cost { get; set; }
        public string location { get; set; } = string.Empty;
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public List<AdvertToRequests> advertToRequest { get; set; }
        //public bool ifHaveAppliedRequests { get; set; }
        public string? performerId { get; set; }
    }
}
