using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10;
        }
    }
}