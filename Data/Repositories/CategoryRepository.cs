using Data.IRepositories;
using Models;

namespace Data.Repositores;

public class CategoryRepository : Repository<Models.Category>, ICategoryRepository
{
    internal CategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public Category GetByName(string name)
    {
        var data = DatabaseContext.Categories?.Where(x => x.Title == name).SingleOrDefault();
        return data;
    }
}
