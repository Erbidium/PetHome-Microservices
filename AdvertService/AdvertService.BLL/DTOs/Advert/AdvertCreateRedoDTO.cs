namespace AdvertService.BLL.DTOs.Advert
{
    public class AdvertCreateRedoDTO
    {
        public string name { get; set; }
        public string description { get; set; } = string.Empty;
        public int cost { get; set; }
        public string location { get; set; } = string.Empty;
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
