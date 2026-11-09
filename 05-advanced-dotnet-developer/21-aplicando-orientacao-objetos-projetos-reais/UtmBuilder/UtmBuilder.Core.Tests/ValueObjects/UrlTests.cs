using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        private const string InvalidUrl = "banana";
        private const string ValidUrl = "https://balta.io";

        [TestMethod]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {
            Assert.ThrowsExactly<InvalidUrlException>(() =>
            {
                new Url(InvalidUrl);
            });
        }

        [TestMethod]
        public void ShouldNoReturnExceptionWhenUrlIsValid()
        {
            new Url(ValidUrl);
            Assert.IsTrue(true);
        }

        [TestMethod]
        [DataRow("  ", true)]
        [DataRow("http", true)]
        [DataRow("banana", true)]
        [DataRow("https://balta.io", false)]
        public void TestUrl(string link, bool expectExpection)
        {
            if (expectExpection)
            {
                try
                {
                    new Url(link);
                    Assert.Fail();
                }
                catch (InvalidUrlException e)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                new Url(link);
                Assert.IsTrue(true);
            }
        }
    }
}