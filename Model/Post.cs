using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Post : Base.Entity
    {
        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Name))]
        public string Name { get; set; }
        public string? Text { get; set; }
    }
}
