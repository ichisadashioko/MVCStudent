namespace BKStudentMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BKStudentMVC.Models;
    using StudentLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BKStudentMVC.Models.BKDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BKStudentMVC.Models.BKDBContext context)
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
                    HasCriminalRecord = false,
                    UndergraduateYears = 4,
                    Province=Province.AnGiang,
                    BankBalance=10000m,
                },
                new BKStudent
                {
                    FirstName = "Wilbert",
                    LastName = "Fava",
                    DoB = DateTime.Parse("1982-1-11"),
                    Gender = Gender.Male,
                    EntryScore = 7.4f,
                    HasCriminalRecord = true,
                    UndergraduateYears = 4,
                    Province=Province.BacKan,
                    BankBalance=2300m,
                },
                new BKStudent
                {
                    FirstName = "Marleen",
                    LastName = "Bashir",
                    DoB = DateTime.Parse("1989-9-21"),
                    Gender = Gender.Male,
                    EntryScore = 6.2f,
                    HasCriminalRecord = false,
                    UndergraduateYears = 3,
                    Province=Province.DakNong,
                    BankBalance=60m,
                },
                new BKStudent
                {
                    FirstName = "Marybeth",
                    LastName = "Graziano",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 9.7f,
                    HasCriminalRecord = false,
                    UndergraduateYears = 6,
                    Province=Province.BacKan,
                    BankBalance=20m,
                },
                new BKStudent
                {
                    FirstName = "Misti",
                    LastName = "Witte",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 8.7f,
                    HasCriminalRecord = true,
                    UndergraduateYears = 5,
                    Province=Province.TayNinh,
                    BankBalance=1500m,
                }
            );
        }
    }
}
