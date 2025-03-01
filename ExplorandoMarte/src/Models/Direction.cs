using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Models
{
    /// <summary>
    /// Enumera os pontos cardeais.
    /// </summary>
    public enum Direction
    {
        N, // Norte
        E, // Leste
        S, // Sul
        W  // Oeste
    }

    /// <summary>
    /// Métodos de extensão para facilitar a rotação.
    /// </summary>
    public static class DirectionExtensions
    {
        /// <summary>
        /// Rotaciona 90 graus para a esquerda.
        /// </summary>
        public static Direction TurnLeft(this Direction dir)
        {
            return dir switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => dir
            };
        }

        /// <summary>
        /// Rotaciona 90 graus para a direita.
        /// </summary>
        public static Direction TurnRight(this Direction dir)
        {
            return dir switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => dir
            };
        }
    }
}
