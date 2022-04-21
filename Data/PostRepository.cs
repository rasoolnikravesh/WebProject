using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class PostRepository : Repository<Models.Post>, IPostRepository
{
    internal PostRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public IList<Post> GetLast10Posts()
    {
        var posts = DatabaseContext.Posts?.Include(p => p.User).OrderByDescending(p => p.InsertDateTime).Take(10).ToList();
        return posts;
    }
}
