using System;
namespace PaddyPowerChallenge
{
	public class CorrectScoreSelection : BaseSelection
	{
		public CorrectScoreSelection(string TeamA, string Odds, string CorrectScore, WinLossDrawEnum ProposedOutcome)
			: base(TeamA, Odds, ProposedOutcome)
		{
			this.CorrectScore = CorrectScore;
		}

		public string CorrectScore { get; set; }

		public bool DoesPayOut(WinLossDrawEnum ActualOutcome, string ActualScore)
		{
			if (ActualOutcome == ProposedOutCome && ActualScore == CorrectScore) 
			{
				return true;
			}
			return false;
		}
	}
}
