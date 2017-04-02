using System.Collections.Generic;

namespace PaddyPowerChallenge.Models
{
	public class Market
	{
		//Properties
		private string MarketName { get; set; }
		private MarketResult Result { get; set; }
		private IList<BaseSelection> Selections { get; set; }

		//Constructor
		public Market(string MarketName)
		{
			this.Selections = new List<BaseSelection>();
			this.MarketName = MarketName;
		}

		//Public Methods
		public void AddResult(MarketResult result)
		{
			Result = result;
			OnResultAdded(Result);
		}

		public void AddSelection(BaseSelection selection)
		{
			Selections.Add(selection);
		}

		//Private Methods
		private void OnResultAdded(MarketResult result)
		{
			if (Selections != null)
			{
				foreach (var sel in Selections)
				{
					sel.CheckIfWinner(result.TeamName, result.ActualOutcome, result.ActualScore);
				}
			}
		}
	}
}