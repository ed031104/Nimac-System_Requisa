using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Dto
{
    public record RequisaConAjustes
    {
        private int _id;
        private Requisa _requisa;
        private IEnumerable<RequisaAjuste> _ajustes;

        #region contructores
        public RequisaConAjustes(int id, Requisa requisa, IEnumerable<RequisaAjuste> ajustes)
        {
            _id = id;
            _requisa = requisa;
            _ajustes = ajustes;
        }
        public RequisaConAjustes() { }

        #endregion

        public int Id { get => _id; set => _id = value; }
        public Requisa Requisa { get => _requisa; set => _requisa = value; }
        public IEnumerable<RequisaAjuste> Ajustes { get => _ajustes; set => _ajustes = value; }

        #region Builder Pattern
        public class Builder
        {
            private readonly RequisaConAjustes _requisaConAjustes;
            public Builder()
            {
                _requisaConAjustes = new RequisaConAjustes();
            }
            public Builder SetId(int id)
            {
                _requisaConAjustes.Id = id;
                return this;
            }
            public Builder SetRequisa(Requisa requisa)
            {
                _requisaConAjustes.Requisa = requisa;
                return this;
            }
            public Builder SetAjustes(IEnumerable<RequisaAjuste> ajustes)
            {
                _requisaConAjustes.Ajustes = ajustes;
                return this;
            }
            public RequisaConAjustes Build()
            {
                return _requisaConAjustes;
            }
        }
        #endregion
    }
}
