using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Articulos
    {
        private int? _idArticulo;
        private string _codigoArticulo;
        private string _descripcion;
        private string _unidadMedida;
        private string _categoria;
        private decimal _precioUnitario;
        private string _proveedor;
        private DateTime _fechaRegistro;
        private DateTime _fechaModificacion;

        #region constructor
        public Articulos() 
        { 
        }

        public Articulos(int? idArticulo, string codigoArticulo, string descripcion, string unidadMedida, string categoria, decimal precioUnitario, string proveedor, DateTime fechaRegistro, DateTime fechaModificacion)
        {
            _idArticulo = idArticulo;
            _codigoArticulo = codigoArticulo;
            _descripcion = descripcion;
            _unidadMedida = unidadMedida;
            _categoria = categoria;
            _precioUnitario = precioUnitario;
            _proveedor = proveedor;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int? IdArticulo { get => _idArticulo; set => _idArticulo = value;}
        public string CodigoArticulo { get => _codigoArticulo; set => _codigoArticulo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string UnidadMedida { get => _unidadMedida; set => _unidadMedida = value; }
        public string Categoria { get => _categoria; set => _categoria = value; }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public string Proveedor { get => _proveedor; set => _proveedor = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly Articulos _articulos;

            public Builder()
            {
                _articulos = new Articulos();
            }
            public Builder SetIdArticulo(int id)
            {
                _articulos._idArticulo = id; 
                return this;
            }
            public Builder SetCodigoArticulo(string codigo)
            {
                _articulos._codigoArticulo = codigo; 
                return this;
            }
            public Builder SetDescripcion(string descripcion)
            {
                _articulos._descripcion = descripcion; 
                return this;
            }
            public Builder SetUnidadMedida(string unidad)
            {
                _articulos._unidadMedida = unidad; 
                return this;
            }
            public Builder SetCategoria(string categoria)
            {
                _articulos._categoria = categoria; 
                return this;
            }
            public Builder SetPrecioUnitario(decimal precio)
            {
                _articulos._precioUnitario = precio; 
                return this;
            }
            public Builder SetProveedor(string proveedor)
            {
                _articulos._proveedor = proveedor; 
                return this;
            }
            public Builder SetFechaRegistro(DateTime fechaRegistro)
            {
                _articulos._fechaRegistro = fechaRegistro; 
                return this;
            }
            public Builder SetFechaModificacion(DateTime fechaModificacion)
            {
                _articulos._fechaModificacion = fechaModificacion; 
                return this;
            }
            public Articulos Build()
            {
                return _articulos;
            }
        }
        #endregion
    }
}
