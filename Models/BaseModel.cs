using System.ComponentModel.DataAnnotations;

namespace symphony2.Models;

public partial class BaseModel
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
