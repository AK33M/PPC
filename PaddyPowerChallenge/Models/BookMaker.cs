using System.Collections.Generic;

namespace PaddyPowerChallenge.Models
{
	public class BookMaker
	{
		//Properties
		public static decimal GlobalProfit { get; private set; }
		public IList<Punter> Punters { get; private set; }
		private IList<SportEvent> Events { get; set; }

		//Constructor
		public BookMaker()
		{
			this.Punters = new List<Punter>();
			this.Events = new List<SportEvent>();
			Bet.BetCreated += Bet_BetCreated;
			Bet.BetPaidOut += Bet_BetPaidOut;
		}

		//Public Methods
		public void AddEvent(SportEvent sportEvent)
		{
			Events.Add(sportEvent);
		}
		public void AddPunter(Punter punter)
		{
			Punters.Add(punter);
		}

		//EventHandlers to Update the Companies Bank balance
		private void Bet_BetCreated(object sender, BetCreatedEventArgs e)
		{
			GlobalProfit += e.Stake;
		}
		private void Bet_BetPaidOut(object sender, BetPaidOutEventArgs e)
		{
			GlobalProfit -= e.PayOut;
		}
	}
}
