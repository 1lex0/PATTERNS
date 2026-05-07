namespace PATTERNS.Lab3.Command;

public interface ICommand
{
    string CommandName { get; }
    string Description { get; }
    void Execute();
    void Undo();
}