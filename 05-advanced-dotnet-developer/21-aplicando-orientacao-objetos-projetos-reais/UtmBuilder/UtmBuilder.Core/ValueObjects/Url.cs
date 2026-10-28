using System;
using System.Collections.Generic;
using System.Text;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        public Url(string address)
        {
            Address = address;
        }
        public string Address { get; }
    }
}
