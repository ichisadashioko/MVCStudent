namespace StudentMVC2.Migrations
{
    using StudentLib.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentMVC2.Models.StudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentMVC2.Models.StudentDBContext context)
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
                    //Address = "",
                    //AvatarImage = "/Content/Images/boy.png"
                },
                new Student
                {
                    FirstName = "Raise",
                    LastName = "Padgett",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    //Address = "",
                    //AvatarImage = "/Content/Images/boy-1.png"
                },
                new Student
                {
                    FirstName = "Retha",
                    LastName = "Segars",
                    DoB = DateTime.Parse("1973-6-12"),
                    Gender = Gender.Female,
                    //Address = "",
                    //AvatarImage = "/Content/Images/girl.png"
                },
                new Student
                {
                    FirstName = "Wilbert",
                    LastName = "Fava",
                    DoB = DateTime.Parse("1982-1-11"),
                    Gender = Gender.Male,
                    //Address = "",
                    //AvatarImage = "/Content/Images/girl-1.png"
                },
                new Student
                {
                    FirstName = "Marleen",
                    LastName = "Bashir",
                    DoB = DateTime.Parse("1989-9-21"),
                    Gender = Gender.Male,
                    //Address = "",
                    //AvatarImage = "/Content/Images/man.png"
                },
                new Student
                {
                    FirstName = "Marybeth",
                    LastName = "Graziano",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    //Address = "",
                    //AvatarImage = "/Content/Images/man-1.png"
                },
                new Student
                {
                    FirstName = "Misti",
                    LastName = "Witte",
                    DoB = DateTime.Parse("1989-1-11"),
                    Gender = Gender.Female,
                    //Address = "",
                    //AvatarImage = "/Content/Images/man-2.png"
                }
            );
        }
    }
}
