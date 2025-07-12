using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.login
{
    public class UsuarioRol
    {
        private int _idUsuarioRol;
        private Usuario _usuario;
        private Role _rol;
        private DateTime _asignadoEn;

        #region constructor
        public UsuarioRol()
        {
        }
        public UsuarioRol(int idUsuarioRol ,Usuario usuario, Role rol, DateTime asignadoEn)
        {
            _usuario = usuario;
            _rol = rol;
            _asignadoEn = asignadoEn;
            _idUsuarioRol = idUsuarioRol;
        }
        #endregion

        public int IdUsuarioRol { get => _idUsuarioRol; set => _idUsuarioRol = value; }
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public Role Rol { get => _rol; set => _rol = value; }
        public DateTime AsignadoEn { get => _asignadoEn; set => _asignadoEn = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly UsuarioRol _usuarioRol;
            public Builder()
            {
                _usuarioRol = new UsuarioRol();
            }
            public Builder SetIdUsuarioRol(int idUsuarioRol)
            {
                _usuarioRol._idUsuarioRol = idUsuarioRol;
                return this;
            }
            public Builder SetUsuario(Usuario usuario)
            {
                _usuarioRol._usuario = usuario;
                return this;
            }
            public Builder SetRol(Role rol)
            {
                _usuarioRol._rol = rol;
                return this;
            }
            public Builder SetAsignadoEn(DateTime asignadoEn)
            {
                _usuarioRol._asignadoEn = asignadoEn;
                return this;
            }
            public UsuarioRol Build()
            {
                return _usuarioRol;
            }
        }
        #endregion
    }
}
