﻿using Microsoft.EntityFrameworkCore;
using symphony2.Database.Seeders;
using symphony2.Models.Configs;

namespace symphony2.Models;

public partial class SymphonyContext : DbContext
{
    public SymphonyContext()
    {
    }

    public SymphonyContext(DbContextOptions<SymphonyContext> options) : base(options)
    {
        UserSeeder.Seed(this);
        CourseSeeder.Seed(this);
    }

    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Course> Course { get; set; }
    public virtual DbSet<UserCourse> UserCourse { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new UserCourseConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
