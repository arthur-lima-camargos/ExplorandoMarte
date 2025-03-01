using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Models
{
    /// <summary>
    /// Representa o planalto de Marte.
    /// </summary>
    public class Plateau
    {
        public int MaxX { get; }
        public int MaxY { get; }

        // Lista de posições ocupadas por rovers já finalizados.
        private readonly List<Position> occupiedPositions = new List<Position>();

        public Plateau(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        /// <summary>
        /// Verifica se uma posição está dentro dos limites do planalto.
        /// </summary>
        public bool IsWithinBounds(Position pos)
        {
            return pos.X >= 0 && pos.X <= MaxX && pos.Y >= 0 && pos.Y <= MaxY;
        }

        /// <summary>
        /// Verifica se a posição informada já está ocupada por outro rover.
        /// </summary>
        public bool IsPositionOccupied(Position pos)
        {
            foreach (var occ in occupiedPositions)
            {
                if (occ.X == pos.X && occ.Y == pos.Y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Registra uma posição como ocupada.
        /// </summary>
        public void OccupyPosition(Position pos)
        {
            occupiedPositions.Add(new Position(pos.X, pos.Y));
        }
    }
}
