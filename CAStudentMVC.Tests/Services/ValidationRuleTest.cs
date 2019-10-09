using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLib.Models;
using CAStudentMVC;
using CAStudentMVC.Services;
using CAStudentMVC.Models;

namespace CAStudentMVC.Tests
{
    [TestClass]
    public class HeightValidationRuleTest
    {
        [TestMethod]
        public void Validate()
        {
            var validator = new HeightValidationRule();
            // Arrange
            (Student student, bool expected)[] pairs =
            {
                (new Student()
                {
                }, false),
                (new CAStudent()
                {
                    Gender=Gender.Female,
                    Height=1.6f,
                    DoB=new DateTime(DateTime.Now.Year - 20, 12, 12),
                }, true),
                (new CAStudent()
                {
                    Gender=Gender.Female,
                    Height=1.6f,
                    DoB=new DateTime(DateTime.Now.Year - 21, 12, 12),
                }, false),
                (new CAStudent()
                {
                    Gender=Gender.Male,
                    Height=1.6f,
                    DoB=new DateTime(DateTime.Now.Year - 22, 12, 12),
                }, true),
                (new CAStudent()
                {
                    Gender=Gender.Male,
                    Height=1.65f,
                    DoB=new DateTime(DateTime.Now.Year - 23, 12, 12),
                }, false),
                (new CAStudent()
                {
                    Gender=Gender.Male,
                    Height=1.7f,
                    DoB=new DateTime(DateTime.Now.Year - 22, 12, 12),
                }, true),
            };

            // Act
            foreach (var pair in pairs)
            {
                var student = pair.student;
                var expected = pair.expected;
                Console.WriteLine(student);

                var actual = validator.Validate(student);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}