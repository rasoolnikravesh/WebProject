namespace ViewModels.Account;

public class LoginViewModel
{
    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Email))]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.EmailAddress]
    [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Password))]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
    public string Password { get; set; } = default!;

    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary),Name = nameof(Resources.DataDictionary.RememberMe))]
    [System.ComponentModel.DataAnnotations.Required]
    public bool RememberMe { get; set; }
}


