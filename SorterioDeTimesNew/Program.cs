using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterioDeTimesNew
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
            
            //Cadastrar jogador - OK
            //Vincular jogador a uma equipe - OK
            //Lista jogadores - OK
            //Lista equipes - OK
            //Lista jogadores de uma equipe especifica - OK
            //Remover Jogadores - OK
            var jogador = new Jogador();
            jogador.Nome = "Ponhonho3";
            jogador.Posicao = "Zagueiro";
            jogador.NivelAtaque = 3;
            jogador.NivelDefesa = 2;
            jogador.Ativo = true;

            //CadastrarJogador(jogador);

            //ListarJogadores();
            //SortearJogadores();

            //ListarJogadores();

            //ListarEquipes();

            //int equipe = 1014;
            //MostrarEquipe(equipe);

            //var jogadorRemover = 1017;
            //RemoverJogador(jogadorRemover);
            //ListarJogadores();

            Console.ReadLine();
        }

        private static void RemoverJogador(int jogadorRemover)
        {
            using(var context = new SorteioDeTimesContext())
            {
                var jogadorRemovido = context.Jogadores.Where(j => j.Id == jogadorRemover).FirstOrDefault();
                context.Jogadores.Remove(jogadorRemovido);
                context.SaveChanges();
            }
        }

        private static void MostrarEquipe(int equipe)
        {
            using(var context = new SorteioDeTimesContext())
            {
                Console.WriteLine($"Esta é a equipe {equipe}:");
                IList<Jogador> jogadores = context.Jogadores.Where(j => j.Equipe.Id == equipe).ToList();
                
                foreach(var item in jogadores)
                {
                    Console.WriteLine($"Nome: {item.Nome} - Posicao: {item.Posicao}");
                }
            }
        }

        private static void ListarEquipes()
        {
            using(var context = new SorteioDeTimesContext())
            {
                Console.WriteLine("/n=============================");
                Console.WriteLine("Estas são as equipes já sorteadas");
                IList<Equipe> equipes = context.Equipes.Include(e => e.Jogador).ToList();
                IList<Jogador> jogadores = context.Jogadores.Include(j => j.Equipe).ToList();
                foreach (var item in equipes)
                {
                    Console.WriteLine(item.Id);
                    foreach (var item2 in jogadores)
                    {
                        if(item2.Equipe != null)
                        {
                            if(item.Id == item2.Equipe.Id)
                                Console.WriteLine($"Jogador: {item2.Nome} - Posicao: {item2.Posicao}");
                        }
                    }
                }
            }
        }

        

        private static void CadastrarJogador(Jogador jogador)
        {
            using(var context = new SorteioDeTimesContext())
            {
                context.Jogadores.Add(jogador);
                context.SaveChanges();
            }
            Console.WriteLine($"Jogador {jogador.Nome} cadastrado com sucesso.");
        }

        private static void SortearJogadores()
        {
            using (var context = new SorteioDeTimesContext())
            {
                var config = new Configuracoes()
                {
                    QuantidadeJogadoresEquipe = 6,
                    ContarGoleiroEquipe = true,
                };

                IList<Jogador> jogadores = context.Jogadores.ToList();
                int quantidadeJogadores = jogadores.Count();
                int quantidadeEquipes = quantidadeJogadores / config.QuantidadeJogadoresEquipe;
                int jogadoresDeFora = quantidadeJogadores % config.QuantidadeJogadoresEquipe;

                for (int e = 0; e <= quantidadeEquipes; e++)
                {
                    var equipe = new Equipe();
                    equipe.QuantidadeJogadores = config.QuantidadeJogadoresEquipe;
                    equipe.ContarGoleiro = config.ContarGoleiroEquipe;
                    context.Equipes.Add(equipe);
                    context.SaveChanges();
                    int[] equipeRegistro = new int[quantidadeJogadores];
                    Random random = new Random();
                    for (int j = 0; j <= (quantidadeJogadores - jogadoresDeFora); j++)
                    {
                        int numero = random.Next();
                        for (int r = 0; r <= equipeRegistro.Length; r++)
                        {
                            if (numero == equipeRegistro[r] && r != j)
                            {
                                numero = random.Next(quantidadeJogadores);
                            }
                            else
                            {
                                equipeRegistro[r] = numero;
                                var jogador = context.Jogadores.ElementAt(numero);
                                jogador.Equipe = equipe;
                                context.Jogadores.Update(jogador);
                                context.SaveChanges();
                            }
                        }
                    }
                }
                               
            }
        }
    }
}
