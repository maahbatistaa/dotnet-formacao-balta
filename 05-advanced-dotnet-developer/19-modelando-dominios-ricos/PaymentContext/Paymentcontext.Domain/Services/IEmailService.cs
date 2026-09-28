using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentcontext.Domain.Services
{
    public interface IEmailService
    {
        void Send(string to, string email, string subject, string body);
    }
}