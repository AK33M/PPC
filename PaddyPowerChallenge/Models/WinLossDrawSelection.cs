using System;
using System.Text;

namespace PaddyPowerChallenge.Models
{
	public class WinLossDrawSelection : BaseSelection
	{
		public WinLossDrawSelection(string TeamName, string Price, WinLossDrawEnum ProposedOutCome)
			: base(TeamName, Price, ProposedOutCome)
		{
			
		}

        public override bool DoesPayOut(WinLossDrawEnum ActualOutcome, string ActualScore = "")
        {
            return base.DoesPayOut(ActualOutcome);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{TeamName} to {ProposedOutCome.ToString()} @{Price}");
            return sb.ToString();
        }
    }
}
