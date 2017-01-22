using Engine.Core.Combat;
using Engine.Core.Creatures;
using Engine.Core.Items;
using Engine.Core.Items.Equipable;
using Engine.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands
{
    public abstract class Command : ICommandable
    {
        protected Player player;

        public Command(Player player)
        {
            this.player = player;
        }

        public abstract CommandResult Execute();

            //switch(arguments.Type)
            //{
            //    case CommandType.Go:
            //        Movement(arguments.DirectionToMove);
            //        break;
            //    case CommandType.Look:
            //        Look();
            //        break;
            //    case CommandType.Take:
            //        Take();
            //        break;
            //    case CommandType.Get:
            //        Get();
            //        break;
            //    case CommandType.Drop:
            //            thePlayer.CurrentRoom.DropItemInRoom(thePlayer.Drop(arguments.ItemToDrop.ID));
            //        break;
            //    case CommandType.Open:
            //        Open();
            //        break;
            //    case CommandType.Inventory:
            //        Inventory();
            //        break;
            //    case CommandType.Score:
            //        break;
            //    case CommandType.Quit:
            //        break;
            //    case CommandType.Equip:
            //        arguments.ItemToEquip.Equip(thePlayer);
            //        break;
            //    case CommandType.Attack:
            //        InitiateCombat();
            //        break;
            //}

        
    }
}
