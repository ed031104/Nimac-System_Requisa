using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.requisas
{
    public class Requisa
    {
        private string _nDocumentoRequisa;
        private DateTime _fechaRegistro;
        private string _descripcion;
        bool estado;
        private Sucursal _sucursal;

        #region constructor
        public Requisa()
        {
        }
        public Requisa(string nDocumentoRequisa, DateTime fechaRegistro, string descripcion, Sucursal sucursal, bool estado)
        {
            _nDocumentoRequisa = nDocumentoRequisa;
            _fechaRegistro = fechaRegistro;
            _descripcion = descripcion;
            _sucursal = sucursal;
            this.estado = estado;
        }
        #endregion

        public string NDocumentoRequisa { get => _nDocumentoRequisa; set => _nDocumentoRequisa = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public Sucursal Sucursal { get => _sucursal ; set => _sucursal = value; }
        public bool Estado { get => estado; set => estado = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly Requisa _requisa;
            public Builder()
            {
                _requisa = new Requisa();
            }
            public Builder SetNDocumentoRequisa(string nDocumento)
            {
                _requisa._nDocumentoRequisa = nDocumento;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fecha)
            {
                _requisa._fechaRegistro = fecha;
                return this;
            }
            public Builder SetDescripcion(string descripcion)
            {
                _requisa._descripcion = descripcion;
                return this;
            }
            public Builder SetSucursal(Sucursal sucursal)
            {
                _requisa._sucursal = sucursal;
                return this;
            }
            public Builder SetEstado(bool estado)
            {
                _requisa.estado = estado;
                return this;
            }
            public Requisa Build()
            {
                return _requisa;
            }
        }
        #endregion

    }
}
