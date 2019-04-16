using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Ozow.GameOfLife.Domain.DomainModel;
using Ozow.GameOfLife.Domain.DomainServices;
using Ozow.GameOfLife.Tests.Builders;

namespace Tests.UnitTests
{
    public class GameOfLifeTests
    {
        #region Constructor Tests
        [Test]
        public void Ctor_RowColCountCorrect()
        {
            // Arrange
            var rows = Faker.RandomNumber.Next(2, 10);
            var cols = Faker.RandomNumber.Next(2, 10);

            // Act
            var sut = _createSubjectUnderTest(rows, cols);

            // Assert
            Assert.AreEqual(rows, sut.RowCount);
            Assert.AreEqual(cols, sut.ColCount);
        }
        #endregion

        #region Method: StartGame()  Tests
        [Test]
        public void StartGame_CorrectNumberOfRows()
        {
            // Arrange
            var rows = Faker.RandomNumber.Next(2, 10);
            var cols = Faker.RandomNumber.Next(2, 10);

            // Act
            var sut = _createSubjectUnderTest(rows, cols);
            sut.StartGame();

            // Assert
            Assert.AreEqual(rows, sut.GameState.Count); 
        }

        [Test]
        public void StartGame_CorrectNumberOfCellsPerRow()
        {
            // Arrange
            var rows = Faker.RandomNumber.Next(2, 10);
            var cols = Faker.RandomNumber.Next(2, 10);

            // Act
            var sut = _createSubjectUnderTest(rows, cols);
            sut.StartGame();

            // Assert
            sut.GameState
                .ToList()
                .ForEach(r => Assert.AreEqual(cols, r.Count) );            
        }

        [Test]
        public void StartGame_EmitsInitialState()
        {
            // Arrange
            var rows = Faker.RandomNumber.Next(2, 10);
            var cols = Faker.RandomNumber.Next(2, 10);
            var eventEmitter = new GameEventEmitterBuilder().Build();

            // Act
            var sut = _createSubjectUnderTest(rows, cols, eventEmitter);
            sut.StartGame();

            // Assert
            eventEmitter
                .Received(1)
                .NewGameStateEvent(Arg.Any<IList<IList<ICell>>>());
        }
        #endregion

        #region  Method: NextGen() Test
        [Test]
        public void  NextGen_()
        {
            
        }
        #endregion

        #region Private Methods
        private IGameOfLife _createSubjectUnderTest(int rows, int cols, IGameEventEmitter eventEmitter = null)
        {
            eventEmitter = eventEmitter ?? new GameEventEmitterBuilder().Build();
            return new GameOfLife(eventEmitter, rowCount: rows, columnCount: cols);
        }
        #endregion

    }

}