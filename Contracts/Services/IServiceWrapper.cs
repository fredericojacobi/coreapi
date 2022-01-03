namespace Contracts.Services
{
    public interface IServiceWrapper
    {
        ITestService Test { get; }
        
        IUserPointHistoryService UserPointHistory { get; }
        
        ICompanyService Company { get; }
        
        ILocationService Location { get; }
    }
}