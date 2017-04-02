using PaddyPowerChallenge.Models;
using System;

namespace PaddyPowerChallenge.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//Create instance of Company 
			var paddyPower = new BookMaker();

			//Create football event
			var footballEvent = new SportEvent("Paddy Power Cup Final", "Clonskeagh", "Tallaght", new DateTime(2020, 6, 1, 14, 0, 0));
			var tennisEvent = new SportEvent("PP group D match 6", "L Harte", "C Ryan", new System.DateTime(2018, 3, 17, 15, 15, 0));

			//Create various markets
			var footballOutrightResultMarket = new Market("Outright Result in Normal Time");
			var footballCorrectScoreMarket = new Market("Correct Score");

			var tennisMatchResultMarket = new Market("Match Betting Market");
			var tennisSet2Game1Market = new Market("To Win Set 2 1st game");

			//Create various selections
			var clonskeaghToWin = new WinDrawSelection("Clonskeagh", "11/4", WinDrawEnum.Win);
			var tallaghtToWin = new WinDrawSelection("Tallaght", "13/5", WinDrawEnum.Win);
			var outrightDraw = new WinDrawSelection("Clonskeagh", "4/6", WinDrawEnum.Draw);//*

			var clonskeaghCorrectScoreA = new CorrectScoreSelection("Clonskeagh", "4/9", "1-0", WinDrawEnum.Win);
			var clonskeaghCorrectScoreB = new CorrectScoreSelection("Clonskeagh", "11/2", "2-0", WinDrawEnum.Win);
			var clonskeaghCorrectScoreC = new CorrectScoreSelection("Clonskeagh", "22/1", "2-1", WinDrawEnum.Win);
			var clonskeaghCorrectScoreD = new CorrectScoreSelection("Clonskeagh", "55/1", "3-0", WinDrawEnum.Win);
			var clonskeaghCorrectScoreE = new CorrectScoreSelection("Clonskeagh", "255/1", "3-1", WinDrawEnum.Win);

			var goallessDraw = new CorrectScoreSelection("Clonskeagh", "9/2", "0-0", WinDrawEnum.Draw);
			var scoredDrawA = new CorrectScoreSelection("Clonskeagh", "175/1", "1-1", WinDrawEnum.Draw);
			var scoredDrawB = new CorrectScoreSelection("Clonskeagh", "225/1", "2-2", WinDrawEnum.Draw);

			var tallaghtCorrectScoreA = new CorrectScoreSelection("Tallaght", "12/1", "1-0", WinDrawEnum.Win);
			var tallaghtCorrectScoreB = new CorrectScoreSelection("Tallaght", "9/2", "2-0", WinDrawEnum.Win);
			var tallaghtCorrectScoreC = new CorrectScoreSelection("Tallaght", "17/1", "2-1", WinDrawEnum.Win);
			var tallaghtCorrectScoreD = new CorrectScoreSelection("Tallaght", "3-0", "16/5", WinDrawEnum.Win);
			var tallaghtCorrectScoreE = new CorrectScoreSelection("Tallaght", "3-1", "14/1", WinDrawEnum.Win);


			//Tennis Event Selections
			var lHarteToWin = new WinDrawSelection("L Harte", "9/4", WinDrawEnum.Win);
			var cRyanToWin = new WinDrawSelection("C Ryan", "3/10", WinDrawEnum.Win);

			var lHarteToWinSet2Game1 = new WinDrawSelection("L Harte", "4/7", WinDrawEnum.Win);
			var cRyanToWinSet2Game1 = new WinDrawSelection("C Ryan", "5/4", WinDrawEnum.Win);

			//Create Event-Market-Selection hierarachy
			//Add Selections to Market
			footballOutrightResultMarket.AddSelection(clonskeaghToWin);
			footballOutrightResultMarket.AddSelection(tallaghtToWin);
			footballOutrightResultMarket.AddSelection(outrightDraw);

			footballCorrectScoreMarket.AddSelection(clonskeaghCorrectScoreA);
			footballCorrectScoreMarket.AddSelection(clonskeaghCorrectScoreB);
			footballCorrectScoreMarket.AddSelection(clonskeaghCorrectScoreC);
			footballCorrectScoreMarket.AddSelection(clonskeaghCorrectScoreD);
			footballCorrectScoreMarket.AddSelection(clonskeaghCorrectScoreE);

			footballCorrectScoreMarket.AddSelection(goallessDraw);
			footballCorrectScoreMarket.AddSelection(scoredDrawA);
			footballCorrectScoreMarket.AddSelection(scoredDrawB);

			footballCorrectScoreMarket.AddSelection(tallaghtCorrectScoreA);
			footballCorrectScoreMarket.AddSelection(tallaghtCorrectScoreB);
			footballCorrectScoreMarket.AddSelection(tallaghtCorrectScoreC);
			footballCorrectScoreMarket.AddSelection(tallaghtCorrectScoreD);
			footballCorrectScoreMarket.AddSelection(tallaghtCorrectScoreE);

			tennisMatchResultMarket.AddSelection(lHarteToWin);
			tennisMatchResultMarket.AddSelection(cRyanToWin);

			tennisSet2Game1Market.AddSelection(lHarteToWinSet2Game1);
			tennisSet2Game1Market.AddSelection(cRyanToWinSet2Game1);

			//Add Markets to Event
			footballEvent.AddMarket(footballOutrightResultMarket);
			footballEvent.AddMarket(footballCorrectScoreMarket);

			tennisEvent.AddMarket(tennisMatchResultMarket);//test about adding wrong market to wrong event
			tennisEvent.AddMarket(tennisSet2Game1Market);

			//Add Events to BookMaker
			paddyPower.AddEvent(footballEvent);
			paddyPower.AddEvent(tennisEvent);



			//Punters Bets
			var punterA = new Punter("Punter A");
			paddyPower.AddPunter(punterA);
			punterA.PlaceBet(new Bet(clonskeaghToWin, 4));

			var punterB = new Punter("Punter B");
			paddyPower.AddPunter(punterB);
			punterB.PlaceBet(new Bet(cRyanToWinSet2Game1, 5));

			var punterC = new Punter("Punter C");
			paddyPower.AddPunter(punterC);
			punterC.PlaceBet(new Bet(cRyanToWin, 5));

			var punterD = new Punter("Punter D");
			paddyPower.AddPunter(punterD);
			punterD.PlaceBet(new Bet(clonskeaghCorrectScoreE, 2));

			var punterE = new Punter("Punter E");
			paddyPower.AddPunter(punterE);
			punterE.PlaceBet(new Bet(tallaghtCorrectScoreA, 1));

			var punterF = new Punter("Punter F");
			paddyPower.AddPunter(punterF);
			punterF.PlaceBet(new Bet(lHarteToWinSet2Game1, 5));

			var punterG = new Punter("Punter G");
			paddyPower.AddPunter(punterG);
			punterG.PlaceBet(new Bet(clonskeaghCorrectScoreE, 2));

			var punterH = new Punter("Punter H");
			paddyPower.AddPunter(punterH);
			punterH.PlaceBet(new Bet(tallaghtCorrectScoreC, 1));

			var punterI = new Punter("Punter I");
			paddyPower.AddPunter(punterI);
			punterI.PlaceBet(new Bet(outrightDraw, 4));

			var punterJ = new Punter("Punter J");
			paddyPower.AddPunter(punterJ);
			punterJ.PlaceBet(new Bet(clonskeaghToWin, 2));

			var punterK = new Punter("Punter K");
			paddyPower.AddPunter(punterK);
			punterK.PlaceBet(new Bet(clonskeaghCorrectScoreB, 10));

			var punterL = new Punter("Punter L");
			paddyPower.AddPunter(punterL);
			punterL.PlaceBet(new Bet(cRyanToWin, 6));

			var punterM = new Punter("Punter M");
			paddyPower.AddPunter(punterM);
			punterM.PlaceBet(new Bet(tallaghtToWin, 1));

			var punterN = new Punter("Punter N");
			paddyPower.AddPunter(punterN);
			punterN.PlaceBet(new Bet(lHarteToWin, 0.5M));

			var punterO = new Punter("Punter O");
			paddyPower.AddPunter(punterO);
			punterO.PlaceBet(new Bet(clonskeaghCorrectScoreB, 2));

			var punterP = new Punter("Punter P");
			paddyPower.AddPunter(punterP);
			punterP.PlaceBet(new Bet(tallaghtToWin, 1));

			var punterQ = new Punter("Punter Q");
			paddyPower.AddPunter(punterQ);
			punterQ.PlaceBet(new Bet(lHarteToWinSet2Game1, 1));

			var punterR = new Punter("Punter R");
			paddyPower.AddPunter(punterR);
			punterR.PlaceBet(new Bet(tallaghtCorrectScoreA, 11));

			//Results are IN!
			var footballResult = new MarketResult("Clonskeagh", "2-1", WinDrawEnum.Win);
			var tennisOutrightResult = new MarketResult("C Ryan", WinDrawEnum.Win);
			var tennisSet2Game1Result = new MarketResult("L Harte", WinDrawEnum.Win);

			footballOutrightResultMarket.AddResult(footballResult);
			footballCorrectScoreMarket.AddResult(footballResult);
			tennisMatchResultMarket.AddResult(tennisOutrightResult);
			tennisSet2Game1Market.AddResult(tennisSet2Game1Result);

			//Punters Collect Winnings
			foreach (var punter in paddyPower.Punters)
			{
				punter.CollectWinnings();
				Console.WriteLine(punter.ToString());				
			}

			Console.WriteLine($"Overall Balance of Company is {BookMaker.GlobalProfit.ToString("C")}");
		}
	}
}
