using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;
using Paymentcontext.Shared.ValueObjects;

namespace Paymentcontext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "E-mail inválido")
            );
        }

        public string Address { get; private set; }
    }
}