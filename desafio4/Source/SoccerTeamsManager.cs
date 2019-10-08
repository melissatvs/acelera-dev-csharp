using System;
using System.Collections.Generic;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    

    public class SoccerTeamsManager : IManageSoccerTeams
    {
        readonly List<Team> teams = new List<Team>();
        readonly List<Player> players = new List<Player>();

        public SoccerTeamsManager()
        {

        }

        private bool TeamExists(long teamId)
        {
            foreach (Team team in teams)
            {
                if (team.Id == teamId)
                {
                    return true;
                }
            }

            return false;
        }

        private bool PlayerExists(long playerId)
        {
            foreach (Player player in players)
            {
                if (player.Id == playerId)
                {
                    return true;
                }
            }

            return false;
        }

        private List<Player> GetPlayersBySkill(long? teamId = null)
        {
            List<Player> playersBySkill = new List<Player>();

            if (teamId.HasValue)
            {
                playersBySkill = GetListTeamPlayers((long)teamId);
            }
            else
            {
                playersBySkill = players;
            }


            for (int i = 0; i < playersBySkill.Count; i++)
            {
                Player skillAux = playersBySkill[i];
                int j = i + 1;

                while (j < playersBySkill.Count)
                {
                    if (skillAux.SkillLevel < playersBySkill[j].SkillLevel ||
                        (skillAux.SkillLevel == playersBySkill[j].SkillLevel && skillAux.Id > playersBySkill[j].SkillLevel))
                    {
                        playersBySkill[i] = playersBySkill[j];
                        playersBySkill[j] = skillAux;

                        skillAux = playersBySkill[i];
                    }

                    j++;
                }

            }

            return playersBySkill;
        }

        private List<Player> GetListTeamPlayers(long teamId)
        {
            if (!TeamExists(teamId))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

            List<Player> resultPlayers = new List<Player>();

            foreach (Player player in players)
            {
                if (player.TeamId == teamId)
                {
                    resultPlayers.Add(player);
                }

            }

            return resultPlayers;
        }
        
        private Team GetTeam(long teamId)
        {
            foreach (Team team in teams)
            {
                if (team.Id == teamId)
                {
                    return team;
                }
            }

            return null;
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (TeamExists(id))
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();
            }
            
            teams.Add(new Team(id, name, createDate, mainShirtColor, secondaryShirtColor));
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if (PlayerExists(id))
            {
                throw new Codenation.Challenge.Exceptions.UniqueIdentifierException();            
            }

            if (!TeamExists(teamId))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

            players.Add(new Player(id, teamId, name, birthDate, skillLevel, salary));

        }
               
        public void SetCaptain(long playerId)
        {
            if (!PlayerExists(playerId))
            {
                throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
            }

            foreach (Player player in players)
            {
                player.Capitain = player.Id == playerId;
            }
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!TeamExists(teamId))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

            foreach (Player player in players)
            {
                if (player.Capitain)
                {
                    return player.Id;
                }
            }

            throw new Codenation.Challenge.Exceptions.CaptainNotFoundException();
        }

        public string GetPlayerName(long playerId)
        {
            foreach (Player player in players)
            {
                if (player.Id == playerId)
                {
                    return player.Name;
                }
            }

            throw new Codenation.Challenge.Exceptions.PlayerNotFoundException();
        }

        public string GetTeamName(long teamId)
        {
            foreach (Team team in teams)
            {
                if (team.Id == teamId)
                {
                    return team.Name;
                }
            }

            throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!TeamExists(teamId))
            {
                throw new Codenation.Challenge.Exceptions.TeamNotFoundException();
            }

            List<long> teamPlayers = new List<long>();

            foreach (Player player in players)
            {
                if (player.TeamId == teamId)
                {
                    teamPlayers.Add(player.Id);
                }
            }

            for (int i = 0; i < teamPlayers.Count; i++)
            {
                long idAux = teamPlayers[i];
                int j = i + 1;

                while (j < teamPlayers.Count)
                {
                    if (idAux > teamPlayers[j])
                    {
                        teamPlayers[i] = teamPlayers[j];
                        teamPlayers[j] = idAux;

                        idAux = teamPlayers[i];
                    }

                    j++;
                }
            }

            return teamPlayers;
        }

        public long GetBestTeamPlayer(long teamId)
        {
            return GetPlayersBySkill(teamId)[0].Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            List<Player> resultPlayers = GetListTeamPlayers(teamId);

            for (int i = 0; i < resultPlayers.Count; i++)
            {
                Player playerAux = resultPlayers[i];
                int j = i + 1;

                while (j < resultPlayers.Count)
                {
                    if (playerAux.BirthDate > resultPlayers[j].BirthDate ||
                        (playerAux.BirthDate == resultPlayers[j].BirthDate && playerAux.Id > resultPlayers[j].Id))
                    {
                        resultPlayers[i] = resultPlayers[j];
                        resultPlayers[j] = playerAux;                        
                        playerAux = resultPlayers[i];
                    }

                    j++;
                }
            }

            return resultPlayers[0].Id;
        }

        public List<long> GetTeams()
        {
            List<long> resultTeams = new List<long>();

            foreach (Team team in teams)
            {
                resultTeams.Add(team.Id);
            }

            for (int i = 0; i < resultTeams.Count; i++)
            {
                long idAux = resultTeams[i];
                int j = i + 1;

                while (j < resultTeams.Count)
                {
                    if (idAux > resultTeams[j])
                    {
                        resultTeams[i] = resultTeams[j];
                        resultTeams[j] = idAux;
                        idAux = resultTeams[i];
                    }

                    j++;
                }
            }

            return resultTeams;
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            List<Player> resultPlayers = GetListTeamPlayers(teamId);

            for (int i = 0; i < resultPlayers.Count; i++)
            {
                Player playerAux = resultPlayers[i];
                int j = i + 1;

                while (j < resultPlayers.Count)
                {
                    if (playerAux.Salary < resultPlayers[j].Salary || (playerAux.Salary == resultPlayers[j].Salary && playerAux.Id > resultPlayers[j].Id))
                    {
                        resultPlayers[i] = resultPlayers[j];
                        resultPlayers[j] = playerAux;
                        playerAux = resultPlayers[i];
                    }

                    j++;
                }                
            }

            return resultPlayers[0].Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            if (!PlayerExists(playerId))
            {
                throw new PlayerNotFoundException();
            }

            foreach (Player player in players)
            {
                if (player.Id == playerId)
                {
                    return player.Salary;
                }
            }

            return 0;
        }

        public List<long> GetTopPlayers(int top)
        {
            List<long> topPlayers = new List<long>();
            
            int i = 0;
            foreach (Player player in GetPlayersBySkill())
            {
                if (i >= top)
                {
                    break;
                }

                i++;

                topPlayers.Add(player.Id);
            }

            return topPlayers;
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if (!TeamExists(teamId))
            {
                throw new TeamNotFoundException();
            }

            if (!TeamExists(visitorTeamId))
            {
                throw new TeamNotFoundException();
            }

            Team mainTeam = GetTeam(teamId);
            Team visitorTeam = GetTeam(visitorTeamId);

            if (mainTeam.MainShirtColor == visitorTeam.MainShirtColor)
            {
                return visitorTeam.SecondaryShirtColor;
            }
            else
            {
                return visitorTeam.MainShirtColor;
            }

        }

    }
}
