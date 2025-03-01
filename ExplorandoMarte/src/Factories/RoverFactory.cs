using ExplorandoMarte.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Factories
{
    /// <summary>
    /// Fábrica para instanciar a sonda (rover) a partir de um input do tipo "X Y D".
    /// </summary>
    public static class RoverFactory
    {
        public static Rover CreateRover(string positionInput, string roverId)
        {
            // Espera-se um formato "X Y D", sendo que D é N, E, S ou W.
            var parts = positionInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                throw new ArgumentException("Entrada inválida para a criação do rover.");
            }
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            var directionStr = parts[2].ToUpper();

            Direction direction = directionStr switch
            {
                "N" => Direction.N,
                "E" => Direction.E,
                "S" => Direction.S,
                "W" => Direction.W,
                _ => throw new ArgumentException("Direção inválida.")
            };

            return new Rover(new Position(x, y), direction, roverId);
        }
    }
}
