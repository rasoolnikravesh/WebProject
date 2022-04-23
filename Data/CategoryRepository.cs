using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
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
}
