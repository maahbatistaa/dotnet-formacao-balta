using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paymentcontext.Shared.ValueObjects;

namespace Paymentcontext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
                AddNotification("Nome.FirstName", "Nome invalido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}