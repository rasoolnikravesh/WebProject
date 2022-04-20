using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Base;

public class Repository<T> : object, IRepository<T> where T : Models.Base.Entity
{
    internal Repository(DatabaseContext databaseContext) : base()
    {
        DatabaseContext =
            databaseContext ?? throw new ArgumentNullException(paramName: nameof(databaseContext));
        DbSet = DatabaseContext.Set<T>();
    }

    // **********
    internal DatabaseContext DatabaseContext { get; }
    // **********

    // **********
    internal DbSet<T> DbSet { get; }
    // **********

    public virtual void Insert(T entity)
    {
        if (entity == null)
        {
            throw new System.ArgumentNullException(paramName: nameof(entity));
        }

        DbSet.Add(entity);
    }

    public virtual async Task InsertAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }

        await DbSet.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }

        DbSet.Update(entity);
    }

    public virtual async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }


        await Task.Run(() =>
        {
            DbSet.Update(entity);
        });
    }

    public virtual void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }

        DbSet.Remove(entity);

    }

    public virtual async Task DeleteAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }

        await Task.Run(() =>
        {
            DbSet.Remove(entity);
        });
    }

    public virtual T GetById(System.Guid id)
    {
        var resault = DbSet.Find(keyValues: id);
        return (resault != null) ? resault : default!;
    }

    public virtual async Task<T> GetByIdAsync(System.Guid id)
    {
        var resault = await DbSet.FindAsync(keyValues: id);
        return resault != null ? resault : default!;
    }

    public virtual bool DeleteById(Guid id)
    {
        T entity = GetById(id);

        if (entity == null)
        {
            return false;
        }

        Delete(entity);

        return true;
    }

    public virtual async Task<bool> DeleteByIdAsync(Guid id)
    {
        T entity =
            await GetByIdAsync(id);

        if (entity == null)
        {
            return false;
        }

        await DeleteAsync(entity);

        return true;
    }

    public virtual IList<T> GetAll()
    {

        var result =
            DbSet.ToList()
            ;

        return result;
    }

    public virtual async Task<IList<T>> GetAllAsync()
    {

        var result =
            await
            DbSet.ToListAsync()
            ;

        return result;

    }
}

