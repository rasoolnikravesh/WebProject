using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Role
{
    public class InsertRole
    {

        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.RoleName))]
        public string? Name { get; set; }
    }
}
