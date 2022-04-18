namespace Data.Base;

public interface IUnitOfWork : IDisposable
{
    bool IsDisposed { get; }

    void Save();

    Task SaveAsync();

    Repository<T> GetRepository<T>() where T : Models.Base.Entity;
}

