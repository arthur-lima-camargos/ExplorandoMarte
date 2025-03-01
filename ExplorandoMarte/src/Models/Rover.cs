using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Models
{
    /// <summary>
    /// Representa uma sonda exploradora.
    /// </summary>
    public class Rover
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        public string Id { get; } // Identificador opcional para melhor rastreamento

        public Rover(Position position, Direction direction, string id = "")
        {
            Position = position;
            Direction = direction;
            Id = id;
        }

        /// <summary>
        /// Rotaciona a sonda 90 graus à esquerda.
        /// </summary>
        public void TurnLeft()
        {
            Direction = Direction.TurnLeft();
        }

        /// <summary>
        /// Rotaciona a sonda 90 graus à direita.
        /// </summary>
        public void TurnRight()
        {
            Direction = Direction.TurnRight();
        }

        /// <summary>
        /// Calcula a próxima posição considerando a direção atual.
        /// </summary>
        public Position GetNextPosition()
        {
            return Direction switch
            {
                Models.Direction.N => new Position(Position.X, Position.Y + 1),
                Models.Direction.E => new Position(Position.X + 1, Position.Y),
                Models.Direction.S => new Position(Position.X, Position.Y - 1),
                Models.Direction.W => new Position(Position.X - 1, Position.Y),
                _ => new Position(Position.X, Position.Y)
            };
        }

        /// <summary>
        /// Move a sonda para a próxima posição (não validando os limites ou colisões – essa verificação é feita via Command).
        /// </summary>
        public void Move()
        {
            Position = GetNextPosition();
        }

        /// <summary>
        /// Retorna uma representação da posição final da sonda.
        /// </summary>
        public override string ToString()
        {
            return $"{Position.X} {Position.Y} {Direction}";
        }
    }
}
