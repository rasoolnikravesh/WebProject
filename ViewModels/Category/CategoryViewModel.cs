namespace ViewModels.Category;

public class CategoryViewModel
{
    [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Title))]
    [System.ComponentModel.DataAnnotations.StringLength(60)]
    public string Title { get; set; }
}
