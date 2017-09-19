using System.Collections.Generic;

namespace Top5GamesSteamNews.Application.DTO.Steam
{
    public class Appnews
    {
        public int Appid { get; set; }
        public List<Newsitem> Newsitems { get; set; }
        public int Count { get; set; }
    }
}
