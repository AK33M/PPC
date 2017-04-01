using System;
namespace PaddyPowerChallenge.Models
{
	public abstract class BaseSelection
	{
		public string TeamName { get; set; }
		public WinLossDrawEnum ProposedOutCome { get; set; }
		public string Price { get; set; }
		public decimal DecimalOdds
		{
			get
			{
				return ConvertPriceToDecimal(Price);
			}
		}

		public BaseSelection(string TeamName, string Price, WinLossDrawEnum ProposedOutCome)
		{
			this.Price = Price;
			this.TeamName = TeamName;
			this.ProposedOutCome = ProposedOutCome;
		}

        public abstract bool DoesPayOut(WinLossDrawEnum ActualOutcome, string ActualScore);

        protected bool DoesPayOut(WinLossDrawEnum ActualOutcome)
        {
            return ActualOutcome == ProposedOutCome;
        }

        private void UpdateOdds(string newOdds)
        {
            Price = newOdds;
        }

		private decimal ConvertPriceToDecimal(string price)
		{
			var splitNumber = price.Trim().Split('/');
            int.TryParse(splitNumber[0], out int topNumber);
            int.TryParse(splitNumber[1], out int bottomNumber);

            if (bottomNumber != 0)
			{
				return (decimal)topNumber / bottomNumber;
			}

			return 0;
		}
	}
}
