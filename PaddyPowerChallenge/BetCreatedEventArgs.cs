using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaddyPowerChallenge
{
    public class BetCreatedEventArgs : EventArgs
    {
        public readonly decimal Stake;

        public BetCreatedEventArgs(decimal Stake)
        {
            this.Stake = Stake;
        }
    }
}
