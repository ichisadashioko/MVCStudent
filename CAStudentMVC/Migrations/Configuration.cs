namespace CAStudentMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentLib.Models;
    using CAStudentMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CAStudentMVC.Models.CADBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CAStudentMVC.Models.CADBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Students.AddOrUpdate(
                new CAStudent
                {
                    FirstName = "Kennith",
                    LastName = "Rusch",
                    DoB = DateTime.Parse("1987-12-11"),
                    Gender = Gender.Male,
                    EntryScore = 6.7f,
                    HasCriminalRecord = true,
                    Province=Province.AnGiang,
                    BankBalance=10000m,
                    Height=1.56f,
                    WasParentInService=false,
                },
                new CAStudent
                {
                    FirstName = "Wilbert",
                    LastName = "Fava",
                    DoB = DateTime.Parse("1982-1-11"),
                    Gender = Gender.Male,
                    EntryScore = 7.4f,
                    HasCriminalRecord = false,
                    Province=Province.BinhThuan,
                    BankBalance=10000m,
                    Height = 1.75f,
                    WasParentInService = false,
                },
                new CAStudent
                {
                    FirstName = "Marleen",
                    LastName = "Bashir",
                    DoB = DateTime.Parse("1989-9-21"),
                    Gender = Gender.Male,
                    EntryScore = 6.2f,
                    HasCriminalRecord = true,
                    Province=Province.HauGiang,
                    BankBalance=10000m,
                    Height = 1.62f,
                    WasParentInService = true,
                },
                new CAStudent
                {
                    FirstName = "Marybeth",
                    LastName = "Graziano",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 9.7f,
                    HasCriminalRecord = false,
                    Province=Province.LaoCai,
                    BankBalance=10000m,
                    Height = 1.78f,
                    WasParentInService = false,
                },
                new CAStudent
                {
                    FirstName = "Misti",
                    LastName = "Witte",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    EntryScore = 8.7f,
                    HasCriminalRecord = true,
                    Province=Province.QuangNinh,
                    BankBalance=10000m,
                    Height = 1.61f,
                    WasParentInService = true,
                }
            );
        }
    }
}
