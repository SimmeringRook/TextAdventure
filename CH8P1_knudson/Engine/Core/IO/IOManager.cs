using Engine.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.IO
{
    public static class IOManager
    {
        private static List<string> _invalidCommandSyntaxMessages = new List<string>()
        {
            "Invalid command syntax.",
            "Valid commands are: ",
            "--Environment: ",
            "Go",
            "Look",
            "Open",
            "Attack",
            "--Inventory Management:",
            "Take",
            "Get",
            "Drop",
            "Inventory",
            "Equip",
            "--Game:",
            "Score",
            "Quit"
        };

        public static void HandleNextInput(string lineOfInput, out List<string> outputToBeDisplayed)
        {
            string[] arguments = lineOfInput.Split(' ');
            ICommandable commandToExecute = CommandFactory.ParseUserInputIntoCommand(arguments);

            if (commandToExecute == null)
                outputToBeDisplayed = _invalidCommandSyntaxMessages;
            else
                outputToBeDisplayed = commandToExecute.Execute().Dialog;

        }
    }
}
