using Paymentcontext.Domain.Enums;
using Paymentcontext.Domain.ValueObjects;

namespace Paymentcontext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("11308296000129", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataRow("29524495031")]
        [DataRow("24017335071")]
        [DataRow("35565668000")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}