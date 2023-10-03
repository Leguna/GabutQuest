namespace Command
{
    public interface ICommand
    {
        ICommand PreviousCommand { get; set; }
        ICommand NextCommand { get; set; }
        void Execute(ICommand previousCommand);
        void Execute();
        void Undo();
        void Redo();
        void Cancel();
        void DisposePreviousCommand(int n);
    }
}