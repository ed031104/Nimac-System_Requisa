using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.requisas
{
    public class RequisaRechazada
    {
        private int _id;
        private string _numeroRequisa;
        private string _descripcion;
        private string _creadoPor;
        private string _modificadoPor;
        private DateTime _fechaCreacion;
        private DateTime _fechaModificacion;

        #region constructor
        public RequisaRechazada() { }

        public RequisaRechazada(int id, string numeroRequisa, string descripcion, string creadoPor, string modificadoPor, DateTime fechaCreacion, DateTime fechaModificacion)
        {
            _id = id;
            _numeroRequisa = numeroRequisa;
            _descripcion = descripcion;
            _creadoPor = creadoPor;
            _modificadoPor = modificadoPor;
            _fechaCreacion = fechaCreacion;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        public int Id { get => _id; set => _id = value; }
        public string NumeroRequisa { get => _numeroRequisa; set => _numeroRequisa = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string CreadoPor { get => _creadoPor; set => _creadoPor = value; }
        public string ModificadoPor { get => _modificadoPor; set => _modificadoPor = value; }
        public DateTime FechaCreacion { get => _fechaCreacion; set => _fechaCreacion = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }


        #region Builder Pattern

        public class Builder
        {
            private int _id;
            private string _numeroRequisa;
            private string _descripcion;
            private string _creadoPor;
            private string _modificadoPor;
            private DateTime _fechaCreacion;
            private DateTime _fechaModificacion;
            public Builder SetId(int id)
            {
                _id = id;
                return this;
            }
            public Builder SetNumeroRequisa(string numeroRequisa)
            {
                _numeroRequisa = numeroRequisa;
                return this;
            }
            public Builder SetDescripcion(string descripcion)
            {
                _descripcion = descripcion;
                return this;
            }
            public Builder SetCreadoPor(string creadoPor)
            {
                _creadoPor = creadoPor;
                return this;
            }
            public Builder SetModificadoPor(string modificadoPor)
            {
                _modificadoPor = modificadoPor;
                return this;
            }
            public Builder SetFechaCreacion(DateTime fechaCreacion)
            {
                _fechaCreacion = fechaCreacion;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fechaModificacion)
            {
                _fechaModificacion = fechaModificacion;
                return this;
            }
            public RequisaRechazada Build()
            {
                return new RequisaRechazada(_id, _numeroRequisa, _descripcion, _creadoPor, _modificadoPor, _fechaCreacion, _fechaModificacion);
            }
        }
        #endregion
    }
}
