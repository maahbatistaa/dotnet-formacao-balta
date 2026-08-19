using System.Security.Cryptography;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
  [TestMethod]
  public void AdicionarAssinatura()
  {
    var subscription = new Subscription(null);
    var student = new Student("André", "Baltieri", "12345678909", "andre@balta.io");
    student.AddSubscription(subscription);
  }
}
