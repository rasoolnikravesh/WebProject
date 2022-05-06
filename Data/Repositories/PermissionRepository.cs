using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PermissionRepository : Repository<Models.Permission>, IRepositories.IPermissionRepository
    {
        internal PermissionRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
