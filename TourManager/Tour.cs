using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace TourManager
{
	public class Tour
	{
		/// <summary>
		/// ”пор€доченный список карточек, не пустой
		/// </summary>
		private readonly LinkedList<Card>  _queue = new LinkedList<Card>();

		public Tour([NotNull]Card card)
		{
			_queue.AddLast(card);
		}

		public void AddLast(Card card)
		{
			if (_queue.Last.Value.To != card.From)
				throw new ArgumentException("_queue.Last.To != card.From");

			_queue.AddLast(card);
		}

		public void AddBefore(Card card)
		{
			if (_queue.First.Value.From != card.To)
				throw new ArgumentException("_queue.First.From != card.To");

			_queue.AddFirst(card);
		}

		public void AddLastTour(Tour tour)
		{
			if(_queue.Last.Value.To != tour.From)
				throw new ArgumentException("_queue.Last.To != tour.From");

			foreach (var card in tour.Cards)
				_queue.AddLast(card);
		}

		public void AddBeforeTour(Tour tour)
		{
			if(_queue.First.Value.From!= tour.To)
				throw new ArgumentException("_queue.First.From != tour.To");

			foreach (var card in tour.Cards)
				_queue.AddFirst(card);
		}

		[NotNull]
		public string To
		{
			get { return _queue.Last.Value.To; }
		}

		[NotNull]
		public string From
		{
			get { return _queue.First.Value.From; }
		}

		public Card[] Cards
		{
			get { return _queue.ToArray(); }
		}
	}
}