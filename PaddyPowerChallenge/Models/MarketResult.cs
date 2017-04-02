namespace PaddyPowerChallenge.Models
{
	public class MarketResult
	{
		//Properties
		public string TeamName { get; private set; }
		public WinDrawEnum ActualOutcome { get; private set; }
		public string ActualScore { get; private set; }

		//Constructors
		public MarketResult(string TeamName, WinDrawEnum ActualOutcome)
		{
			this.TeamName = TeamName;
			this.ActualScore = string.Empty;
			this.ActualOutcome = ActualOutcome;
		}

		public MarketResult(string TeamName, string ActualScore, WinDrawEnum ActualOutcome)
		{
			this.TeamName = TeamName;
			this.ActualScore = ActualScore;
			this.ActualOutcome = ActualOutcome;
		}
	}
}
