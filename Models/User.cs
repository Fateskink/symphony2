using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace symphony2.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(150, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 2 characters")]
    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Number { get; set; }

    public DateTime? Birthday { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
