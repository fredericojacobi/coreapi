namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IBranchRepository Branch { get; }
        
        ICompanyRepository Company { get; }
        
        IEletronicPointHistoryRepository EletronicPointHistory { get; }
        
        IEventRepository Event { get; }
        
        ILocationRepository Location { get; }
        
        IPointRepository Point { get; }
        
        IReminderRepository Reminder { get; }
        
        IUserRepository User { get; }
        
        IEventUserRepository EventUser { get; }
    }
}