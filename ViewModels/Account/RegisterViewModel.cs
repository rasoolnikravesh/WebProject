﻿namespace ViewModels.Account;

public class RegisterViewModel
{
    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.UserName))]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.StringLength(maximumLength: 20)]
    public string UserName { get; set; } = default!;

    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Email))]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.EmailAddress]
    public string Email { get; set; } = default!;

    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Password))]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
    public string Password { get; set; } = default!;


    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.ConfirmPassword))]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
    [System.ComponentModel.DataAnnotations.Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = default!;

}
