using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Documento
    {
        private int? _idDocumento;
        private string? _nombre;
        private byte[]? _documento;
        private string? _creadoPor;
        private string? _modificadoPor;
        private DateTime? _fechaCreacion;
        private DateTime? _fechaModificacion;

        #region constructores
        public Documento() { }

        public Documento(int? idDocumento, string? nombre, byte[]? documento, string? creadoPor, string? modificadoPor, DateTime? fechaCreacion, DateTime? fechaModificacion)
        {
            _idDocumento = idDocumento;
            _nombre = nombre;
            _documento = documento;
            _creadoPor = creadoPor;
            _modificadoPor = modificadoPor;
            _fechaCreacion = fechaCreacion;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int? IdDocumento { get => _idDocumento; set => _idDocumento = value; }
        public string? Nombre { get => _nombre; set => _nombre = value; }
        public byte[]? DocumentoBytes { get => _documento; set => _documento = value; }
        public string? CreadoPor { get => _creadoPor; set => _creadoPor = value; }
        public string? ModificadoPor { get => _modificadoPor; set => _modificadoPor = value; }
        public DateTime? FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public DateTime? FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        public override string ToString()
        {
            return Nombre ?? "Documento sin nombre";
        }

        #region Builder Pattern
        public class Builder
        {
            private int? _idDocumento;
            private string? _nombre;
            private byte[]? _documento;
            private string? _creadoPor;
            private string? _modificadoPor;
            private DateTime? _fechaCreacion;
            private DateTime? _fechaModificacion;
            public Builder? SetIdDocumento(int? idDocumento)
            {
                _idDocumento = idDocumento;
                return this;
            }
            public Builder SetNombre(string? nombre)
            {
                _nombre = nombre;
                return this;
            }
            public Builder SetDocumento(byte[]? documento)
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
            public Documento Build()
            {
                return new Documento(_idDocumento, _nombre, _documento, _creadoPor, _modificadoPor, _fechaCreacion, _fechaModificacion);
            }
        }
        #endregion
    }
}
