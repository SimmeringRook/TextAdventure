using Engine.Core.Commands;
using System.Collections.Generic;

namespace Engine.Core.IO
{
    public static class IOManager
    {
        //TODO: Move to a different file?
        //  probably in the file that will contain all the command aliases?
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

        //TODO: Hook into the UI
        public static void HandleNextInput(string lineOfInput, out List<string> outputToBeDisplayed)
        {
            string[] arguments = lineOfInput.Split(' ');
            //Get the command the user wants to execute
            ICommandable commandToExecute = CommandFactory.ParseUserInputIntoCommand(arguments);
            
            if (commandToExecute == null)
                //command was invalid/not supported/bad syntax
                outputToBeDisplayed = _invalidCommandSyntaxMessages;
            else
                //Execute the command and past back the text to be displayed to the user
                outputToBeDisplayed = commandToExecute.Execute().Dialog;

        }
    }
}
