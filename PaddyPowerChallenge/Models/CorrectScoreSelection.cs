using System;
using System.Text;

namespace PaddyPowerChallenge.Models
{
	public class CorrectScoreSelection : BaseSelection
	{
		public CorrectScoreSelection(string TeamName, string Price, string ProposedScore, WinLossDrawEnum ProposedOutcome)
			: base(TeamName, Price, ProposedOutcome)
		{
			this.ProposedScore = ProposedScore;
		}

		public string ProposedScore { get; set; }

		public override bool DoesPayOut(WinLossDrawEnum ActualOutcome, string ActualScore)
		{
			if (!string.IsNullOrWhiteSpace(ActualScore)) 
			{
                return base.DoesPayOut(ActualOutcome) && ActualScore == ProposedScore;
			}

			return base.DoesPayOut(ActualOutcome);
		}

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{TeamName} to {ProposedOutCome.ToString()} by {ProposedScore} @{Price}");
            return sb.ToString();
        }
    }
}
