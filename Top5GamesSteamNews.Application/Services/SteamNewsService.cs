using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Top5GamesSteamNews.Application.DTO.Steam;
using Top5GamesSteamNews.Domain.Entities;
using Top5GamesSteamNews.Domain.Entities.Configuration;
using Top5GamesSteamNews.Domain.Interfaces;
using Top5GamesSteamNews.Application.Adapters;

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

        public async Task<IEnumerable<News>> Get(int howManyArticles, int howManyGames)
        {
            return await Task.Run<IEnumerable<News>>(async () =>
             {
                 var list = new List<News>();

                 var games = await _gamesServices.Get(howManyGames);

                 foreach (var game in games)
                 {
                     var news = GetNewsForGame(game, howManyArticles);                     
                     list.Add(news);
                 }

                 return list;
             });
        }

        private News GetNewsForGame(Game game, int howManyArticles)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(_endpoints.NewsByAppId, game.Id, howManyArticles);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;
                var steamNews = JsonConvert.DeserializeObject<SteamNews>(result);

                return steamNews.ToNews(game);
            }
        }
    }
}