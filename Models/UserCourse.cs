using System.ComponentModel.DataAnnotations;

namespace symphony2.Models;

public partial class UserCourse : BaseModel
{
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }

    [Required]
    public int CourseId { get; set; }
    public Course? Course { get; set; }
}
