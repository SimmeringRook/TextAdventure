using Engine.Core.Combat;
using System.Collections.Generic;

namespace Engine.Core.Commands
{
    /// <summary>
    /// This is a glorified data structure to handle accepting all the different possiblities foreach command
    /// and act as an intermediary for the backend with commands being executed and the GUI for the user to know
    /// what has occured.
    /// </summary>
    public class CommandResult
    {
        public List<string> Dialog { get; private set; }

        public CommandResult()
        {
            Dialog = new List<string>();
        }

        public CommandResult(string lineOfDialog)
        {
            Dialog = new List<string>() { lineOfDialog };
        }

        public CommandResult(List<string> formattedDialog)
        {
            Dialog = new List<string>();
            foreach (string s in formattedDialog)
                Dialog.Add(s);
        }

        public CommandResult(List<CombatResult> combatSession)
        {
            Dialog = new List<string>();
            foreach (CombatResult turnOfCombat in combatSession)
            {
                foreach (string combat in turnOfCombat.Log)
                {
                    Dialog.Add(combat);
                }
            }
        }
        public void Log(string log)
        {
            Dialog.Add(log);
        }
    }
}
