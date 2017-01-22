using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands
{
    public enum CommandType
    {
        Go,
        Look,
        Take,
        Get,
        Drop,
        Open,
        Inventory,
        Score,
        Quit,
        Equip,
        Attack
    }
}
