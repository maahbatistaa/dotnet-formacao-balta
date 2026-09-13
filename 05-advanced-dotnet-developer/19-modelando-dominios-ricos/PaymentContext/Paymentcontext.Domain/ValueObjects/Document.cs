using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paymentcontext.Domain.Enums;
using Paymentcontext.Shared.ValueObjects;

namespace Paymentcontext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}