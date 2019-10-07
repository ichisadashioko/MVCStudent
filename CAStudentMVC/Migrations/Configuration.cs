namespace CAStudentMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CAStudentMVC.Models.CAStudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CAStudentMVC.Models.CAStudentDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Students.AddOrUpdate(
                new Student
                {
                    FirstName = "Kennith",
                    LastName = "Rusch",
                    DoB = DateTime.Parse("1987-12-11"),
                    Gender = Gender.Male,
                    EntryScore = 6.7f,
                    HasCriminalRecord = true,
                },
                new Student
                {
                    FirstName = "Wilbert",
                    LastName = "Fava",
                    DoB = DateTime.Parse("1982-1-11"),
                    Gender = Gender.Male,
                    EntryScore = 7.4f,
                    HasCriminalRecord = false,
                },
                new Student
                {
                    FirstName = "Marleen",
                    LastName = "Bashir",
                    DoB = DateTime.Parse("1989-9-21"),
                    Gender = Gender.Male,
                    EntryScore = 6.2f,
                    HasCriminalRecord = true,
                },
                new Student
                {
                    FirstName = "Marybeth",
                    LastName = "Graziano",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 9.7f,
                    HasCriminalRecord = false,
                },
                new Student
                {
                    FirstName = "Misti",
                    LastName = "Witte",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 8.7f,
                    HasCriminalRecord = true,
                }
            );
        }
    }
}
