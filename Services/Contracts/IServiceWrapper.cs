namespace Services.Contracts
{
    public interface IServiceWrapper
    {
        ITestService Test { get; }
        
        IUserPointHistoryService UserPointHistory { get; }
    }
}