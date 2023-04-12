using System;

namespace RefactoringChallenge.Exceptions
{
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message)
        { }
    }
}

