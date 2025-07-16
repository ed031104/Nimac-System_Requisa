using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.requisas
{
    public class RequisaEstado
    {
        int _idEstadoRequisa;
        Requisa _requisa;
        Estado _estado;
        string _creadoPor;
        string _modificadoPor;
        DateTime _fechaCreacion;
        DateTime _fechaModificacion;

        #region constructor
        public RequisaEstado()
        {
        }

        public RequisaEstado(int idEstadoRequisa, Requisa requisa, Estado estado, string creadoPor, string modificadoPor, DateTime fechaCreacion, DateTime fechaModificacion)
        {
            _idEstadoRequisa = idEstadoRequisa;
            _requisa = requisa;
            _estado = estado;
            _creadoPor = creadoPor;
            _modificadoPor = modificadoPor;
            _fechaCreacion = fechaCreacion;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int IdEstadoRequisa { get => _idEstadoRequisa; set => _idEstadoRequisa = value; }
        public Requisa Requisa { get => _requisa; set => _requisa = value; }
        public Estado Estado { get => _estado; set => _estado = value; }
        public string CreadoPor { get => _creadoPor; set => _creadoPor = value; }
        public string ModificadoPor { get => _modificadoPor; set => _modificadoPor = value; }
        public DateTime FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly RequisaEstado _requisaEstado;
            public Builder()
            {
                _requisaEstado = new RequisaEstado();
            }
            public Builder SetIdEstadoRequisa(int idEstadoRequisa)
            {
                _requisaEstado._idEstadoRequisa = idEstadoRequisa;
                return this;
            }
            public Builder SetRequisa(Requisa requisa)
            {
                _requisaEstado._requisa = requisa;
                return this;
            }
            public Builder SetEstado(Estado estado)
            {
                _requisaEstado._estado = estado;
                return this;
            }
            public Builder SetCreadoPor(string creadoPor)
            {
                _requisaEstado._creadoPor = creadoPor;
                return this;
            }
            public Builder SetModificadoPor(string modificadoPor)
            {
                _requisaEstado._modificadoPor = modificadoPor;
                return this;
            }
            public Builder SetFechaCreacion(DateTime fechaCreacion)
            {
                _requisaEstado._fechaCreacion = fechaCreacion;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fechaModificacion)
            {
                _requisaEstado._fechaModificacion = fechaModificacion;
                return this;
            }
            public RequisaEstado Build()
            {
                return _requisaEstado;
            }
        }
        #endregion
        
        public override string ToString()
        {
            return Requisa.NDocumentoRequisa + " - " + Estado.Descripcion ;
        }
    }
}
