using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.login
{
    public class Role
    {
        private int _idRole;
        private string _nombreRol;
        private string _descripcion;

        #region constructor
        public Role() 
        {
        }
        public Role(int idRole, string nombreRol, string descripcion)
        {
            _idRole = idRole;
            _nombreRol = nombreRol;
            _descripcion = descripcion;
        }
        #endregion

        public int IdRole { get => _idRole; set => _idRole = value; }
        public string NombreRol { get => _nombreRol; set => _nombreRol = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public override string ToString()
        {
            return NombreRol;
        }

        #region Builder Pattern
        public class Builder
        {
            private readonly Role _role;
            public Builder()
            {
                _role = new Role();
            }
            public Builder SetIdRole(int id)
            {
                _role._idRole = id;
                return this;
            }
            public Builder SetNombreRol(string nombre)
            {
                _role._nombreRol = nombre;
                return this;
            }
            public Builder SetDescripcion(string descripcion)
            {
                _role._descripcion = descripcion;
                return this;
            }
            public Role Build()
            {
                return _role;
            }
        }
        #endregion
    }
}
