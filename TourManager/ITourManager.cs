using System.Collections.Generic;
using JetBrains.Annotations;

namespace TourManager
{
	public interface ITourManager
	{
		Tour CreateTour([NotNull] IEnumerable<Card> srcCards);
	}
}