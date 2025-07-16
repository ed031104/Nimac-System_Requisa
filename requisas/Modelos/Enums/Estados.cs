using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Enums
{
    public enum Estados
    {
        CREADA = 4,
        PENDIENTE_A_REVISION = 5,
        PENDIENTE_A_APROBACION_1 = 6,
        PENDIENTE_A_APROBACION_2 = 7,
        PENDIENTE_A_APLICAR = 8,
        APLICADA = 9,
        RECHAZADA = 10
    }
}
