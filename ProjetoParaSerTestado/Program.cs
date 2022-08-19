using ProjetoParaSerTestado.Models;
using System;
using System.Collections.Generic;

namespace ProjetoParaSerTestado
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Game> games = FreeNbaApiClient.GetAllGames(5);
            //ImprimirTimesQueGanharamEmCasa(games);
            //ImprimirPorcentagemDeVitoriasEmCasa(games);
            //ImprimirPorcentagemDeJogosComMaisDe120Pontos(games);

            List<Team> teams = FreeNbaApiClient.GetAllTeams();
            ImprimirListaDeConfrontos(teams);
        }

        private static void ImprimirTimesQueGanharamEmCasa(List<Game> games)
        {
            InterestingInformations interestingInformations = new InterestingInformations();

            
            List<Game> gamesHomeTeamWins = interestingInformations.GetGamesHomeTeamWins(games);
            


            for (int i = 0; i < gamesHomeTeamWins.Count; i++)
            {
                var game = gamesHomeTeamWins[i];
                Console.WriteLine($"Game {i + 1} - {game.Date.ToShortDateString()}");
                Console.WriteLine("Home team: " + game.HomeTeamScore);
                Console.WriteLine("Visitor team: " + game.VisitorTeamScore);
                Console.WriteLine();
            }
        }

        private static void ImprimirPorcentagemDeVitoriasEmCasa(List<Game> games)
        {
            InterestingInformations interestingInformations = new InterestingInformations();

            decimal percentageHomeTeamWon = interestingInformations.GetPercentageHomeTeamWins(games);
            Console.WriteLine($"Em {string.Format("{0:0.00}", percentageHomeTeamWon)}% dos jogos quem ganhou foi o time de casa.");
        }

        private static void ImprimirPorcentagemDeJogosComMaisDe120Pontos(List<Game> games)
        {
            InterestingInformations interestingInformations = new InterestingInformations();

            decimal gamesWithMoreThan120Points = interestingInformations.GetPercentageGamesWithMoreThan120Points(games);

            Console.WriteLine($"Em {string.Format("{0:0.00}", gamesWithMoreThan120Points)}% dos jogos pelo menos um dos dois times ultrapassaram os 120 pontos.");
        }

        private static void ImprimirListaDeConfrontos(List<Team> teams)
        {
            InterestingInformations interestingInformations = new InterestingInformations();
            Dictionary<string, string> confrontos = interestingInformations.GenerateClashesRandomly(teams);
            foreach(KeyValuePair<string, string> confronto in confrontos)
            {
                Console.WriteLine(confronto.Key);
                Console.WriteLine("VS");
                Console.WriteLine(confronto.Value);
                Console.WriteLine("----------------------");
            }
        }
    }
}
