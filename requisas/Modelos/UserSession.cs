using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class UserSession
    {
        private static UserSession _instance;
        
        private int _id;
        private string _nombreUsuario;
        private string _correo;
        private int _idRol;
        private string _rol;

        public int ID { get => _id; set => _id = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Rol { get => _rol; set => _rol = value; }

        #region constructor
        private UserSession() { }
        #endregion

        #region functions
        public static UserSession Instance => _instance ??= new UserSession();

        public void CloseSession() {
            _instance = null;
        }
        #endregion

        #region Builder Parttern
        public class Builder {
            
            private int _id;
            private string _nombreUsuario;
            private string _correo;
            private int _idRol;
            private string _rol;
            
            public Builder SetId(int id) {
                _id = id;
                return this;
            }
            public Builder SetNombreUsuario(string nombreUsuario) {
                _nombreUsuario = nombreUsuario;
                return this;
            }
            public Builder SetCorreo(string correo) {
                _correo = correo;
                return this;
            }
            public Builder SetIdRol(int idRol) {
                _idRol = idRol;
                return this;
            }
            public Builder SetRol(string rol) {
                _rol = rol;
                return this;
            }
            public UserSession Build() {
                UserSession session = UserSession.Instance;
                session.ID = _id;
                session.NombreUsuario = _nombreUsuario;
                session.Correo = _correo;
                session.IdRol = _idRol;
                session.Rol = _rol;
                return session;
            }
        }
        #endregion
    }
}
