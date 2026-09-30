using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paymentcontext.Domain.Entities;
using Paymentcontext.Domain.Enums;
using Paymentcontext.Domain.Queries;
using Paymentcontext.Domain.ValueObjects;

namespace Paymentcontext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        // Red, Green, Refactor
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();
            for (var i = 0; i <= 10; i++)
            {
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
            var exp = StudentQuerie.GetStudentInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }
    }
}