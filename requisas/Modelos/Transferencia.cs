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
        private string? _sucursalPrecedencia;
        private string? _sucursalTransferida;
        private string? _creadoPor;
        private string? _modificadoPor;
        private DateTime? _fechaCreacion;
        private DateTime? _fechaModificacion;

        #region constructores
        public Transferencia() { }

        public Transferencia(int? idTransferencia, string? sucursalPrecedencia, string? sucursalTransferida, string? creadoPor, string? modificadoPor, DateTime? fechaCreacion, DateTime? fechaModificacion)
        {
            _idTransferencia = idTransferencia;
            _sucursalPrecedencia = sucursalPrecedencia;
            _sucursalTransferida = sucursalTransferida;
            _creadoPor = creadoPor;
            _modificadoPor = modificadoPor;
            _fechaCreacion = fechaCreacion;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int? IdTransferencia { get => _idTransferencia; set => _idTransferencia = value; }
        public string? SucursalPrecedencia { get => _sucursalPrecedencia; set => _sucursalPrecedencia = value; }
        public string? SucursalTransferida { get => _sucursalTransferida; set => _sucursalTransferida = value; }
        public string? CreadoPor { get => _creadoPor; set => _creadoPor = value; }
        public string? ModificadoPor { get => _modificadoPor; set => _modificadoPor = value; }
        public DateTime? FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public DateTime? FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        public override string ToString()
        {
            return $"Se transfiere de sucursal {_sucursalPrecedencia} a {_sucursalTransferida}";
        }

        #region Builder Pattern
        public class Builder
        {
            private int? _idTransferencia;
            private string? _sucursalPrecedencia;
            private string? _sucursalTransferida;
            private string? _creadoPor;
            private string? _modificadoPor;
            private DateTime? _fechaCreacion;
            private DateTime? _fechaModificacion;

            public Builder? SetIdTransferencia(int? idTransferencia)
            {
                _idTransferencia = idTransferencia;
                return this;
            }
            public Builder SetSucursalPrecedencia(string? SucursalPrecedencia)
            {
                _sucursalPrecedencia = SucursalPrecedencia;
                return this;
            }
            public Builder SetSucursalTransferida(string? sucursalTransferida)
            {
                _sucursalTransferida = sucursalTransferida;
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
                return new Transferencia(_idTransferencia, _sucursalPrecedencia, _sucursalTransferida, _creadoPor, _modificadoPor, _fechaCreacion, _fechaModificacion);
            }
        }
        #endregion|
    }
}
