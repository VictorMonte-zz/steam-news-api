using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Top5GamesSteamNews.Domain.Entities;
using Top5GamesSteamNews.Domain.Entities.Steam;
using Top5GamesSteamNews.Domain.Interfaces;

namespace Top5GamesSteamNews.Application.Services
{
    public class SteamNewsService : INewsService
    {
        private Endpoints _endpoints;
        private IGamesServices _gamesServices;

        public SteamNewsService(IOptions<Endpoints> endpoints, IGamesServices gamesService)
        {
            _endpoints = endpoints.Value;
            _gamesServices = gamesService;
        }

        public async Task<IEnumerable<SteamNews>> Get(int howManyArticles, int howManyGames)
        {
            return await Task.Run<IEnumerable<SteamNews>>(() =>
             {
                 var news = new List<SteamNews>();

                 _gamesServices.GetGamesIds(howManyGames)
                     .Result
                     .ToList()
                     .ForEach(id =>
                     {
                         var articles = GetArticlesFromGame(id, howManyArticles);
                         if (articles != null)
                         {
                             news.Add(articles);
                         }
                     });

                 return news;
             });
        }

        private SteamNews GetArticlesFromGame(string id, int howManyArticles)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(_endpoints.NewsByAppId, id, howManyArticles);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;
                var articles = JsonConvert.DeserializeObject<SteamNews>(result);

                return articles;
            }
        }
    }
}