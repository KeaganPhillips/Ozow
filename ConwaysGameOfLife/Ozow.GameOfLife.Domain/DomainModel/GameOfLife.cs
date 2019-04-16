using System;
using System.Collections.Generic;
using Ozow.GameOfLife.Domain.DomainServices;

namespace Ozow.GameOfLife.Domain.DomainModel
{
    public interface IGameOfLife
    {
        int RowCount { get; }
        int ColCount { get; }        
        
        IList<IList<ICell>> GameState { get; }

        void StartGame();
        void NextGen();
    }

    public class GameOfLife : IGameOfLife
    {
        #region Dependencies
        private readonly IGameEventEmitter _eventEmitter;
        #endregion

        #region public Properties
        public int RowCount { get; private set; }
        public int ColCount { get; private set; }                
        public IList<IList<ICell>> GameState { get; private set; }        
        #endregion

        #region Constructor
        public GameOfLife(IGameEventEmitter eventEmitter, int rowCount, int columnCount)
        {
            _eventEmitter = eventEmitter;

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
            this.GameState = _crateInitGameState();  
            _eventEmitter.NewGameStateEvent(this.GameState);
        }
        #endregion

        #region Private Methods
        private IList<IList<ICell>> _crateInitGameState()
        {
            var mailList  = new List<IList<ICell>>();

            // Crate Grid
            for(var r = 0; r < this.RowCount; r++){
                var rowList = new List<ICell>();
                for(var c = 0; c < this.ColCount; c++)
                    rowList.Add(new Cell());
                mailList.Add(rowList);
            }

            return mailList;
        }
        #endregion
    }
}