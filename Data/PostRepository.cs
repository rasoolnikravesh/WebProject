using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PostRepository : Repository<Models.Post>, IPostRepository
    {
        internal PostRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        
    }
}
