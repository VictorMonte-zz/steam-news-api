using System.Collections.Generic;
using System.Threading.Tasks;
using Top5GamesSteamNews.Domain.Entities.News;

namespace Top5GamesSteamNews.Domain.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<SteamNews>> Get(int howManyArticles, int howManyGames);
    }
}
