namespace Modelos.login
{
    public class Usuario
    {
        private int _id;
        private string _nombre;
        private string _CorreoElectronico;
        private string _contrasena;
        private DateTime _creadoEn;

        #region constructor
        public Usuario() 
        {
        }
        public Usuario(int id, string nombre, string correoElectronico, string contrasena, DateTime creadoEn)
        {
            _id = id;
            _nombre = nombre;
            _CorreoElectronico = correoElectronico;
            _contrasena = contrasena;
            _creadoEn = creadoEn;
        }
        #endregion

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string CorreoElectronico { get => _CorreoElectronico; set => _CorreoElectronico = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public DateTime CreadoEn { get => _creadoEn; set => _creadoEn = value; }

        public override string ToString()
        {
            return Nombre;
        }

        #region Builder Pattern
        public class Builder
        {
            private readonly Usuario _usuario;
            public Builder()
            {
                _usuario = new Usuario();
            }
            public Builder SetId(int id)
            {
                _usuario._id = id;
                return this;
            }
            public Builder SetNombre(string nombre)
            {
                _usuario._nombre = nombre;
                return this;
            }
            public Builder SetCorreoElectronico(string correo)
            {
                _usuario._CorreoElectronico = correo;
                return this;
            }
            public Builder SetContrasena(string contrasena)
            {
                _usuario._contrasena = contrasena;
                return this;
            }
            public Builder SetCreadoEn(DateTime creadoEn)
            {
                _usuario._creadoEn = creadoEn;
                return this;
            }
            public Usuario Build()
            {
                return _usuario;
            }
        }
        #endregion
    }
}
