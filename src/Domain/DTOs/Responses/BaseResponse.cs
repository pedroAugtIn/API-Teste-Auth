using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses
{
    public class BaseResponse<T>(bool success, string message, object data,
        List<string>? erros = null)
    {
        public bool Success { get; set; } = success;
        public string Message { get; set; } = message;
        public List<string>? Errors { get; set; } = erros;
        public object Data { get; set; } = data;
    }
}