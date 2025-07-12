using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.data
{
    public enum TypeError
    {
        None = 0,
        NotFound = 1,
        BadRequest = 2,
        Unauthorized = 3,
        Forbidden = 4,
        InternalServerError = 5,
        ServiceUnavailable = 6,
        Conflict = 7,
        UnprocessableEntity = 8
    }
}
