using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paymentcontext.Domain.Entities;

namespace Paymentcontext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssiantura()
        {
            var subscription = new Subscription(null);
            var student = new Student("Mariana", "Batista", "12345678912", "mariana@batista.com");
            student.AddSubscription(subscription);
        }
    }
}