using System.ComponentModel.DataAnnotations;

namespace Models;

public class Controller : Base.Entity
{
    public Controller() : base()
    {

    }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = default!;

    [StringLength(100)]
    public string? Title { get; set; }

    public ICollection<Action> actions { get; set; } = new List<Action>();
}
