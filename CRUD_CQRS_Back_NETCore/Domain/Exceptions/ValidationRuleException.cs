using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ValidationRuleException : Exception
    {
        public string[] Errors { get; private set; }
        public ValidationRuleException(string[] errors, Exception inner = null) : base("Um ou Mais erros", inner)
        {
            Errors = errors;
        }
    }
}
