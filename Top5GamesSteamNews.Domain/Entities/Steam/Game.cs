namespace Top5GamesSteamNews.Domain.Entities.Steam
{
    public class Game
    {
        public int? Appid { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public int? Score_rank { get; set; }
        public int? Owners { get; set; }
        public int? Owners_variance { get; set; }
        public int? Players_forever { get; set; }
        public int? Players_forever_variance { get; set; }
        public int? Players_2weeks { get; set; }
        public int? Players_2weeks_variance { get; set; }
        public int? Average_forever { get; set; }
        public int? Average_2weeks { get; set; }
        public int? Median_forever { get; set; }
        public int? Median_2weeks { get; set; }
        public int? Ccu { get; set; }
        public string Price { get; set; }
    }
}
