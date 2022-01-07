namespace Contracts.Services
{
    public interface IServiceWrapper
    {
        ITestService Test { get; }

        IUserPointHistoryService UserPointHistory { get; }

        ICompanyService Company { get; }

        ILocationService Location { get; }

        IBranchService Branch { get; }
        
        IEventService Event { get; }
        
        IUserService User { get; }
    }
}