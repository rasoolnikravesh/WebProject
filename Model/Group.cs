using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Group : Base.Entity
    {
        public Group() : base()
        {

        }
        public string Name { get; set; } = default!;

        public ICollection<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();

        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
