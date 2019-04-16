using Ozow.GameOfLife.Domain.DomainModel;
using Ozow.GameOfLife.Domain.DomainServices;

namespace Ozow.GameOfLife.Domain.Factories
{
    public interface IGameFactory
    {
        IGameOfLife CreateGame(IGameEventEmitter eventEmitter, int gridRowCount, int gridColCount);
    }

    public class GameFactory : IGameFactory
    {
        public IGameOfLife CreateGame(IGameEventEmitter eventEmitter, int gridRowCount, int gridColCount)
        {
            return new DomainModel.GameOfLife(eventEmitter, gridColCount, gridColCount);
        }
    }
}