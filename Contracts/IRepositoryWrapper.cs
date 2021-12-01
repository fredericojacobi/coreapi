namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IReminderRepository Reminder { get; }
        
        IUserRepository User { get; }
        
        IEletronicPointHistoryRepository EletronicPointHistory { get; }
        
        IEventRepository Event { get; }
        
        IBranchRepository Branch { get; }
    }
}