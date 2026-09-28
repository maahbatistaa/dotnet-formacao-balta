using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paymentcontext.Shared.Commands;

namespace Paymentcontext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}