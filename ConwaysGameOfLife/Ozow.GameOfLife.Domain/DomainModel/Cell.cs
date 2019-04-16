namespace Ozow.GameOfLife.Domain.DomainModel
{
    public interface ICell
    {
        bool IsAlive { get; }
    }

    public class Cell : ICell
    {
        public bool IsAlive { get; private set; }
    }
}