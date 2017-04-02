using System.Text;

namespace PaddyPowerChallenge.Models
{
	public class Punter
	{
		//Properties
		private string Name { get; set; }
		private Bet Bet { get; set; }
		private decimal TotalWinnings { get; set; }


		//Constructor
		public Punter(string Name)
		{
			this.Name = Name;
		}

		//Public Methods
		public void PlaceBet(Bet bet)
		{
			Bet = bet;
		}

		public void CollectWinnings()
		{
			if (Bet != null)
			{
				TotalWinnings = Bet.GetBetPayOut();
			}
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"{Name} placed {Bet.Stake} on {Bet.Selection.ToString()}");
			sb.AppendLine($"{Name} won {TotalWinnings.ToString("C")} from {Bet.Selection.ToString()}");
			sb.AppendLine("*******");
			return sb.ToString();
		}
	}
}
