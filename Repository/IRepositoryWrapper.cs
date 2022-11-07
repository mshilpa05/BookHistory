namespace BookHistory.Repository
{
    public interface IRepositoryWrapper
    {
        IBookRepository Book { get; }
        IAuditRepository Audit { get; }
        Task SaveAsync();
    }
}