using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Transferencia
    {
        private int? _idTransferencia;
        private Sucursal? _Sucursal;
        private Casa? _casa;
        private string? _creadoPor;
        private string? _modificadoPor;
        private DateTime? _fechaCreacion;
        private DateTime? _fechaModificacion;

        #region constructores
        public Transferencia() { }

        public Transferencia(int? idTransferencia, Sucursal? idSucursal, Casa? casa, string? creadoPor, string? modificadoPor, DateTime? fechaCreacion, DateTime? fechaModificacion)
        {
            _idTransferencia = idTransferencia;
            _Sucursal = idSucursal;
            _casa = casa;
            _creadoPor = creadoPor;
            _modificadoPor = modificadoPor;
            _fechaCreacion = fechaCreacion;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int? IdTransferencia { get => _idTransferencia; set => _idTransferencia = value; }
        public Sucursal? Sucursal { get => _Sucursal; set => _Sucursal = value; }
        public Casa? Casa { get => _casa; set => _casa = value; }
        public string? CreadoPor { get => _creadoPor; set => _creadoPor = value; }
        public string? ModificadoPor { get => _modificadoPor; set => _modificadoPor = value; }
        public DateTime? FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public DateTime? FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        public override string ToString()
        {
            return $"Transferencia ID: {IdTransferencia}, Sucursal: {Sucursal}, Casa: {Casa}";
        }

        #region Builder Pattern
        public class Builder
        {
            private int? _idTransferencia;
            private Sucursal? _sucursal;
            private Casa? _casa;
            private string? _creadoPor;
            private string? _modificadoPor;
            private DateTime? _fechaCreacion;
            private DateTime? _fechaModificacion;

            public Builder? SetIdTransferencia(int? idTransferencia)
            {
                _idTransferencia = idTransferencia;
                return this;
            }
            public Builder SetSucursal(Sucursal? Sucursal)
            {
                _sucursal = Sucursal;
                return this;
            }
            public Builder SetCasa(Casa? casa)
            {
                _casa = casa;
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
            public Transferencia Build()
            {
                return new Transferencia(_idTransferencia, _sucursal, _casa, _creadoPor, _modificadoPor, _fechaCreacion, _fechaModificacion);
            }
        }
        #endregion|
    }
}
