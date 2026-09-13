using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paymentcontext.Shared.ValueObjects;

namespace Paymentcontext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}