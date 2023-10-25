using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace symphony2.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    public string? Number { get; set; }

    public DateTime? Birthday { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
