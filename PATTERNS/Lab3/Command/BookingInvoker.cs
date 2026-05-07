namespace PATTERNS.Lab3.Command;

public class BookingInvoker
{
    private readonly Stack<ICommand> _history = new();

    public List<(string name, string description)> GetHistory() =>
        _history.Select(c => (c.CommandName, c.Description)).ToList();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public bool UndoLast()
    {
        if (!_history.Any()) return false;
        var command = _history.Pop();
        command.Undo();
        return true;
    }
}