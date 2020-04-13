using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace SorterioDeTimesNew.Logica
{
    public class JogadorController : Controller
    {
        public IEnumerable<Jogador> Jogadores { get; set; }

        public IActionResult ListarJogadores()
        {
            var repo = new SorteioDeTimesContext();
            var context = repo.Jogadores.ToList();
            ViewBag.Jogadores = context;
            return View("jogadores");            
        }



    //var repo = new SorteioDeTimesContext();
    //IList<Jogador> jogadores = repo.Jogadores.Include(j => j.Equipe).ToList();
    //var linhas = new StringBuilder();
    //        foreach (var item in jogadores)
    //        {
    //            if (item.Equipe != null)
    //            {
    //                linhas.AppendLine($"Nome: {item.Nome} - Posicao: {item.Posicao} - N. Ataque: {item.NivelAtaque} - " +
    //                    $"N. Defesa: {item.NivelDefesa} - Equipe: {item.Equipe.Id}");
    //                linhas.AppendLine("=======================================================================");
    //            }
    //            else if (item.Equipe == null)
    //            {
    //                linhas.AppendLine($"Nome: {item.Nome} - Posicao: {item.Posicao} - N. Ataque: {item.NivelAtaque} - " +
    //                    $"N. Defesa: {item.NivelDefesa} - Equipe: Sem equipe");
    //                linhas.AppendLine("=======================================================================");
    //            }
    }
}
