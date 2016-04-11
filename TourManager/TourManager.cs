using System;
using System.Collections.Generic;
using System.Linq;

namespace TourManager
{
	public class TourManager : ITourManager
	{
		public Tour CreateTour(IEnumerable<Card> srcCards)
		{
			var hashFrom = new Dictionary<string, Tour>();	// индекс городов, где оканчиваются туры
			var hashTo = new Dictionary<string, Tour>();	// индекс городов, где начинаются туры

			// создаем из карточек туры по мере поступления. Сложность алогритма - О(N)
			foreach (var card in srcCards)
			{
				Tour tour;
				if (hashFrom.TryGetValue(card.To, out tour))
				{
					hashFrom.Remove(card.To);
					tour.AddBefore(card);
					hashFrom.Add(tour.From, tour);
					continue;
				}
				if (hashTo.TryGetValue(card.From, out tour))
				{
					hashTo.Remove(card.From);
					tour.AddLast(card);
					hashTo.Add(tour.To, tour);
					continue;
				}
				tour = new Tour(card);

				hashFrom.Add(tour.From, tour);
				hashTo.Add(tour.To, tour);
			}

			if (hashTo.Count != hashFrom.Count)
				throw new InvalidOperationException("Исходные данные не удовлетворяют условию задачи");

			Tour result = null;
			foreach (var pair in hashFrom)
			{
				if (!hashTo.TryGetValue(pair.Value.From, out result))
				{
					result = pair.Value;
					continue;
				}

				result.AddLastTour(pair.Value);

				hashTo[result.To] = result;
			}

			return result;
		}
	}
}