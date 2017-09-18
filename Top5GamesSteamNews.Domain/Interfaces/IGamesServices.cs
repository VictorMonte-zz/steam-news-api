using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Top5GamesSteamNews.Domain.Interfaces
{
    public interface IGamesServices
    {
        Task<IEnumerable<string>> GetGamesIds(int range);
    }
}
