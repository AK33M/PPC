using System;
namespace PaddyPowerChallenge
{
	public class WinLossDrawSelection : BaseSelection
	{
		public WinLossDrawSelection(string TeamName, string Odds, WinLossDrawEnum ProposedOutCome)
			: base(TeamName, Odds, ProposedOutCome)
		{
			
		}

		public bool DoesPayOut(WinLossDrawEnum ActualOutcome)
		{
			if (ActualOutcome == ProposedOutCome)
			{
				return true;
			}
			return false;
		}
	}
}
