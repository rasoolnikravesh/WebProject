using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public interface IPostRepository : Base.IRepository<Models.Post>
{
    IList<Models.Post> GetLast10Posts();

    Task<IList<Models.Post>> GetAllWithCategoryAsync();
}
