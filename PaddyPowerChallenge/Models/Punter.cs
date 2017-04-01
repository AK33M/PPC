using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaddyPowerChallenge.Models
{
    public class Punter
    {
        public string Name { get; set; }
        public IList<Bet> Bets { get; set; }

		public Punter(string Name)
		{
			this.Name = Name;
			this.Bets = new List<Bet>();
		}

		public void PlaceBet(Bet bet)
		{
			Bets.Add(bet);
		}
	}
}
