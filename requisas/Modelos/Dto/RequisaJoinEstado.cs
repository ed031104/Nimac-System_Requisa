using Modelos.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
    public class RequisaJoinEstado
    {
        public string CodigoRequisa { get; set; }
        public string descripcionRequisa { get; set; }
        public string Usuario { get; set; }
        public int cantidadAjuste { get; set; }
        public decimal costoTotal { get; set; }
        public Estado EstadoRequisa { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return CodigoRequisa;
        }
        
        #region constructors
        public RequisaJoinEstado() { }

        public RequisaJoinEstado(string codigoRequisa, string usuario, int cantidadAjuste, decimal costoTotal, Estado EstadoRequisa, DateTime fechaCreacion)
        {
            CodigoRequisa = codigoRequisa;
            Usuario = usuario;
            this.cantidadAjuste = cantidadAjuste;
            this.costoTotal = costoTotal;
            this.EstadoRequisa = EstadoRequisa;
            FechaCreacion = fechaCreacion;
        }
        #endregion

        #region builder
        public class Builder
        {
            private readonly RequisaJoinEstado _requisaJoinEstado;
            public Builder()
            {
                _requisaJoinEstado = new RequisaJoinEstado();
            }
            public Builder SetDescripcionRequisa(string descripcionRequisa)
            {
                _requisaJoinEstado.descripcionRequisa = descripcionRequisa;
                return this;
            }
            public Builder SetCodigoRequisa(string codigoRequisa)
            {
                _requisaJoinEstado.CodigoRequisa = codigoRequisa;
                return this;
            }
            public Builder SetUsuario(string usuario)
            {
                _requisaJoinEstado.Usuario = usuario;
                return this;
            }
            public Builder SetCantidadAjuste(int cantidadAjuste)
            {
                _requisaJoinEstado.cantidadAjuste = cantidadAjuste;
                return this;
            }
            public Builder SetCostoTotal(decimal costoTotal)
            {
                _requisaJoinEstado.costoTotal = costoTotal;
                return this;
            }
            public Builder SetEstadoRequisa(Estado estadoRequisa)
            {
                _requisaJoinEstado.EstadoRequisa = estadoRequisa;
                return this;
            }
            public Builder SetFechaCreacion(DateTime fechaCreacion)
            {
                _requisaJoinEstado.FechaCreacion = fechaCreacion;
                return this;
            }
            public RequisaJoinEstado Build()
            {
                return _requisaJoinEstado;
            }
        }
        #endregion
    }
}
