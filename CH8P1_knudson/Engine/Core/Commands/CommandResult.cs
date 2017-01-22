using Engine.Core.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands
{
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
