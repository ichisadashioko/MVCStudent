namespace FUStudentMVC.Migrations
{
    using FUStudentMVC.Models;
    using StudentLib.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FUStudentMVC.Models.FUStudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FUStudentMVC.Models.FUStudentDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Students.AddOrUpdate(
                new FUStudent
                {
                    FirstName = "Kennith",
                    LastName = "Rusch",
                    DoB = DateTime.Parse("1987-12-11"),
                    Gender = Gender.Male,
                    EntryScore = 6.7f,
                    Credits = 20,
                },
                new FUStudent
                {
                    FirstName = "Wilbert",
                    LastName = "Fava",
                    DoB = DateTime.Parse("1982-1-11"),
                    Gender = Gender.Male,
                    EntryScore = 7.4f,
                    Credits = 46,
                },
                new FUStudent
                {
                    FirstName = "Marleen",
                    LastName = "Bashir",
                    DoB = DateTime.Parse("1989-9-21"),
                    Gender = Gender.Male,
                    EntryScore = 6.2f,
                    Credits = 30,
                },
                new FUStudent
                {
                    FirstName = "Marybeth",
                    LastName = "Graziano",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 9.7f,
                    Credits = 69,
                },
                new FUStudent
                {
                    FirstName = "Misti",
                    LastName = "Witte",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 8.7f,
                    Credits = 51,
                }
            );
        }
    }
}
