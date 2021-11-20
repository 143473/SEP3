using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookAndPlaySOAP;


namespace BusinessLayer.Data
{
    public interface IGameWebService
    {
        Task<Game> GetGameAsync(int id);
        Task AddGameAsync(Game game);
        Task<IList<Game>> GetGamesAsync();
        Task<IList<Game>> GetUserGamesAsync(string user);
        Task RemoveGameAsync(int id);
        Task EditGameAsync(Game game);
    }
}