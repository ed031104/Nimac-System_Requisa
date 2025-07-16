using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Estado
    {
        private int _idEstado;
        private string _descripcion;
        private DateTime _fechaRegistro;
        private DateTime _fechaModificacion;
        private string _creadoPor;


        #region Constructor
        public Estado()
        {
        }
        public Estado(int idEstado, string descripcion, DateTime fechaRegistro, DateTime fechaModificacion, string creadoPor)
        {
            _idEstado = idEstado;
            _descripcion = descripcion;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
            _creadoPor = creadoPor;
        }
        #endregion

        public int IdEstado { get => _idEstado; set => _idEstado = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }
        public string CreadoPor { get => _creadoPor; set => _creadoPor = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly Estado _estado;
            public Builder()
            {
                _estado = new Estado();
            }
            public Builder SetIdEstado(int idEstado)
            {
                _estado._idEstado = idEstado;
                return this;
            }
            public Builder SetDescripcion(string descripcion)
            {
                _estado._descripcion = descripcion;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fechaRegistro)
            {
                _estado._fechaRegistro = fechaRegistro;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fechaModificacion)
            {
                _estado._fechaModificacion = fechaModificacion;
                return this;
            }
            public Builder SetCreadoPor(string creadoPor)
            {
                _estado._creadoPor = creadoPor;
                return this;
            }
            public Estado Build()
            {
                return _estado;
            }
        }
        #endregion
        
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
