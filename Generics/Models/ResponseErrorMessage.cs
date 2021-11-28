using System;

namespace Generic.Models
{
    public class ResponseErrorMessage
    {
        private string Code;

        private string Message;

        private string StackTrace;

        private DateTime Time;

        public static ResponseErrorMessage InternalServerError() => new() {Code = "500"};
        
        public static ResponseErrorMessage InternalServerError(Exception e) => new()
        {
            Code = "500",
            Message = e.Message,
            StackTrace = e.StackTrace,
            Time = DateTime.Now
        };

        public static ResponseErrorMessage NotFound() => new() {Code = "404"};

        public static ResponseErrorMessage NotFound(Exception e) => new()
        {
            Code = "404",
            Message = e.Message,
            StackTrace = e.StackTrace,
            Time = DateTime.Now
        };
    }
}