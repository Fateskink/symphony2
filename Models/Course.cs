using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace symphony2.Models;

public partial class Course
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Course Name is required")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Course Name must be between 3 and 150 characters")]
    public string? CourseName { get; set; }

    [Required(ErrorMessage = "Major is required")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Major must be between 3 and 150 characters")]
    public string? Major { get; set; }

    [StringLength(1000, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 1000 characters")]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<UserCourse> UserCourses { get; set; }
}
