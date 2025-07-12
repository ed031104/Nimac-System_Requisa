using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.data
{
    public class DBOResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }

        public static DBOResponse<T> Ok(T data)
        {
            return new DBOResponse<T> { Data = data, Message = @"Se ejecutó correctamente la consulta", Success = true };
        }

        public static DBOResponse<T> Error(string message)
        {
            return new DBOResponse<T> { Message = message, Success = false };
        }
    }
}
