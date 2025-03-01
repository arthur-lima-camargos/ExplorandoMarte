﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.src.Commands
{
    /// <summary>
    /// Fábrica para criação de objetos ICommand a partir de um caractere.
    /// </summary>
    public static class CommandFactory
    {
        public static ICommand GetCommand(char commandChar)
        {
            return commandChar switch
            {
                'L' => new RotateLeftCommand(),
                'R' => new RotateRightCommand(),
                'M' => new MoveForwardCommand(),
                _ => null,
            };
        }
    }
}
