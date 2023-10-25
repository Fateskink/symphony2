using symphony2.Models;
using System;
using System.Linq;

namespace symphony2.Seeders;

public class UserSeeder
{
    public static void Seed(SymphonyContext context)
    {
      try {
        if (!context.User.Any())
        {
            for (int i = 1; i <= 10; i++)
            {
                var user = new User
                {
                    FirstName = GenerateRandomName(),
                    LastName = GenerateRandomName(),
                    Number = GenerateRandomNumber(),
                    Birthday = DateTime.Now.AddYears(-i),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                context.User.Add(user);
            }
            context.SaveChanges();
            Console.WriteLine("Seeder: Users added successfully");

        } else {
          Console.WriteLine("Seeder: Users already exist in the database");

        }

      } catch (Exception ex) {
        Console.WriteLine("Seeder Error: " + ex.Message);
      }
    }

    private static string GenerateRandomName()
    {
        return "User" + Guid.NewGuid().ToString("N").Substring(0, 5);
    }

    private static string GenerateRandomNumber()
    {
        Random random = new Random();
        return "0" + new string(Enumerable.Range(0, 9).Select(_ => random.Next(0, 10).ToString()[0]).ToArray());
    }
}
