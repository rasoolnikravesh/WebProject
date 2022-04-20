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
        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Title))]
        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; } = default!;

        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Content))]
        public string Content { get; set; } = default!;

        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Summary))]
        [System.ComponentModel.DataAnnotations.StringLength(150, MinimumLength = 30)]
        public string? Summary { get; set; }

        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Published))]
        public bool Published { get; set; } = default!;

        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.PublishedAt))]
        public DateTime PublishedAt { get; set; }

        public Models.ApplicationUser User { get; set; } = null!;

        public ICollection<Category>? Categories { get; set; }
    }
}
