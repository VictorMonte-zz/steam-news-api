using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Top5GamesSteamNews.Domain.Entities.Steam;
using Top5GamesSteamNews.Domain.Interfaces;

namespace Top5GamesSteamNews.Application.Services
{
    public class SteamGamesService : IGamesServices
    {
        private Endpoints _endpoints;

        public SteamGamesService(IOptions<Endpoints> endpoints)
        {
            _endpoints = endpoints.Value;
        }

        public async Task<IEnumerable<string>> GetGamesIds(int range)
        {
            return await Task.Run<IEnumerable<string>>(() =>
             {
                 List<string> ids = new List<string>();

                 using (var client = new HttpClient())
                 {
                     client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                     HttpResponseMessage response = client.GetAsync(_endpoints.Top100Games).Result;
                     response.EnsureSuccessStatusCode();

                     string conteudo = response.Content.ReadAsStringAsync().Result;
                     var games = JsonConvert.DeserializeObject<Dictionary<string, Game>>(conteudo);

                     ids = games.Keys.Take(range).ToList();
                 }

                 return ids;
             });
        }
    }
}
