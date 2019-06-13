using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2DChart.Helpers
{
    public class CommandResult  
    {
        private CommandResult() { }

        private CommandResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        public string FailureReason { get; }
        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public static CommandResult Success { get; } = new CommandResult();

        public static CommandResult Fail(string reason)
        {
            return new CommandResult(reason);
        }

        public static implicit operator bool(CommandResult result)
        {
            return result.IsSuccess;
        }
    }
}
