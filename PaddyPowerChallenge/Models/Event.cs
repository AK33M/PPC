using System;
using System.Collections.Generic;

namespace PaddyPowerChallenge.Models
{
    public class Event
    {
        public string EventName { get; set; }
        public DateTime EventDateTime { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public IList<Market> Markets { get; set; }

        public Event()
        {
            Markets = new List<Market>();
        }

        public Event(string EventName, string TeamA, string TeamB, DateTime EventDateTime) 
            : this()
        {
            this.EventName = EventName;
            this.TeamA = TeamA;
            this.TeamB = TeamB;
            this.EventDateTime = EventDateTime;
        }

		public void AddMarket(Market market)
		{
			Markets.Add(market);
		}
    }
}