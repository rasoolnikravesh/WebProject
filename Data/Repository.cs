
namespace Data;

public class Repository<T> : Base.Repository<T> where T : Models.Base.Entity
{
    internal Repository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public override void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }

        entity.InsertDateTime = Models.Utility.Now;

        DbSet.Add(entity);
    }

}

