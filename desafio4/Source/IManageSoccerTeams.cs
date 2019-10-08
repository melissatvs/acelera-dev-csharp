using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public interface IManageSoccerTeams 
	{
		void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor);

		void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary);

		void SetCaptain(long playerId);

		long GetTeamCaptain(long teamId);

		string GetPlayerName(long playerId);

		string GetTeamName(long teamId);

		long GetHigherSalaryPlayer(long teamId);

		decimal GetPlayerSalary(long playerId);

		List<long> GetTeamPlayers(long teamId);

		long GetBestTeamPlayer(long teamId);

		long GetOlderTeamPlayer(long teamId);

		List<long> GetTeams();

		List<long> GetTopPlayers(int top);

		string GetVisitorShirtColor(long teamId, long visitorTeamId);
	}
}