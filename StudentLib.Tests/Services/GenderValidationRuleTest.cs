using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLib.Models;
using StudentLib.Services;

namespace StudentLib.Tests.Services
{

    [TestClass]
    public class GenderValidationRuleTest
    {
        [TestMethod]
        public void Validate()
        {
            // Arrange
            object[,] pairs =
            {
                {
                    new Student
                    {
                        FirstName = "Kennith",
                        LastName = "Rusch",
                        DoB = DateTime.Parse("1987-12-11"),
                        Gender = Gender.Male,
                    }, true
                },
                {
                    new Student
                    {
                        FirstName = "Raise",
                        LastName = "Padgett",
                        DoB = DateTime.Parse("1989-1-11"),
                        Gender = Gender.Female,
                    }, false

                },
                {
                    new Student
                    {
                        FirstName = "Retha",
                        LastName = "Segars",
                        DoB = DateTime.Parse("1973-6-12"),
                        Gender = Gender.Female,
                    }, false
                },
                {
                    new Student
                    {
                        FirstName = "Wilbert",
                        LastName = "Fava",
                        DoB = DateTime.Parse("1982-1-11"),
                        Gender = Gender.Male,
                    }, true
                },
                {
                    new Student
                    {
                        FirstName = "Marleen",
                        LastName = "Bashir",
                        DoB = DateTime.Parse("1989-9-21"),
                        Gender = Gender.Male,
                    },true
                },
                {
                    new Student
                    {
                        FirstName = "Marybeth",
                        LastName = "Graziano",
                        DoB = DateTime.Parse("1989-1-11"),
                        Gender = Gender.Female,
                    }, false
                }
                ,
                {
                    new Student
                    {
                        FirstName = "Misti",
                        LastName = "Witte",
                        DoB = DateTime.Parse("1989-1-11"),
                        Gender = Gender.Female,
                    }, false
                }
            };

            GenderValidationRule rule = new GenderValidationRule();

            for (int i = 0; i < pairs.GetLength(0); i++)
            {
                Student student = (Student)pairs[i, 0];
                bool expected = (bool)pairs[i, 1];

                // Act
                bool actual = rule.Validate(student);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
