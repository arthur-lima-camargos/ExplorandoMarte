using NUnit.Framework;
using ExplorandoMarte.src.Models;
using ExplorandoMarte.src.Commands;
using NUnit.Framework.Legacy;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void TurnLeftTest()
        {
            // Arrange
            Rover rover = new Rover(new Position(1, 1), Direction.N, "1");

            // Act
            rover.TurnLeft();

            // Assert
            Assert.That(rover.Direction, Is.EqualTo(Direction.W));
        }

        [Test]
        public void TurnRightTest()
        {
            // Arrange
            Rover rover = new Rover(new Position(1, 1), Direction.N, "1");

            // Act
            rover.TurnRight();

            // Assert
            Assert.That(rover.Direction, Is.EqualTo(Direction.E));
        }

        [Test]
        public void MoveWithinPlateauTest()
        {
            // Arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2), Direction.N, "1");
            var command = new MoveForwardCommand();

            // Act
            command.Execute(rover, plateau);

            // Assert
            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(3));
        }

        [Test]
        public void MoveOutOfPlateauIgnoredTest()
        {
            // Arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(5, 5), Direction.N, "1");
            var command = new MoveForwardCommand();

            // Act
            command.Execute(rover, plateau);

            // Assert
            Assert.That(rover.Position.X, Is.EqualTo(5));
            Assert.That(rover.Position.Y, Is.EqualTo(5));
        }

        [Test]
        public void CollisionTest()
        {
            // Arrange
            Plateau plateau = new Plateau(5, 5);
            plateau.OccupyPosition(new Position(1, 3));
            Rover rover = new Rover(new Position(1, 2), Direction.N, "1");
            var command = new MoveForwardCommand();

            // Act
            command.Execute(rover, plateau);

            // Assert
            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(2));
        }
    }
}