using System;
using System.Collections.Generic;

namespace PaddyPowerChallenge.Models
{
	public class SportEvent
	{
		//Properties
		private string EventName { get; set; }
		private DateTime EventDateTime { get; set; }
		private string TeamA { get; set; }
		private string TeamB { get; set; }
		private IList<Market> Markets { get; set; }

		//Constructor
		public SportEvent()
		{
			Markets = new List<Market>();
		}

		public SportEvent(string EventName, string TeamA, string TeamB, DateTime EventDateTime) 
			: this()
		{
			this.EventName = EventName;
			this.TeamA = TeamA;
			this.TeamB = TeamB;
			this.EventDateTime = EventDateTime;
		}

		//Public Methods
		public void AddMarket(Market market)
		{
			Markets.Add(market);
		}
	}
}