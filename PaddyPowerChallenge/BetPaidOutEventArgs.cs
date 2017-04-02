using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaddyPowerChallenge
{
    public class BetPaidOutEventArgs: EventArgs
    {
        public decimal PayOut { get; private set; }
        public decimal Stake { get; private set; }

        public BetPaidOutEventArgs(decimal Stake, decimal PayOut)
        {
            this.Stake = Stake;
            this.PayOut = PayOut;
        }
    }
}
