using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaddyPowerChallenge.Models
{
    public class ActualResult
    {
        public string TeamName { get; set; }
        public WinLossDrawEnum ActualOutcome { get; set; }
        public string ActualScore { get; set; }


        public ActualResult(string TeamName, WinLossDrawEnum ActualOutcome)
        {
            this.TeamName = TeamName;
            this.ActualScore = string.Empty;
            this.ActualOutcome = ActualOutcome;
        }

        public ActualResult(string TeamName, string ActualScore, WinLossDrawEnum ActualOutcome)
        {
            this.TeamName = TeamName;
            this.ActualScore = ActualScore;
            this.ActualOutcome = ActualOutcome;
        }
    }
}
