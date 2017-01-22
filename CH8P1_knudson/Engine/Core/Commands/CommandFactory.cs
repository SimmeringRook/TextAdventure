using Engine.Core.Commands.Executable;
using Engine.Core.Creatures;
using Engine.Core.Items;
using Engine.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands
{
    public static class CommandFactory
    {
        private static Player _player;
        public static ICommandable ParseUserInputIntoCommand(string[] arguments)
        {
            CommandType type = ParseStringToCommandType(arguments[0]);
            _player = World.World.Instance.CurrentPlayer;

            switch (type)
            {
                #region Player Environment Commands
                case CommandType.Go:
                    string direction = (arguments.Length > 1)
                        ? arguments[1]
                        : null;
                   return CreateGoCommand(direction) as ICommandable;

                case CommandType.Look:
                    return CreateLookCommand() as ICommandable;

                case CommandType.Open:
                    return CreateOpenCommand();

                case CommandType.Attack:
                    string targetName = (arguments.Length > 1)
                        ? arguments[1]
                        : null;
                    return CreateAttackCommand(targetName);
                #endregion
                #region Inventory Management Commands
                case CommandType.Inventory:
                    return CreateInventoryCommand();

                case CommandType.Take:
                case CommandType.Get:
                    string itemToLootName = (arguments.Length > 1)
                        ? arguments[1]
                        : null;
                    return CreateTakeCommand(itemToLootName) as ICommandable;

                case CommandType.Equip:
                    string itemToEquipName = (arguments.Length > 1)
                        ? arguments[1]
                        : null;
                    return CreateEquipCommand(itemToEquipName);

                case CommandType.Drop:
                    string itemToDropName = (arguments.Length > 1)
                        ? arguments[1]
                        : null;
                    return CreateDropCommand(itemToDropName);
                #endregion
                #region Game Commands
                case CommandType.Score:
                    return CreateScoreCommand();
                case CommandType.Quit:
                    return CreateQuitCommand();
                #endregion
            }

            return null;
        }

        #region CommandType
        private static List<CommandType> _commandTypes = new List<CommandType>()
        {
            CommandType.Go,
            CommandType.Look,
            CommandType.Take,
            CommandType.Get,
            CommandType.Drop,
            CommandType.Open,
            CommandType.Inventory,
            CommandType.Score,
            CommandType.Quit,
            CommandType.Equip,
            CommandType.Attack
        };

        private static CommandType ParseStringToCommandType(string input)
        {
            foreach (CommandType command in _commandTypes)
            {
                if (input.ToLower().Equals(command.ToString().ToLower()))
                    return command;
            }

            throw new NotImplementedException();
        }
        #endregion

        //NotImplemented Yet:
        //  -Open
        #region Player Environment Commands

        #region Go Command
        private static Go CreateGoCommand(string input)
        {
            Direction directionToMove = ConvertStringToDirection(input); 
            return new Go(_player, directionToMove);
        }

        private static List<Direction> _directions = new List<Direction>()
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West
        };
        private static Direction ConvertStringToDirection(string unFormattedDirection)
        {
            Direction directionToMove = Direction.Empty;
            
            foreach (Direction direction in _directions)
            {
                if (unFormattedDirection.ToLower().Equals(direction.ToString().ToLower()))
                    directionToMove = direction;
            }

            return directionToMove;
        }
        #endregion

        #region Look Command
        private static Look CreateLookCommand()
        {
            return new Look(_player);
        }
        #endregion

        #region Open Command 
        private static Open CreateOpenCommand()
        {
            throw new NotImplementedException();
            return new Open(_player);
        }
        #endregion

        #region Attack Command
        private static Attack CreateAttackCommand(string targetName)
        {
            return new Attack(_player, targetName);
        }
        #endregion

        #endregion

        #region Inventory Management Commands


        #region Inventory Command
        private static Inventory CreateInventoryCommand()
        {
            return new Inventory(_player);
        }
        #endregion

        //Is "Get" not just an alias for take?
        #region Take/Get Command
        private static Take CreateTakeCommand(string itemToLootName)
        {
            return new Take(_player, itemToLootName);
        }

        //private static Get CreateGetCommand()
        //{
        //    throw new NotImplementedException();
        //    return new Get();
        //}
        #endregion

        #region Equip Command
        private static Equip CreateEquipCommand(string itemToEquipName)
        {
            return new Equip(_player, itemToEquipName);
        }
        #endregion

        #region Drop Command
        private static Drop CreateDropCommand(string itemName)
        {
            IItem itemToDrop = GetItemToDrop(itemName);
            return new Drop(_player, itemToDrop);
        }

        private static IItem GetItemToDrop(string itemName)
        {
            IItem drop = null;
            foreach (IItem item in World.World.MasterItemList)
            {
                if (item.GetFormalName().ToLower().Equals(itemName.ToLower()))
                    drop = item;
            }
            return drop;
        }
        #endregion

        #endregion

        //Not Implemented Yet:
        //  -Quit
        #region Game Commands

        #region Score Command
        private static Score CreateScoreCommand()
        {
            return new Score(_player);
        }
        #endregion

        #region Quit Command
        private static Quit CreateQuitCommand()
        {
            throw new NotImplementedException();
            return new Quit(_player);
        }
        #endregion

        #endregion


    }
}
