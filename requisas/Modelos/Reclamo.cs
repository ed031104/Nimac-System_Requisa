using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Reclamo
    {
        private int? _idReclamo;
        private string? _observacion;
        private Documento? Documento { get; set; }
        private string? _creadoPor;
        private string? _modificadoPor;
        private DateTime? _fechaCreacion;
        private DateTime? _fechaModificacion;

        #region constructores
        public Reclamo() { }

        public Reclamo(int? idReclamo, string? observacion, Documento? documento, string? creadoPor, string? modificadoPor, DateTime? fechaCreacion, DateTime? fechaModificacion)
        {
            _idReclamo = idReclamo;
            _observacion = observacion;
            Documento = documento;
            _creadoPor = creadoPor;
            _modificadoPor = modificadoPor;
            _fechaCreacion = fechaCreacion;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int? IdReclamo { get => _idReclamo; set => _idReclamo = value; }
        public string? Observacion { get => _observacion; set => _observacion = value; }
        public Documento? DocumentoReclamo { get => Documento; set => Documento = value; }
        public string? CreadoPor { get => _creadoPor; set => _creadoPor = value; }
        public string? ModificadoPor { get => _modificadoPor; set => _modificadoPor = value; }
        public DateTime? FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public DateTime? FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        public override string ToString()
        {
            return Observacion;
        }

        #region Builder Pattern
        public class Builder
        {
            private int? _idReclamo;
            private string? _observacion;
            private Documento? _documento;
            private string? _creadoPor;
            private string? _modificadoPor;
            private DateTime? _fechaCreacion;
            private DateTime? _fechaModificacion;
            public Builder? SetIdReclamo(int? idReclamo)
            {
                _idReclamo = idReclamo;
                return this;
            }
            public Builder SetObservacion(string observacion)
            {
                _observacion = observacion;
                return this;
            }
            public Builder SetDocumento(Documento? documento)
            {
                _documento = documento;
                return this;
            }
            public Builder SetCreadoPor(string? creadoPor)
            {
                _creadoPor = creadoPor;
                return this;
            }
            public Builder SetModificadoPor(string? modificadoPor)
            {
                _modificadoPor = modificadoPor;
                return this;
            }
            public Builder SetFechaCreacion(DateTime? fechaCreacion)
            {
                _fechaCreacion = fechaCreacion;
                return this;
            }
            public Builder SetFechaModificacion(DateTime? fechaModificacion)
            {
                _fechaModificacion = fechaModificacion;
                return this;
            }
            public Reclamo Build()
            {
                return new Reclamo(_idReclamo, _observacion, _documento, _creadoPor, _modificadoPor, _fechaCreacion, _fechaModificacion);
            }
        }
        #endregion
    }
}
