using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaddyPowerChallenge.Models
{
    public class BookMaker
    {
        public static decimal GlobalProfit { get; set; }

        public IList<Punter> Punters { get; set; }
        public IList<Event> Events { get; set; }
    }
}
