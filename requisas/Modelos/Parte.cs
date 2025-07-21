using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Parte
    {
        private string _numeroParte;
        private string _descripcionParte;
        private DateTime _fechaRegistro;
        private DateTime _fechaModificacion;

        #region constructor
        public Parte() 
        {
        }
        public Parte(string numeroParte, string descripcionParte, DateTime fechaRegistro, DateTime fechaModificacion)
        {
            _numeroParte = numeroParte;
            _descripcionParte = descripcionParte;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public string NumeroParte { get => _numeroParte; set => _numeroParte = value; }
        public string DescripcionParte { get => _descripcionParte; set => _descripcionParte = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        public override string ToString()
        {
            return NumeroParte;
        }

        #region Builder Pattern
        public class Builder
        {
            private readonly Parte _parte;
            public Builder()
            {
                _parte = new Parte();
            }
            public Builder SetNumeroParte(string numero)
            {
                _parte._numeroParte = numero;
                return this;
            }
            public Builder SetDescripcionParte(string descripcion)
            {
                _parte._descripcionParte = descripcion;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fecha)
            {
                _parte._fechaRegistro = fecha;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fecha)
            {
                _parte._fechaModificacion = fecha;
                return this;
            }
            public Parte Build()
            {
                return _parte;
            }
        }
        #endregion
    }
}
