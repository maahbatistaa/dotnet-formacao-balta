using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paymentcontext.Shared.Commands;

namespace Paymentcontext.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}