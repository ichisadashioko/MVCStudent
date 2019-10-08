using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLib.Models;
using FUStudentMVC;
using FUStudentMVC.Services;

namespace FUStudentMVC.Tests
{
    [TestClass]
    public class ForeignNameValidationRuleTest
    {
        [TestMethod]
        public void Validate()
        {
            var validator = new ForeignNameValidationRule();
            // Arrange
            (Student student, bool expected)[] pairs =
            {
                (new Student()
                {
                    FirstName="あかし",
                    LastName="とうや",
                }, true),
                (new Student()
                {
                    FirstName="Alex",
                    LastName="とうや",
                }, true),
                (new Student()
                {
                    FirstName="Edward12th",
                    LastName="Arthur",
                }, false),
                (new Student()
                {
                    FirstName="深雪",
                    LastName="四葉",
                }, true),
            };

            // Act
            foreach (var pair in pairs)
            {
                var student = pair.student;
                var expected = pair.expected;
                Console.WriteLine(student.FullName);

                var actual = validator.Validate(student);

                Assert.AreEqual(expected, actual);
            }
        }
    }
    [TestClass]
    public class EntryScoreValidationRuleTest
    {
        [TestMethod]
        public void Validate()
        {
            var validator = new EntryScoreValidationRule();
            // Arrange
            (Student student, bool expected)[] pairs =
            {
                (new Student()
                {
                    EntryScore=7.1f,
                }, true),
                (new Student()
                {
                    EntryScore=7.0f,
                }, false),
                (new Student()
                {
                    EntryScore=3.0f,
                }, false),
                (new Student()
                {
                    EntryScore=9.0f,
                }, true),
            };

            // Act
            foreach (var pair in pairs)
            {
                var student = pair.student;
                var expected = pair.expected;
                Console.WriteLine(student.EntryScore);

                var actual = validator.Validate(student);

                Assert.AreEqual(expected, actual);
            }
        }
    }
    [TestClass]
    public class BalanceValidationRuleTest
    {
        [TestMethod]
        public void Validate()
        {
            var validator = new BalanceValidationRule();
            // Arrange
            (Student student, bool expected)[] pairs =
            {
                (new Student()
                {
                    BankBalance=1_000_000_000m,
                }, true),
                (new Student()
                {
                    BankBalance=999_999_999m,
                }, false),
                (new Student()
                {
                    BankBalance=9_000_000m,
                }, false),
                (new Student()
                {
                    BankBalance=2_900_230_000m,
                }, true),
            };

            // Act
            foreach (var pair in pairs)
            {
                var student = pair.student;
                var expected = pair.expected;
                Console.WriteLine(student.EntryScore);

                var actual = validator.Validate(student);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}