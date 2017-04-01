using NUnit.Framework;
using PaddyPowerChallenge.Models;
using System;
using System.Collections.Generic;

namespace PaddyPowerChallenge.Tests
{
    [TestFixture]
    public class Test
    {
        Event football = new Event("Paddy Power Cup Final", "Clonskeagh", "Tallaght", new System.DateTime(2020, 6, 1, 14, 00, 0));
        Event tennis = new Event("PP group D match 6", "L Harte", "C Ryan", new System.DateTime(2018, 3, 17, 15, 15, 0));

        CorrectScoreSelection correctScoreSelection = new CorrectScoreSelection("Clonskeagh", "255/1", "3-1", WinLossDrawEnum.Win);

        WinLossDrawSelection winLossDrawSelection = new WinLossDrawSelection("Clonskeagh", "11/4", WinLossDrawEnum.Win);

        ActualResult cupFinal = new ActualResult("Clonskeagh", "2-1", WinLossDrawEnum.Win);
        ActualResult tennisOutright = new ActualResult("C Ryan", WinLossDrawEnum.Win);
        ActualResult tennisSet2Game1 = new ActualResult("L Harte", WinLossDrawEnum.Win);

        Market outrightNormalTime = new Market("Outright in Normal time", false);

        [Test]
        public void CalculateOutcome()
        {

            var expectedResult = true;

            var actualResult = correctScoreSelection.DoesPayOut(WinLossDrawEnum.Win, "3-1");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateDecimalOdds()
        {

            var expectedResult = (decimal)2.75;

            var actualResult = winLossDrawSelection.DecimalOdds;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CreateSelectionInMarket()
        {
            var market = new Market();
            market.Selections.Add(winLossDrawSelection);
            market.Selections.Add(correctScoreSelection);

            var foo = market.Selections[0].GetType();
            var bar = market.Selections[1].GetType();

            Assert.AreEqual(typeof(WinLossDrawSelection).ToString(), foo.FullName);
            Assert.AreEqual(typeof(CorrectScoreSelection).ToString(), bar.FullName);

        }

        [Test]
        public void CalculatePayOut()
        {
            outrightNormalTime.Selections.Add(winLossDrawSelection);
            outrightNormalTime.Selections.Add(correctScoreSelection);
            //test if throws exception
            outrightNormalTime.AddResult(cupFinal);

            //test if payouts return true
            Assert.IsTrue(outrightNormalTime.Payouts()[0]);
            Assert.IsFalse(outrightNormalTime.Payouts()[1]);
        }
    }
}
