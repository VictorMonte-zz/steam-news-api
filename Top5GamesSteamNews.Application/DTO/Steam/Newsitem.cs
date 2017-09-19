namespace Top5GamesSteamNews.Application.DTO.Steam
{
    public class Newsitem
    {
        public string Gid { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool Is_external_url { get; set; }
        public string Author { get; set; }
        public string Contents { get; set; }
        public string Feedlabel { get; set; }
        public int Date { get; set; }
        public string Feedname { get; set; }
        public int Feed_type { get; set; }
        public int Appid { get; set; }
    }
}
