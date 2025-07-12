using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class TipoAjuste
    {
        private int? _tipoAjuste;
        private string _descripcion;
        private string _simboloTipoAjuste;
        private DateTime _fechaRegistro;
        private DateTime _fechaModificacion;

        #region constructor
        public TipoAjuste() 
        {
        }
        public TipoAjuste(int? tipoAjuste, string descripcion, string simboloTipoAjuste, DateTime fechaRegistro, DateTime fechaModificacion)
        {
            _tipoAjuste = tipoAjuste;
            _descripcion = descripcion;
            _simboloTipoAjuste = simboloTipoAjuste;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
        }
        #endregion
        
        public int? TipoAjusteId { get => _tipoAjuste; set => _tipoAjuste = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string SimboloTipoAjuste { get => _simboloTipoAjuste; set => _simboloTipoAjuste = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        public override string ToString()
        {
            return $"{Descripcion} ({SimboloTipoAjuste})";
        }

        #region Builder Pattern
        public class Builder
        {
            private readonly TipoAjuste _tipoAjuste;
            public Builder()
            {
                _tipoAjuste = new TipoAjuste();
            }
            public Builder SetTipoAjusteId(int? id)
            {
                _tipoAjuste._tipoAjuste = id;
                return this;
            }
            public Builder SetDescripcion(string descripcion)
            {
                _tipoAjuste._descripcion = descripcion;
                return this;
            }
            public Builder SetSimboloTipoAjuste(string simbolo)
            {
                _tipoAjuste._simboloTipoAjuste = simbolo;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fecha)
            {
                _tipoAjuste._fechaRegistro = fecha;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fecha)
            {
                _tipoAjuste._fechaModificacion = fecha;
                return this;
            }
            public TipoAjuste Build()
            {
                return _tipoAjuste;
            }
        }
        #endregion
    }
}
