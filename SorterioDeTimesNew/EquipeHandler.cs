using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterioDeTimesNew
{
    class EquipeHandler : IDisposable
    {
        private SorteioDeTimesContext context;

        public EquipeHandler()
        {
            context = new SorteioDeTimesContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void IncluirEquipe(Equipe equipe)
        {
            context.Equipes.Add(equipe);
            context.SaveChanges();
        }
    }
}
