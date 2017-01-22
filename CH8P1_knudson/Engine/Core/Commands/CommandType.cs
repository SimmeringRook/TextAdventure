using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands
{
    //Obsolete?
    //TODO: Localize to the CommandFactory file?
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
