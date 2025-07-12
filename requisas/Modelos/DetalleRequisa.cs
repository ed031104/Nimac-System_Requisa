using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleRequisa
    {
        private int? idDetalleRequisa;
        private ParteSucursal ParteSucursal;
        private int? cantidadAjuste;
        private DateTime fechaRegistro;

        #region constructor
        public DetalleRequisa()
        {
        }

        public DetalleRequisa(int? idDetalleRequisa, ParteSucursal parteSucursal, int? cantidadAjuste, DateTime fechaRegistro)
        {
            this.idDetalleRequisa = idDetalleRequisa;
            this.ParteSucursal = parteSucursal;
            this.cantidadAjuste = cantidadAjuste;
            this.fechaRegistro = fechaRegistro;
        }
        #endregion

        public int? IdDetalleRequisa { get => idDetalleRequisa; set => idDetalleRequisa = value; }
        public ParteSucursal IdParteCasa { get => ParteSucursal; set => ParteSucursal = value; }
        public int? CantidadAjuste { get => cantidadAjuste; set => cantidadAjuste = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly DetalleRequisa _detalleRequisa;
            public Builder()
            {
                _detalleRequisa = new DetalleRequisa();
            }
            public Builder SetIdDetalleRequisa(int id)
            {
                _detalleRequisa.idDetalleRequisa = id;
                return this;
            }
            public Builder SetIdParteSucursal(ParteSucursal parteSucursal)
            {
                _detalleRequisa.ParteSucursal = parteSucursal;
                return this;
            }
            public Builder SetCantidadAjuste(int? cantidad)
            {
                _detalleRequisa.cantidadAjuste = cantidad;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fecha)
            {
                _detalleRequisa.fechaRegistro = fecha;
                return this;
            }
            public DetalleRequisa Build()
            {
                return _detalleRequisa;
            }
        }
        #endregion
    }
}
