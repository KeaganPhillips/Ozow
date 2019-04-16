using Ozow.GameOfLife.Domain.DomainModel;

namespace Ozow.GameOfLife.Domain.Factories
{
    public interface IGameFactory
    {
        IGameOfLife CreateGame(int gridRowCount, int gridColCount);
    }

    public class GameFactory : IGameFactory
    {
        public IGameOfLife CreateGame(int gridRowCount, int gridColCount)
        {
            return new DomainModel.GameOfLife(gridColCount, gridColCount);
        }
    }
}