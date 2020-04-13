using System.Text;

namespace SorterioDeTimesNew
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int NivelAtaque { get; set; }
        public int NivelDefesa { get; set; }
        public Equipe Equipe { get; set; }
        public bool Ativo { get; set; }

        
    }
}