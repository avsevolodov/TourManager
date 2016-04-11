using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TourManager.UnitTest
{
	[TestClass]
	public class TourManagerTest
	{
		private TourManager _tourManager;

		[TestInitialize]
		public void TestInit()
		{
			_tourManager = new TourManager();
		}

		[TestMethod]
		public void TourManager_ctor()
		{
			Assert.IsNotNull(_tourManager);
		}

		[TestMethod]
		public void TourManager_When_OneCard()
		{
			var tour = _tourManager.CreateTour(new[]
			{
				new Card("1", "2"),
			});

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("2", tour.To, "To");
		}

		[TestMethod]
		public void TourManager_When_TwoCard_Sequantal()
		{
			var tour = _tourManager.CreateTour(new[]
			{
				new Card("1", "2"),
				new Card("2", "3"),
			});

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("3", tour.To, "To");
		}

		[TestMethod]
		public void TourManager_When_ThreeCard_Sequantal()
		{
			var tour = _tourManager.CreateTour(new[]
			{
				new Card("1", "2"),
				new Card("2", "3"),
				new Card("3", "4"),
				
			});

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("4", tour.To, "To");
		}

		[TestMethod]
		public void TourManager_When_ThreeCard_Invert()
		{
			var tour = _tourManager.CreateTour(new[]
			{
				new Card("3", "4"),
				new Card("2", "3"),
				new Card("1", "2"),
				
			});

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("4", tour.To, "To");
		}

		[TestMethod]
		public void TourManager_When_ThreeCard()
		{
			var tour = _tourManager.CreateTour(new[]
			{
				new Card("3", "4"),
				new Card("1", "2"),
				new Card("2", "3"),
				
			});

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("4", tour.To, "To");
		}

		[TestMethod]
		public void TourManager_When_TwoCard_Rnd()
		{
			const int count = 10000;
			var rnd = new Random();
			var cards = Enumerable.Range(0, count)
				.Select(c => new Card(c.ToString(), (c + 1).ToString()))
				.OrderBy(c => rnd.Next());

			var tour = _tourManager.CreateTour(cards);

			Assert.AreEqual("0", tour.From, "From");
			Assert.AreEqual(count.ToString(), tour.To, "To");

			var total = tour.Cards;
			for (int i = 0; i < count; i++)
			{
				Assert.AreEqual(i.ToString(), total[i].From, string.Format("from {0}", i));
				Assert.AreEqual((i + 1).ToString(), total[i].To, string.Format("to {0}", i));
			}
		}
	}
}