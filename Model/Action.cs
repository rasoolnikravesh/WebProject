using System.ComponentModel.DataAnnotations;

namespace Models;

public class Action : Base.Entity
{
    public Action() : base()
    {

    }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = default!;

    //Controller Relation
    public Guid ControllerId { get; set; }
    public Controller Controller { get; set; } = default!;

    //Permission

    public Guid PermissionId { get; set; }
    [Required]
    public Permission Permission { get; set; } = default!;
}
