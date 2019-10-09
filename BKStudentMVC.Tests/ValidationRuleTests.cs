using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLib.Models;
using BKStudentMVC.Services;

namespace BKStudentMVC.Tests
{
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
                    EntryScore=7.5f,
                }, false),
                (new Student()
                {
                    EntryScore=7.6f,
                }, true),
                (new Student()
                {
                    EntryScore=0,
                }, false),
                (new Student()
                {
                    EntryScore=9.2f,
                }, true),
                (new Student()
                {
                    EntryScore=7.4f,
                }, false),
                (new Student()
                {
                    EntryScore=8f,
                }, true),
            };

            // Act
            foreach (var pair in pairs)
            {
                var student = pair.student;
                var expected = pair.expected;

                var actual = validator.Validate(student);
                Console.WriteLine(student);
                Console.WriteLine($"expected: {expected}, actual: {actual}");

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
