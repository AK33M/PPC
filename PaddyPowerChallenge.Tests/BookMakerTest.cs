using NUnit.Framework;
using PaddyPowerChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaddyPowerChallenge.Tests
{
    [TestFixture]
    public class BookMakerTest
    {
        [Test]
        public void CreateBookMakerWithDefaultConstructorHasDefaultValues()
        {
            var bookMaker = new BookMaker();
            var defaultPunters = new List<Punter>();
            var defaultEvents = new List<SportEvent>();

            
        }

        [Test]
        public void AddEventAfterCreateBookMakerWithDefaultConstructor()
        {
			var bookMaker = new BookMaker();
			var sportEvent = new SportEvent();

			bookMaker.AddEvent(sportEvent);

		}
    }
}
