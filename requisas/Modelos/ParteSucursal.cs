using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ParteSucursal
    {
        private int? _IdParteSucursal { get; set; }
        private Parte _parte { get; set; }
        private decimal _costoUnitario { get; set; }
        private int? _stock { get; set; }
        private DateTime _fechaRegistro { get; set; }
        private DateTime _fechaModificacion { get; set; }
        private Sucursal _sucursal { get; set; }

        #region constructor
        public ParteSucursal() 
        {
        }

        public ParteSucursal(int? idParteSucursal, Parte parte, Sucursal sucursal, decimal costoUnitario, int? stock, DateTime fechaRegistro, DateTime fechaModificacion)
        {
            _IdParteSucursal = idParteSucursal;
            _parte = parte;
            _sucursal = sucursal;    
            _costoUnitario = costoUnitario;
            _stock = stock;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int? IdParteSucursal { get => _IdParteSucursal; set => _IdParteSucursal = value; }
        public Parte Parte { get => _parte; set => _parte = value; }
        public Sucursal Sucursal { get => _sucursal; set => _sucursal  = value; }
        public decimal CostoUnitario { get => _costoUnitario; set => _costoUnitario = value; }
        public int? Stock { get => _stock; set => _stock = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly ParteSucursal _ParteSucursal;
            public Builder()
            {
                _ParteSucursal = new ParteSucursal();
            }
            public Builder SetIdParteSucursal(int? id)
            {
                _ParteSucursal._IdParteSucursal = id;
                return this;
            }
            public Builder SetParte(Parte parte)
            {
                _ParteSucursal._parte = parte;
                return this;
            }
            public Builder SetSucursal(Sucursal sucursal)
            {
                _ParteSucursal._sucursal = sucursal;
                return this;
            }
            public Builder SetCostoUnitario(decimal costo)
            {
                _ParteSucursal._costoUnitario = costo;
                return this;
            }
            public Builder SetCantidad(int? stock)
            {
                _ParteSucursal._stock = stock;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fecha)
            {
                _ParteSucursal._fechaRegistro = fecha;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fecha)
            {
                _ParteSucursal._fechaModificacion = fecha;
                return this;
            }
            public ParteSucursal Build()
            {
                return _ParteSucursal;
            }
        }
        #endregion
    }
}
