using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using ProjetoParaSerTestado.Models;
using ProjetoParaSerTestado;

namespace TestProject.UnitTests
{
    public class InterestingInformationsTests
    {
        private static readonly InterestingInformations _interestingInformations = new InterestingInformations();
        private static readonly List<Game> _games = FreeNbaApiClient.GetAllGames(5);

        [Fact]
        public void NullListThrowException()
        {
            //Arrange
            List<Game> gameList = null;

            //Act e Assert
            Assert.Throws<ArgumentNullException>(() => _interestingInformations.GetPercentageHomeTeamWins(gameList));
        }

        [Fact]
        public void PercentageHomeTeamsWon()
        {
            //Arrange
            List<Game> games = _games;

            //Act
            decimal percentage = _interestingInformations.GetPercentageHomeTeamWins(games);
            string percentageHomeTeamWon = string.Format("{0:0.00}", percentage);

            //Assert
            Assert.Equal("58,40",percentageHomeTeamWon);
        }

        [Fact]
        public void NullGameListThrowException()
        {
            //Arrange
            List<Game> gameList = null;

            //Act e Assert
            Assert.Throws<ArgumentNullException>(() => _interestingInformations.GetGamesHomeTeamWins(gameList));
        }

        [Fact]
        public void OnlyHomeTeamsWonList()
        {
            //Arrange
            List<Game> games = _games;

            //Act
            bool onlyHomeTeamsWon = _interestingInformations.GetGamesHomeTeamWins(games).Any(g => g.HomeTeamScore <= g.VisitorTeamScore);

            //Assert
            Assert.True(onlyHomeTeamsWon);
        }

        [Fact]
        public void NullListException()
        {
            //Arrange
            List<Game> gameList = null;

            //Act e Assert
            Assert.Throws<ArgumentNullException>(() => _interestingInformations.GetPercentageGamesWithMoreThan120Points(gameList));
        }

        [Fact]
        public void PercentageGamesWithMoreThan120Points()
        {
            //Arrange
            List<Game> games = _games;

            //Act
            decimal percentage = _interestingInformations.GetPercentageGamesWithMoreThan120Points(games);
            string percentageGamesWithMoreThan120Points = string.Format("{0:0.00}", percentage);

            //Assert
            Assert.Equal("38,20", percentageGamesWithMoreThan120Points);
        }

        [Fact]
        public void GenerateClashesRandomlyUsingLessThan30TeamsException()
        {
            //Arrange
            List<Team> teams = FreeNbaApiClient.GetAllTeams();
            teams.RemoveAt(0);

            //Act e Assert
            Assert.Throws<Exception>(() => _interestingInformations.GenerateClashesRandomly(teams));
        }

        [Fact]
        public void GenerateClashesRandomlyUsingMoreThan30TeamsException()
        {
            //Arrange
            List<Team> teams = FreeNbaApiClient.GetAllTeams();
            teams.Add(teams[0]);

            //Act e Assert
            Assert.Throws<Exception>(() => _interestingInformations.GenerateClashesRandomly(teams));
        }

        [Fact]
        public void GenerateClashesRandomly()
        {
            //Arrange
            List<Team> teams = FreeNbaApiClient.GetAllTeams();

            //Act
            var clashes = _interestingInformations.GenerateClashesRandomly(teams);

            //Assert
            Assert.True(clashes.Count == 15);
        }
    }
}
