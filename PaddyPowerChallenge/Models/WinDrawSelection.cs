using System.Text;

namespace PaddyPowerChallenge.Models
{
	public class WinDrawSelection : BaseSelection
	{
		//Constructor
		public WinDrawSelection(string TeamName, string Price, WinDrawEnum ProposedOutCome)
			: base(TeamName, Price, ProposedOutCome)
		{
			
		}


		//Public Methods
		public override void CheckIfWinner(string TeamName, WinDrawEnum ActualOutcome, string ActualScore = "")
		{
            base.CheckIfWinner(TeamName, ActualOutcome);
        }
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"{TeamName} to {ProposedOutCome.ToString()} @ {Price}");
			return sb.ToString();
		}
	}
}
