using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.data
{
    public static class ErrorServices
    {
        private static string error;

        public static string GetErrorMessage(TypeError typeError)
        {
            error = typeError switch
            {
                TypeError.NotFound => "Not Found",
                TypeError.BadRequest => "Bad Request",
                TypeError.Unauthorized => "Unauthorized",
                TypeError.Forbidden => "Forbidden",
                TypeError.InternalServerError => "Internal Server Error",
                TypeError.ServiceUnavailable => "Service Unavailable",
                TypeError.Conflict => "Conflict",
                TypeError.UnprocessableEntity => "Unprocessable Entity",
                _ => "Unknown Error"
            };

            return error;
        }


    }
}

