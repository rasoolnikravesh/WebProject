using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Models;

// Add profile data for application users by adding properties to the User class
public class ApplicationUser : IdentityUser<Guid>
{
    [Display(ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Name))]
    [MaxLength(Constant.Length.GENERAL_NAME)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [Display(ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Name))]
    [MaxLength(Constant.Length.GENERAL_NAME)]
    [Required]
    public string LastName { get; set; } = string.Empty;

    public virtual ICollection<Post> Posts { get; set; } = default!;
}

