using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class PostRepository : Repository<Models.Post>, IPostRepository
{
    internal PostRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }



    public async Task<IList<Post>> GetAllWithCategoryAsync()
    {
        var posts = await DatabaseContext.Posts.Include(x => x.Category).ToListAsync();
        return posts;
    }

    public IList<Post> GetLast10Posts()
    {
        var posts = DatabaseContext.Posts?.Include(x => x.Category)
            .OrderByDescending(p => p.InsertDateTime).Take(10).ToList();
        return posts;
    }
}
