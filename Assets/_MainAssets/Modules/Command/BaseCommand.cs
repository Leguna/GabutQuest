using System;

namespace Command
{
    public class BaseCommand : ICommand
    {
        public string CommandId = Guid.NewGuid().ToString();

        public BaseCommand(string commandName = "", ICommand previousCommand = null)
        {
            CommandName = commandName;
            PreviousCommand = previousCommand;
        }

        public string CommandName { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public void Execute()
        {
        }

        public void Execute(ICommand previousCommand)
        {
            PreviousCommand = previousCommand;
            DisposePreviousCommand(5);
            Execute();
        }

        public void Undo()
        {
        }

        public void Redo()
        {
        }

        public void Cancel()
        {
        }

        public void DisposePreviousCommand(int n)
        {
            // Limit command history to n
            if (PreviousCommand == null) return;
            PreviousCommand.DisposePreviousCommand(n - 1);
            PreviousCommand = null;
        }
    }
}