namespace PaddyPowerChallenge.Models
{
	public abstract class BaseSelection
	{
		//Properties
		public string TeamName { get; private set; }
		public WinDrawEnum ProposedOutCome { get; private set; }
		public string Price { get; private set; }
		public decimal PriceInDouble { get { return ConvertPriceToDouble(Price); } }
		public bool IsWinner { get; protected set; } = false;

		//Constructor
		public BaseSelection(string TeamName, string Price, WinDrawEnum ProposedOutCome)
		{
			this.Price = Price;
			this.TeamName = TeamName;
			this.ProposedOutCome = ProposedOutCome;
		}

		//Public Methods
		public abstract void CheckIfWinner(string TeamName, WinDrawEnum ActualOutcome, string ActualScore);


		//Protected and Private Methods
		protected void CheckIfWinner(string TeamName, WinDrawEnum ActualOutcome)
		{
			IsWinner = (TeamName == this.TeamName && ActualOutcome == ProposedOutCome);
		}

		private void UpdateOdds(string newOdds)
		{
			Price = newOdds;
		}

		private decimal ConvertPriceToDouble(string price)
		{
			var splitNumber = price.Trim().Split('/');
			int topNumber;
			int bottomNumber;
			int.TryParse(splitNumber[0], out topNumber);
			int.TryParse(splitNumber[1], out bottomNumber);

			if (bottomNumber != 0)
			{
				return (decimal)topNumber / bottomNumber;
			}

			return 0;
		}
	}
}
