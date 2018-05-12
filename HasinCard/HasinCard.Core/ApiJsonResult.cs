using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Core
{
    public class ApiJsonResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

        public static ApiJsonResult SuccessResult(string message = "", object data = null) => new ApiJsonResult()
        {
            IsSuccess = true,
            Message = message,
            Data = data
        };

        public static ApiJsonResult ErrorResult(string message = "", object data = null) => new ApiJsonResult()
        {
            IsSuccess = false,
            Message = message,
            Data = data
        };
    }
}
