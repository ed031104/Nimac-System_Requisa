using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class StockArticuloCasa
    {
        private int? _idStock;
        private Articulos _articulo;
        private Casa _casa;
        private int? _cantidad;
        private DateTime _fechaRegistro;
        private DateTime _fechaModificacion;

        #region constructor
        public StockArticuloCasa()
        {
        }
        public StockArticuloCasa(int? idStock, Articulos articulo, Casa casa, int? cantidad, DateTime fechaRegistro, DateTime fechaModificacion)
        {
            _idStock = idStock;
            _articulo = articulo;
            _casa = casa;
            _cantidad = cantidad;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int? IdStock { get => _idStock; set => _idStock = value; }
        public Articulos Articulo { get => _articulo; set => _articulo = value; }
        public Casa Casa { get => _casa; set => _casa = value; }
        public int? Cantidad { get => _cantidad; set => _cantidad = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly StockArticuloCasa _stockArticuloCasa;
            public Builder()
            {
                _stockArticuloCasa = new StockArticuloCasa();
            }
            public Builder SetIdStock(int? id)
            {
                _stockArticuloCasa._idStock = id;
                return this;
            }
            public Builder SetArticulo(Articulos articulo)
            {
                _stockArticuloCasa._articulo = articulo;
                return this;
            }
            public Builder SetCasa(Casa casa)
            {
                _stockArticuloCasa._casa = casa;
                return this;
            }
            public Builder SetCantidad(int? cantidad)
            {
                _stockArticuloCasa._cantidad = cantidad;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fecha)
            {
                _stockArticuloCasa._fechaRegistro = fecha;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fecha)
            {
                _stockArticuloCasa._fechaModificacion = fecha;
                return this;
            }
            public StockArticuloCasa Build()
            {
                return _stockArticuloCasa;
            }
        }
        #endregion
    }
}
