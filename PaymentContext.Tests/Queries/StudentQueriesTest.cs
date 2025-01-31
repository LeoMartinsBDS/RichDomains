using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQuerieTests
    {
        private IList<Student> _students;

        public StudentQuerieTests()
        {
            for(var i = 0; i <= 10; i++){
                _students.Add(new Student(
                new Name("Aluno", i.ToString()),
                new Document("1111111111" + i.ToString(), EDocumentType.CPF), 
                new Email(i.ToString() + "@balta.io")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("1234567891011");
            var stnd = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, stnd);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("1111111111");
            var stnd = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, stnd);
        }

    }

}