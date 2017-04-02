using System;

namespace PaddyPowerChallenge.Models
{
	public class Bet
	{
		//Properties
		public BaseSelection Selection { get; private set; }
		public decimal Stake { get; private set; }


		//Contstructor
		public Bet(BaseSelection Selection, decimal Stake)
		{
			this.Selection = Selection;
			this.Stake = Stake;
			OnBetCreated(new BetCreatedEventArgs(Stake));
		}


		//Public Methods
		public decimal GetBetPayOut()
		{
			if (Selection.IsWinner)
			{
				var payOut = Stake + (Stake * Selection.PriceInDouble);
				OnBetPaidOut(new BetPaidOutEventArgs(Stake, payOut));
				return payOut;
			}

			return 0;
		}


		//EventHandlers to Update the Companies Bank balance
		public static event EventHandler<BetCreatedEventArgs> BetCreated;
		public static event EventHandler<BetPaidOutEventArgs> BetPaidOut;
		protected virtual void OnBetCreated(BetCreatedEventArgs e)
		{
			BetCreated?.Invoke(this, e);
		}

		protected virtual void OnBetPaidOut(BetPaidOutEventArgs e)
		{
			BetPaidOut?.Invoke(this, e);
		}
	}
}