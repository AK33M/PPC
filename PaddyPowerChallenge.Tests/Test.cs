using NUnit.Framework;
using System;

namespace PaddyPowerChallenge.Tests
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void CalculateOutcome()
		{
			var selection = new WinLossDrawSelection("Clonskeagh", "11/4", WinLossDrawEnum.Win);
			var expectedResult = true;

			var actualResult = selection.DoesPayOut(WinLossDrawEnum.Win);

			Assert.AreSame(expectedResult, actualResult);
		}
	}
}
