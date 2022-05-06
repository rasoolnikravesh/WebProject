using System.ComponentModel.DataAnnotations;

namespace ViewModels.Account;

public class LoginViewModel
{
    [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Email))]
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Password))]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    [Display(ResourceType = typeof(Resources.DataDictionary),Name = nameof(Resources.DataDictionary.RememberMe))]
    [Required]
    public bool RememberMe { get; set; }
}


