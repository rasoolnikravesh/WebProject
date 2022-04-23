namespace ViewModels.MangeBlog;

public class AddPostViewModel
{
    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Title))]
    public string Title { get; set; } = default!;


    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Content))]
    public string Content { get; set; } = default!;

    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Category))]
    public string CategoryName { get; set; } = default!;



    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Summary))]
    public string Summary { get; set; } = default!;
}
