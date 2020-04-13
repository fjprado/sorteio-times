using System.Collections.Generic;

namespace SorterioDeTimesNew
{
    public class Equipe
    {
        public int Id { get; set; }
        public int QuantidadeJogadores { get; internal set; }
        public bool ContarGoleiro { get; internal set; }
        public IList<Jogador> Jogador { get; set; }
    }
}