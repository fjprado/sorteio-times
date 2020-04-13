using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SorterioDeTimesNew.Logica
{
    public class CadastroController
    {
        public IActionResult CadastrarJogador()
        {
            var html = new ViewResult() { ViewName = "formulario" };
            return html;
        }

        public string Incluir(Jogador jogador)
        {
            var repo = new SorteioDeTimesContext();
            repo.Jogadores.Add(jogador);
            return "Jogador cadastrado com sucesso!!!";
        }
        
    }
}
