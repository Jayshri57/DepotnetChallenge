using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefactoringChallenge.Domain.Entities;
using System;

namespace RefactoringChallenge.Utils
{
    public static class ApplicationUtils
    {
        private const string ErrorMessage = "Failed to perform operation. Please try again and contact support team if problem remain persists.";

        public static string CrlfCheck(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            return input.Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "").Replace(" ", "").Trim();
        }

        public static IActionResult ReturnFailureResult(int statusCodes, string message = ErrorMessage)
        {
            var responseError = new RequestError
            {
                Message = message,
                ResponseCode = statusCodes
            };
            return new ObjectResult(responseError)
            {
                StatusCode = statusCodes
            };
        }

        public static DateTime? CompareTo(DateTime? date1, DateTime? date2)
        {
            if (!date1.HasValue) return date2;
            if (!date2.HasValue) return date1;

            var result = DateTime.Compare(date1.Value, date2.Value);

            return result <= 0 ? date2 : date1;
        }
    }
}
