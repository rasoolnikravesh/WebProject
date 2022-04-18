using Microsoft.EntityFrameworkCore;

namespace Data.Base;

public abstract class UnitOfWork : object, IUnitOfWork
{

    public UnitOfWork(Tools.Options options) : base()
    {
        Options = options;
    }

    // **********
    protected Tools.Options Options { get; set; }
    // **********

    // **********
    private DatabaseContext? _databaseContext;
    // **********

    // **********
    /// <summary>
    /// Lazy Loading = Lazy Initialization
    /// </summary>
    internal DatabaseContext DatabaseContext
    {
        get
        {
            if (_databaseContext == null)
            {
                var optionsBuilder =
                    new DbContextOptionsBuilder<DatabaseContext>();

                switch (Options.Provider)
                {
                    case Tools.Enums.Provider.SqlServer:
                        {
                            object p = optionsBuilder.UseSqlServer
                                (connectionString: Options.ConnectionString);
                            break;
                        }

                    case Tools.Enums.Provider.MySql:
                        {
                            //optionsBuilder.UseMySql
                            //	(connectionString: Options.ConnectionString);

                            break;
                        }

                    case Tools.Enums.Provider.Oracle:
                        {
                            //optionsBuilder.UseOracle
                            //	(connectionString: Options.ConnectionString);

                            break;
                        }

                    case Tools.Enums.Provider.PostgreSQL:
                        {
                            //optionsBuilder.UsePostgreSQL
                            //	(connectionString: Options.ConnectionString);

                            break;
                        }

                    case Tools.Enums.Provider.InMemory:
                        {
                            // optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                _databaseContext =
                    new DatabaseContext(options: optionsBuilder.Options);
            }

            return _databaseContext;
        }
    }

    Repository<T> IUnitOfWork.GetRepository<T>()
    {
        return new Repository<T>(databaseContext: DatabaseContext);
    }

    public virtual void Save()
    {
        DatabaseContext.SaveChanges();
    }

    public virtual async Task SaveAsync()
    {
        await DatabaseContext.SaveChangesAsync();
    }

    public bool IsDisposed { get; protected set; }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed)
        {
            return;
        }

        if (disposing)
        {

            if (_databaseContext != null)
            {
                _databaseContext.Dispose();
                _databaseContext = null;
            }
        }

        
        IsDisposed = true;
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }

}
