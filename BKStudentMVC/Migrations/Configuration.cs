namespace BKStudentMVC.Migrations
{
    using BKStudentMVC.Models;
    using StudentLib.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BKStudentMVC.Models.BKStudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BKStudentMVC.Models.BKStudentDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Students.AddOrUpdate(
                new BKStudent
                {
                    FirstName = "Kennith",
                    LastName = "Rusch",
                    DoB = DateTime.Parse("1987-12-11"),
                    Gender = Gender.Male,
                    EntryScore = 6.7f,
                    UndergraduateYears = 4,
                },
                new BKStudent
                {
                    FirstName = "Wilbert",
                    LastName = "Fava",
                    DoB = DateTime.Parse("1982-1-11"),
                    Gender = Gender.Male,
                    EntryScore = 7.4f,
                    UndergraduateYears = 4,
                },
                new BKStudent
                {
                    FirstName = "Marleen",
                    LastName = "Bashir",
                    DoB = DateTime.Parse("1989-9-21"),
                    Gender = Gender.Male,
                    EntryScore = 6.2f,
                    UndergraduateYears = 3,
                },
                new BKStudent
                {
                    FirstName = "Marybeth",
                    LastName = "Graziano",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 9.7f,
                    UndergraduateYears = 6,
                },
                new BKStudent
                {
                    FirstName = "Misti",
                    LastName = "Witte",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 8.7f,
                    UndergraduateYears = 5,
                }
            );
        }
    }
}
