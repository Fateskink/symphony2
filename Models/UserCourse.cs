using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace symphony2.Models;

public partial class UserCourse
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
