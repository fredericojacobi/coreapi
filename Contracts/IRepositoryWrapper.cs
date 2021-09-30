namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IReminderRepository Reminder { get; }
    }
}