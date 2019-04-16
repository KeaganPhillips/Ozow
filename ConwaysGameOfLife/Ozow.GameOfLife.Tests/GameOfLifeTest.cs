using NUnit.Framework;
using Ozow.GameOfLife.Domain.DomainModel;

namespace Tests
{
    public class GameOfLifeTests
    {

        [Test]
        public void Ctor_RowColCountCorrect()
        {
            // Arrange
            var rows = Faker.RandomNumber.Next(2, 10);
            var cols = Faker.RandomNumber.Next(2, 10);

            // Act
            var sut = new GameOfLife(rowCount: rows, columnCount: cols);

            // Assert
            Assert.AreEqual(rows, sut.RowCount);
            Assert.AreEqual(cols, sut.ColCount);
        }
    }
}