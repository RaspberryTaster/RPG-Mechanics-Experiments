using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Commands
{
    [Serializable]
	public class Command_Sequence
	{
        protected readonly Queue<Command_Base> command_Wait = new Queue<Command_Base>();
        protected readonly Queue<Command_Base> command_Done = new Queue<Command_Base>();
        protected bool executing;
        protected bool paused;

        [Range(0, 3000)]
        public int delayMS = 0;

        public int Wait_Conut { get { return command_Wait.Count; } }
        public int Done_Count { get { return command_Done.Count; } }

        public virtual void Register(Command_Base command)
        {
            command_Wait.Enqueue(command);
        }
        public void Reset()
		{
            Clear();
            executing = false;
		}

        public virtual void Clear()
        {
            command_Wait.Clear();
            command_Done.Clear();
        }

        public void Next_Command()
        {
            if (executing)
            {
                Debug.LogWarning("A Command is already being executed.");
                return;
            }
            Thread.Sleep(delayMS);

            executing = true;

            while (paused)
            {
                Thread.Sleep(100);
            }

            if (command_Wait.Count > 0)
            {
                Command_Base command = command_Wait.Dequeue();
                command.Execute();
                command_Done.Enqueue(command);
            }
            else
            {
                Debug.LogWarning("No actions are in wait, so I can't execute anything.");
            }
            executing = false;
        }

        public void Undo_Command()
		{
            if (command_Done.Count > 0)
            {
                if (command_Done.Peek().disable_Undo)
                {
                    Debug.LogWarning("Action undo is disabled.");
                    return;
                }

                Command_Base command = command_Done.Dequeue();
                command.Undo();
            }
            else
            {
                Debug.LogWarning("No action can be undone.");
            }
        }

        public override string ToString()
        {
            return "ActionSequence, wait: " + command_Wait.Count + ", done: " + command_Done.Count;
        }
    }
}
