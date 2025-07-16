using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Casa
    {
        private string? _codigoCasa;
        private string? _nombreCasa;
        private DateTime? _fechaRegistro;
        private DateTime? _fechaModificacion;

        #region constructor
        public Casa() 
        {
        }

        public Casa(string? codigoCasa, string? nombreCasa, DateTime? fechaRegistro, DateTime? fechaModificacion)
        {
            _codigoCasa = codigoCasa;
            _nombreCasa = nombreCasa;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public string? CodigoCasa { get => _codigoCasa; set => _codigoCasa = value; }
        public string? NombreCasa { get => _nombreCasa; set => _nombreCasa = value; }
        public DateTime? FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime? FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        public override string ToString()
        {
            return NombreCasa + " - " + CodigoCasa;
        }

        #region Builder Pattern
        public class Builder
        {
            private readonly Casa? _casa;
            public Builder()
            {
                _casa = new Casa();
            }
            public Builder SetCodigoCasa(string? codigo)
            {
                _casa._codigoCasa = codigo; 
                return this;
            }
            public Builder SetNombreCasa(string? nombre)
            {
                _casa._nombreCasa = nombre; 
                return this;
            }
            public Builder SetFechaRegistro(DateTime? fecha)
            {
                _casa._fechaRegistro = fecha; 
                return this;
            }
            public Builder SetFechaModificacion(DateTime? fecha)
            {
                _casa._fechaModificacion = fecha; 
                return this;
            }
            
            public Casa Build()
            {
                return _casa;
            }
        }
        #endregion
    }
}
