using System.Text;

namespace PaddyPowerChallenge.Models
{
	public class CorrectScoreSelection : BaseSelection
    {
		//Properties
		private string ProposedScore { get; set; }

		//Constructor
		public CorrectScoreSelection(string TeamName, string Price, string ProposedScore, WinDrawEnum ProposedOutcome)
            : base(TeamName, Price, ProposedOutcome)
        {
            this.ProposedScore = ProposedScore;
        }

		//Public Methods
        public override void CheckIfWinner(string TeamName, WinDrawEnum ActualOutcome, string ActualScore)
        {
            if (!string.IsNullOrWhiteSpace(ActualScore))
            {
                IsWinner = (TeamName == this.TeamName && ActualOutcome == ProposedOutCome && ActualScore == ProposedScore);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{TeamName} to {ProposedOutCome.ToString()} by {ProposedScore} @ {Price}");
            return sb.ToString();
        }
    }
}
