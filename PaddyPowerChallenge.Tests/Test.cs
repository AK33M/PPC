using NUnit.Framework;
using PaddyPowerChallenge.Models;

namespace PaddyPowerChallenge.Tests
{
	[TestFixture]
    public class Test
    {
        SportEvent football = new SportEvent("Paddy Power Cup Final", "Clonskeagh", "Tallaght", new System.DateTime(2020, 6, 1, 14, 00, 0));
        SportEvent tennis = new SportEvent("PP group D match 6", "L Harte", "C Ryan", new System.DateTime(2018, 3, 17, 15, 15, 0));

        CorrectScoreSelection correctScoreSelection = new CorrectScoreSelection("Clonskeagh", "255/1", "3-1", WinDrawEnum.Win);

        WinDrawSelection winLossDrawSelection = new WinDrawSelection("Clonskeagh", "11/4", WinDrawEnum.Win);

        MarketResult cupFinal = new MarketResult("Clonskeagh", "2-1", WinDrawEnum.Win);
        MarketResult tennisOutright = new MarketResult("C Ryan", WinDrawEnum.Win);
        MarketResult tennisSet2Game1 = new MarketResult("L Harte", WinDrawEnum.Win);

        Market outrightNormalTime = new Market("Outright in Normal time");


       
        

        [Test]
        public void CalculateOutcome()
        {
            correctScoreSelection.CheckIfWinner("Clonskeagh", WinDrawEnum.Win, "3-1");

            var actualResult = correctScoreSelection.IsWinner;

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CalculateDecimalOdds()
        {

            var expectedResult = (decimal)2.75;

            var actualResult = winLossDrawSelection.PriceInDouble;

            Assert.AreEqual(expectedResult, actualResult);
        }

        //[Test]
        //public void CreateSelectionInMarket()
        //{
        //    var market = new Market("Market");
        //    market.Selections.Add(winLossDrawSelection);
        //    market.Selections.Add(correctScoreSelection);

        //    var foo = market.Selections[0].GetType();
        //    var bar = market.Selections[1].GetType();

        //    Assert.AreEqual(typeof(WinDrawSelection).ToString(), foo.FullName);
        //    Assert.AreEqual(typeof(CorrectScoreSelection).ToString(), bar.FullName);

        //}

        //[Test]
        //public void CheckIfAddResultUpdatesSelections()
        //{
        //    outrightNormalTime.Selections.Add(winLossDrawSelection);
        //    outrightNormalTime.Selections.Add(correctScoreSelection);
        //    //test if throws exception
        //    outrightNormalTime.AddResult(cupFinal);


        //    //test if payouts return true
        //    Assert.IsTrue(outrightNormalTime.Selections[0].IsWinner);
        //    Assert.IsFalse(outrightNormalTime.Selections[1].IsWinner);
        //}

        //[Test]
        //public void CalculateBetPayOut()
        //{
        //    var punter = new Punter("John");
        //    var market = new Market("Champions League Final Winner");
        //    var selectionA = new WinDrawSelection("Team A", "2/1", WinDrawEnum.Win);
        //    var selectionB = new WinDrawSelection("Team B", "2/1", WinDrawEnum.Win);
        //    var result = new MarketResult("Team A", WinDrawEnum.Win);

        //    market.AddSelection(selectionA);
        //    market.AddSelection(selectionB);
        //    market.AddResult(result);

        //    punter.PlaceBet(new Bet(selectionA, 10));
        //    //punter.PlaceBet(new Bet(selectionB, 10));

        //    var payoutA = punter.Bet.GetBetPayOut();
        //    //var payoutB = punter.Bets[1].GetBetPayOut();

        //    var expectedPayoutA = 30.00;
        //    var expectedPayoutB = 00.00;

        //    Assert.AreEqual(expectedPayoutA, payoutA);
        //   // Assert.AreEqual(expectedPayoutB, payoutB);

        //}

        [Test]
        public void BroadcastBetCreated()
        {
            var selection = new WinDrawSelection("Team A", "2/1", WinDrawEnum.Win);
			decimal stakeEvent = 0;
            Bet.BetCreated += delegate (object sender, BetCreatedEventArgs e)
            {
                stakeEvent = e.Stake;
            };
            var bet = new Bet(selection, 10);
            


            Assert.AreEqual(10, stakeEvent);
        }

        [Test]
        public void CheckGlobalPofitLoss()
        {
            var paddyPower = new BookMaker();
            var market = new Market("Champions League Final Winner");

            var selection = new WinDrawSelection("Team A", "2/1", WinDrawEnum.Win);
            var result = new MarketResult("Team A", WinDrawEnum.Win);

            var punter = new Punter("John");
            var bet = new Bet(selection, 10);

            market.AddSelection(selection);
			market.AddResult(result);

			punter.PlaceBet(bet);
			punter.CollectWinnings();


            Assert.AreEqual(-20, BookMaker.GlobalProfit);

        }
    }
}
