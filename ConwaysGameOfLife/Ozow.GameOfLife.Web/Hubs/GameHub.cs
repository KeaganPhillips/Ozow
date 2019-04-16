using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Ozow.GameOfLife.Domain.DomainModel;
using Ozow.GameOfLife.Domain.DomainServices;
using Ozow.GameOfLife.Domain.Factories;
using Ozow.GameOfLife.Web.Hubs.HubViewModels;

namespace Ozow.GameOfLife.Web.Hubs
{
    public class GameHub : Hub, IGameEventEmitter
    {
        #region Dependencies
        private readonly IGameFactory _gameFactory;
        #endregion

        public GameHub(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;            
        }

        public void NewGameStateEvent(IList<IList<ICell>> state)
        {

            Clients.All.SendAsync("UpdateGameState", state);
        }

        public void StartGame(StartNewGameCommand command)
        {
            Clients.All.SendAsync("StartGameMsgReceived");

            var game = _gameFactory.CreateGame(this, command.RowCount, command.ColumnCount);
        }
    }
}