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
        public string Name { get; set; }
        public string? Text { get; set; }
    }
}
