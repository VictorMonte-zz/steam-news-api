using System;
using System.Collections.Generic;
using System.Text;

namespace Top5GamesSteamNews.Domain.Entities
{
    public class News
    {
        public Game Game { get; set; }
        public IEnumerable<Article> Articles { get; set; }

        public News(Game game)
        {
            Game = game;
        }
    }
}
