using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepositories;

public interface ICategoryRepository : Base.IRepository<Models.Category>
{
    Models.Category GetByName(string name);
}
