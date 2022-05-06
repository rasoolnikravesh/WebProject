using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Permission : Base.Entity
    {
        public Permission() : base()
        {

        }

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Title { get; set; } = default!;

        [Required]
        public Action Action { get; set; } = default!;
        [Required]
        public string Route { get; set; } = default!;

        public ICollection<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
