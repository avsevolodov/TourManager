using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TourManager.UnitTest
{
	[TestClass]
	public class TourTest
	{
		[TestMethod]
		public void Tour_When_OneCard()
		{
			var tour = new Tour(new Card("1", "2"));

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("2", tour.To, "To");
		}

		[TestMethod]
		public void Tour_When_AddLast()
		{
			var tour = new Tour(new Card("1", "2"));
			tour.AddLast(new Card("2", "3"));

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("3", tour.To, "To");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Tour_When_AddLast_To_NotEqual_From()
		{
			var tour = new Tour(new Card("1", "2"));
			tour.AddLast(new Card("1", "4"));
		}

		[TestMethod]
		public void Tour_When_AddBefore()
		{
			var tour = new Tour(new Card("2", "3"));
			tour.AddBefore(new Card("1", "2"));

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("3", tour.To, "To");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Tour_When_AddBefore_From_NotEqual_To()
		{
			var tour = new Tour(new Card("1", "2"));
			tour.AddBefore(new Card("1", "2"));
		}

		[TestMethod]
		public void Tour_When_AddLastTour()
		{
			var tour = new Tour(new Card("1", "2"));
			var subTour = new Tour(new Card("2", "3"));
			tour.AddLastTour(subTour);

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("3", tour.To, "To");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Tour_When_AddLastTour_To_NotEqual_From()
		{
			var tour = new Tour(new Card("1", "2"));
			var subTour = new Tour(new Card("1", "2"));
			tour.AddLastTour(subTour);
		}

		[TestMethod]
		public void Tour_When_AddBeforeTour()
		{
			var tour = new Tour(new Card("2", "3"));
			var subTour = new Tour(new Card("1", "2"));
			tour.AddBeforeTour(subTour);

			Assert.AreEqual("1", tour.From, "From");
			Assert.AreEqual("3", tour.To, "To");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Tour_When_AddBeforeTour_From_NotEqual_To()
		{
			var tour = new Tour(new Card("1", "2"));
			var subTour = new Tour(new Card("1", "2"));
			tour.AddBeforeTour(subTour);
		}
	}
}
