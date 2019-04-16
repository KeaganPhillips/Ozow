using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Ozow.GameOfLife.Web.Hubs.HubViewModels;

namespace Ozow.GameOfLife.Web.Hubs
{
    public class GameHub : Hub
    {
        public void StartGame(StartNewGameCommand message)
        {
            Clients.All.SendAsync("StartGameMsgReceived");
        }
    }
}