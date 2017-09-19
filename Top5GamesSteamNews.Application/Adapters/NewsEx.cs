using System;
using System.Collections.Generic;
using System.Text;
using Top5GamesSteamNews.Application.DTO.Steam;
using Top5GamesSteamNews.Domain.Entities;

namespace Top5GamesSteamNews.Application.Adapters
{
    public static class SteamNewsEx
    {
        public static News ToNews(this SteamNews steamNews, Game game)
        {
            var news = new News(game);
            
            var articles = new List<Article>();
            foreach (var item in steamNews.Appnews.Newsitems)
            {
                articles.Add(
                    new Article()
                    {
                        Content = item.Contents,
                        Title = item.Title
                    });
            }
            news.Articles = articles;

            return news;
        }
    }
}
