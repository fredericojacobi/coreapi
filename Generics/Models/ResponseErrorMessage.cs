using System;

namespace Generic.Models
{
    public class ResponseErrorMessage
    {
        private string Code;

        private DateTime Time;

        private string Message;

        private string StackTrace;

        private string InnerException;

        public static ResponseErrorMessage InternalServerError() => new() {Code = "500"};

        public static ResponseErrorMessage InternalServerError(string message) => new()
        {
            Code = "500",
            Time = DateTime.Now,
            Message = message
        };

        public static ResponseErrorMessage InternalServerError(Exception e) => new()
        {
            Code = "500",
            Message = e.Message,
            StackTrace = e.StackTrace,
            InnerException = $"{e.InnerException?.Message.Substring(0, 600)} See logfiles for more details.",
            Time = DateTime.Now
        };

        public static ResponseErrorMessage NotFound() => new() {Code = "404"};

        public static ResponseErrorMessage NotFound(Exception e) => new()
        {
            Code = "404",
            Message = e.Message,
            StackTrace = e.StackTrace,
            InnerException = e.InnerException?.Message,
            Time = DateTime.Now
        };

        public static ResponseErrorMessage WrongBodyContent() => new()
        {
            Code = "400",
            Message = "Wrong body content.",
            Time = DateTime.Now
        };
    }
}