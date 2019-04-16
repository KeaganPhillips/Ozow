using System.Collections.Generic;

namespace Ozow.GameOfLife.Domain.DomainModel
{
    public interface IGameOfLife
    {
        int RowCount { get; }
        int ColCount { get; }        

        IList<IList<Cell>> GameHistory { get; }
        IList<Cell> GameState { get; }

        void StartGame();
        void NextGen();
    }

    public class GameOfLife : IGameOfLife
    {
        #region public Properties
        public int RowCount { get; private set; }
        public int ColCount { get; private set; }        
        public IList<IList<Cell>> GameHistory => throw new System.NotImplementedException();
        public IList<Cell> GameState => throw new System.NotImplementedException();
        #endregion

        #region Constructor
        public GameOfLife(int rowCount, int columnCount)
        {            
            this.RowCount = rowCount;
            this.ColCount = columnCount;
        }
        #endregion

        #region Public Methods
        public void NextGen()
        {
            throw new System.NotImplementedException();
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}