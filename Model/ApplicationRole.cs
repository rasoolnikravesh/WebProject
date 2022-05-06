namespace Models
{
    public class ApplicationRole : Microsoft.AspNetCore.Identity.IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {

        }

        public ICollection<Group> Groups { get; set; } = new List<Group>();

        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
