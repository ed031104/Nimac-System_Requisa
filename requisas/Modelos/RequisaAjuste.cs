using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class RequisaAjuste
    {
        private int _idRequisaAjuste;
        private Requisa _requisa;
        private TipoAjuste _tipoAjuste;
        private string _creadoPor;
        private string _modificadoPor;
        private DateTime _fechaRegistro;
        private DateTime _fechaModificacion;
        private decimal? _montoAjuste; // Nuevo campo para monto de ajuste
        private string _descripcion; // Nuevo campo para descripción del ajuste
        private ParteSucursal _parteSucursal; // Nuevo campo para parte de la sucursal
        private decimal _costoPromedio; // Nuevo campo para costo promedio
        private decimal _costoPromedioExtendido;

        #region Constructores

        public RequisaAjuste() { }

        public RequisaAjuste(int idRequisaAjuste, Requisa requisa, TipoAjuste tipoAjuste, string creadoPor, string modificadoPor, DateTime fechaRegistro, DateTime fechaModificacion, decimal? montoAjuste, string descripcion, ParteSucursal parteSucursal, decimal costoPromedio, decimal costoPromedioExtendido)
        {
            _idRequisaAjuste = idRequisaAjuste;
            _requisa = requisa;
            _tipoAjuste = tipoAjuste;
            _creadoPor = creadoPor;
            _modificadoPor = modificadoPor;
            _fechaRegistro = fechaRegistro;
            _fechaModificacion = fechaModificacion;
            _montoAjuste = montoAjuste;
            _descripcion = descripcion;
            _parteSucursal = parteSucursal;
            _costoPromedio = costoPromedio;
            _costoPromedioExtendido = costoPromedioExtendido;
        }
        #endregion

        public int IdRequisaAjuste { get => _idRequisaAjuste; set => _idRequisaAjuste = value; }
        public Requisa Requisa { get => _requisa; set => _requisa = value; }
        public TipoAjuste TipoAjuste { get => _tipoAjuste; set => _tipoAjuste = value; }
        public string CreadoPor { get => _creadoPor; set => _creadoPor = value; }
        public string ModificadoPor { get => _modificadoPor; set => _modificadoPor = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime FechaModificacion { get => _fechaModificacion; set => _fechaModificacion = value; }
        public decimal? MontoAjuste { get => _montoAjuste; set => _montoAjuste = value;}
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public ParteSucursal ParteSucursal { get => _parteSucursal; set => _parteSucursal = value; }
        public decimal CostoPromedio { get => _costoPromedio; set => _costoPromedio = value; }
        public decimal CostoPromedioExtendido { get => _costoPromedioExtendido; set => _costoPromedioExtendido = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly RequisaAjuste _requisaAjuste;
            public Builder()
            {
                _requisaAjuste = new RequisaAjuste();
            }
            public Builder SetIdRequisaAjuste(int id)
            {
                _requisaAjuste._idRequisaAjuste = id;
                return this;
            }
            public Builder SetRequisa(Requisa requisa)
            {
                _requisaAjuste._requisa = requisa;
                return this;
            }
            public Builder SetTipoAjuste(TipoAjuste tipoAjuste)
            {
                _requisaAjuste._tipoAjuste = tipoAjuste;
                return this;
            }
            public Builder SetCreadoPor(string creadoPor)
            {
                _requisaAjuste._creadoPor = creadoPor;
                return this;
            }
            public Builder SetModificadoPor(string modificadoPor)
            {
                _requisaAjuste._modificadoPor = modificadoPor;
                return this;
            }
            public Builder SetFechaRegistro(DateTime fechaRegistro)
            {
                _requisaAjuste._fechaRegistro = fechaRegistro;
                return this;
            }
            public Builder SetFechaModificacion(DateTime fechaModificacion)
            {
                _requisaAjuste._fechaModificacion = fechaModificacion;
                return this;
            }
            public Builder SetMontoAjuste(decimal? montoAjuste)
            {
                _requisaAjuste._montoAjuste = montoAjuste;
                return this;
            }
            public Builder SetDescripcion(string descripcion)
            {
                _requisaAjuste._descripcion = descripcion;
                return this;
            }
            public Builder SetParteSucursal(ParteSucursal parteSucursal)
            {
                _requisaAjuste._parteSucursal = parteSucursal;
                return this;
            }
            public Builder SetCostoPromedio(decimal costoPromedio)
            {
                _requisaAjuste._costoPromedio = costoPromedio;
                return this;
            }
            public Builder SetCostoPromedioExtendido(decimal costoPromedioExtendido)
            {
                _requisaAjuste._costoPromedioExtendido = costoPromedioExtendido;
                return this;
            }
            public RequisaAjuste Build()
            {
                return _requisaAjuste;
            }
        }
        #endregion

    }
}
