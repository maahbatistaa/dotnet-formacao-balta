using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paymentcontext.Domain.Entities;
using Paymentcontext.Domain.Enums;
using Paymentcontext.Domain.ValueObjects;

namespace Paymentcontext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            _student = new Student(_name, _document, _email);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}