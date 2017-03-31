using System;
namespace PaddyPowerChallenge
{
	public class BaseSelection
	{
		public string TeamName { get; set; }
		public WinLossDrawEnum ProposedOutCome { get; set; }
		public string Odds { get; set; }
		public decimal DecimalOdds
		{
			get
			{
				return ConvertOddsToDecimal(Odds);
			}
		}

		public BaseSelection(string TeamName, string Odds, WinLossDrawEnum ProposedOutCome)
		{
			this.Odds = Odds;
			this.TeamName = TeamName;
			this.ProposedOutCome = ProposedOutCome;
		}

		private decimal ConvertOddsToDecimal(string odds)
		{
			var splitNumber = odds.Trim().Split('/');
			var topNumber = 0;
			int.TryParse(splitNumber[0], out topNumber);
			var bottomNumber = 0;
			int.TryParse(splitNumber[1], out bottomNumber);

			if (bottomNumber != 0)
			{
				return topNumber / bottomNumber;
			}

			return 0;
		}
	}
}
