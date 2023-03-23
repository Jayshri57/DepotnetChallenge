using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringChallenge.Domain.Entities
{
    public class RequestError
    {
        public string Message { get; set; } = "";
        public int ResponseCode { get; set; }
    }
}
