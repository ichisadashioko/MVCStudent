namespace FUStudentMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FUStudentMVC.Models;
    using StudentLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FUStudentMVC.Models.FUDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FUStudentMVC.Models.FUDBContext context)
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
                    HasCriminalRecord = true,
                    Credits = 20,
                    Province=Province.QuangNinh,
                    BankBalance=10000m,
                },
                new FUStudent
                {
                    FirstName = "Wilbert",
                    LastName = "Fava",
                    DoB = DateTime.Parse("1982-1-11"),
                    Gender = Gender.Male,
                    EntryScore = 7.4f,
                    HasCriminalRecord = false,
                    Credits = 46,
                    Province=Province.Foreign,
                    BankBalance=10000m,
                },
                new FUStudent
                {
                    FirstName = "Marleen",
                    LastName = "Bashir",
                    DoB = DateTime.Parse("1989-9-21"),
                    Gender = Gender.Male,
                    EntryScore = 6.2f,
                    HasCriminalRecord = true,
                    Credits = 30,
                    Province=Province.AnGiang,
                    BankBalance=10000m,
                },
                new FUStudent
                {
                    FirstName = "Marybeth",
                    LastName = "Graziano",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 9.7f,
                    HasCriminalRecord = false,
                    Credits = 69,
                    Province=Province.HaNam,
                    BankBalance=10000m,
                },
                new FUStudent
                {
                    FirstName = "Misti",
                    LastName = "Witte",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 8.7f,
                    HasCriminalRecord = true,
                    Credits = 51,
                    Province=Province.Foreign,
                    BankBalance=10000m,
                }
            );
        }
    }
}
