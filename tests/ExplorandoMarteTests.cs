using NUnit.Framework;
using ExplorandoMarte.src.Models;
using ExplorandoMarte.src.Commands;
using ExplorandoMarte.src.Factories;

namespace MarsRover.Tests
{
    [TestFixture]
    public class ExplorandoMarteTests
    {
        [Test]
        public void TurnLeftTest()
        {
            Rover rover = new Rover(new Position(1, 1), Direction.N, "1");

            rover.TurnLeft();

            Assert.That(rover.Direction, Is.EqualTo(Direction.W));
        }

        [Test]
        public void TurnRightTest()
        {
            Rover rover = new Rover(new Position(1, 1), Direction.N, "1");

            rover.TurnRight();

            Assert.That(rover.Direction, Is.EqualTo(Direction.E));
        }

        [Test]
        public void MoveWithinPlateauTest()
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2), Direction.N, "1");
            var command = new MoveForwardCommand();

            command.Execute(rover, plateau);

            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(3));
        }

        [Test]
        public void MoveOutOfPlateauIgnoredTest()
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(5, 5), Direction.N, "1");
            var command = new MoveForwardCommand();

            command.Execute(rover, plateau);

            Assert.That(rover.Position.X, Is.EqualTo(5));
            Assert.That(rover.Position.Y, Is.EqualTo(5));
        }

        [Test]
        public void CollisionTest()
        {
            Plateau plateau = new Plateau(5, 5);
            plateau.OccupyPosition(new Position(1, 3));
            Rover rover = new Rover(new Position(1, 2), Direction.N, "1");
            var command = new MoveForwardCommand();

            command.Execute(rover, plateau);

            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(2));
        }
        [Test]
        public void RoverFactoryCreatesRoverCorrectly()
        {
            string input = "1 2 N";
            Rover rover = RoverFactory.CreateRover(input, "1");

            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(2));
            Assert.That(rover.Direction, Is.EqualTo(Direction.N));
        }

        [Test]
        public void RoverFactoryThrowsExceptionForInvalidInput()
        {
            string invalidInput = "1 2";

            Assert.Throws<ArgumentException>(() =>
            {
                RoverFactory.CreateRover(invalidInput, "1");
            });
        }

        [Test]
        public void PlateauAcceptsPositionWithinBounds()
        {
            Plateau plateau = new Plateau(5, 5);
            Position position = new Position(3, 3);

            Assert.That(plateau.IsWithinBounds(position), Is.True);
        }

        [Test]
        public void PlateauRejectsPositionOutOfBounds()
        {
            Plateau plateau = new Plateau(5, 5);
            Position position = new Position(6, 6);

            Assert.That(plateau.IsWithinBounds(position), Is.False);
        }

        [Test]
        public void PlateauRegistersOccupiedPositions()
        {
            Plateau plateau = new Plateau(5, 5);
            Position position = new Position(2, 2);

            plateau.OccupyPosition(position);

            Assert.That(plateau.IsPositionOccupied(position), Is.True);
        }

        [Test]
        public void PlateauDetectsCollisionOnOccupiedPosition()
        {
            Plateau plateau = new Plateau(5, 5);
            Position position = new Position(2, 2);

            plateau.OccupyPosition(position);

            Assert.That(plateau.IsPositionOccupied(new Position(2, 2)), Is.True);
        }

        [Test]
        public void RotateLeftCommandWorksCorrectly()
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(0, 0), Direction.N, "1");
            ICommand command = new RotateLeftCommand();

            command.Execute(rover, plateau);

            Assert.That(rover.Direction, Is.EqualTo(Direction.W));
        }

        [Test]
        public void RotateRightCommandWorksCorrectly()
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(0, 0), Direction.N, "1");
            ICommand command = new RotateRightCommand();

            command.Execute(rover, plateau);

            Assert.That(rover.Direction, Is.EqualTo(Direction.E));
        }

        [Test]
        public void MoveForwardCommandWorksCorrectly()
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 1), Direction.N, "1");
            ICommand command = new MoveForwardCommand();

            command.Execute(rover, plateau);

            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(2));
        }

        [Test]
        public void ExecuteFullCommandSequence()
        {
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2), Direction.N, "1");
            string commands = "LMLMLMLMM";

            foreach (char commandChar in commands)
            {
                ICommand command = CommandFactory.GetCommand(commandChar);
                command.Execute(rover, plateau);
            }

            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(3));
            Assert.That(rover.Direction, Is.EqualTo(Direction.N));
        }
    }
}