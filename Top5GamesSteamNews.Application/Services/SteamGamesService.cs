using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Top5GamesSteamNews.Domain.Entities.Configuration;
using Top5GamesSteamNews.Domain.Interfaces;
using System;
using Top5GamesSteamNews.Domain.Entities;
using Top5GamesSteamNews.Application.DTO.Spy;
using System.Linq;

namespace Top5GamesSteamNews.Application.Services
{
    public class SteamGamesService : IGamesService
    {
        private Endpoints _endpoints;

        public SteamGamesService(IOptions<Endpoints> endpoints)
        {
            _endpoints = endpoints.Value;
        }

        public IEnumerable<Game> Get(int howManyGames)
        {
            List<Game> games = new List<Game>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(_endpoints.Top100Games).Result;
                response.EnsureSuccessStatusCode();

                string conteudo = response.Content.ReadAsStringAsync().Result;
                var spyGames = JsonConvert.DeserializeObject<Dictionary<string, GameDto>>(conteudo);

                foreach (var game in spyGames.Take(howManyGames))
                {
                    games.Add(
                        new Game()
                        {
                            Id = game.Key,
                            Name = game.Value.Name
                        });
                }
            }

            return games;
        }
    }
}
