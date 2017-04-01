using System;
using System.Collections.Generic;

namespace PaddyPowerChallenge.Models
{
    public class Market
    {
        public string MarketName { get; set; }
        public bool PredictCorrectScore { get; set; }
        public ActualResult Result { get; set; }
        public IList<BaseSelection> Selections { get; set; }


        public Market()
        {
            Selections = new List<BaseSelection>();
        }

        public Market(string MarketName, bool PredictCorrectScore)
            : this()
        {

        }

        public void AddResult(ActualResult result)
        {
            Result = result;
        }

        public IList<bool> Payouts()
        {
            var payouts = new List<bool>();

            if (Result == null)
            {
                throw new InvalidOperationException("The result is not in yet.");
            }

            foreach (var sel in Selections)
            {
                var payout = sel.DoesPayOut(Result.ActualOutcome, Result.ActualScore);

                payouts.Add(payout);
            }

            return payouts;
        }
    }
}