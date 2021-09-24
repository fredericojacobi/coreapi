namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IReminderRepository Reminder { get; }
    }
}