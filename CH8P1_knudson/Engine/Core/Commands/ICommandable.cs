namespace Engine.Core.Commands
{
    /// <summary>
    /// The interface used for Dependency Injection - allowing the IOManager to execute whatever command was created.
    /// </summary>
    public interface ICommandable
    {
        CommandResult Execute();
    }
}
