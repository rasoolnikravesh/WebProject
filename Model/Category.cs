using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category : Base.Entity
    {
        public Guid ParentId { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(75)]
        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Title))]
        public string Title { get; set; } = default!;

        public ICollection<Post>? Posts { get; set; }
    }
}
