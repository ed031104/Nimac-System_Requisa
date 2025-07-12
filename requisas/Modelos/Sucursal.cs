using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Sucursal
    {
        private string _numeroSucursal;
        private string _nombreSucursal;
        private DateTime _fechaRegistro;
        private DateTime _fechaModificacion;
        private Casa _casa;

        #region constructor
        public Sucursal() 
        {
        }
        public Sucursal(string numeroSucursal, string nombreSucursal, DateTime fechaRegistro, DateTime fechaModificacion, Casa casa)
        {
            _numeroSucursal = numeroSucursal;
            _nombreSucursal = nombreSucursal;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
            _casa = casa;
        }
        #endregion

        public string NumeroSucursal { get => _numeroSucursal; set => _numeroSucursal = value; }
        public string NombreSucursal { get => _nombreSucursal; set => _nombreSucursal = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }
        public Casa Casa { get => _casa; set => _casa = value; }

        public override string ToString()
        {
            return NombreSucursal;
        }

        #region Builder Pattern
        public class Builder
        {
            private readonly Sucursal _sucursal;
            public Builder()
            {
                _sucursal = new Sucursal();
            }
            public Builder SetNumeroSucursal(string numero)
            {
                _sucursal._numeroSucursal = numero;
                return this;
            }
            public Builder SetNombreSucursal(string nombre)
            {
                _sucursal._nombreSucursal = nombre;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fecha)
            {
                _sucursal._fechaRegistro = fecha;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fecha)
            {
                _sucursal._fechaModificacion = fecha;
                return this;
            }
            public Builder SetCasa(Casa casa)
            {
                _sucursal._casa = casa;
                return this;
            }
            public Sucursal Build()
            {
                return _sucursal;
            }
        }
        #endregion
    }
}
