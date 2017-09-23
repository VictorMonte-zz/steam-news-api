using System.Collections.Generic;
using System.Threading.Tasks;
using Top5GamesSteamNews.Domain.Entities;

namespace Top5GamesSteamNews.Domain.Interfaces
{
    public interface INewsService
    {
        IEnumerable<News> Get(int howManyArticles, int howManyGames);
    }
}
