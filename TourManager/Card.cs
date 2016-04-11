using System;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TourManager
{
	public interface ICard
	{
		/// <summary>
		/// пункт отправления
		/// </summary>
		string From { get; }

		/// <summary>
		/// Пункт назанчения
		/// </summary>
		string To { get; }
	}

	/// <summary>
	/// Карточка путешествия
	/// </summary>
    public class Card : ICard
	{
		public Card([NotNull]string @from, [NotNull]string to)
	    {
		    From = @from;
		    To = to;

			if (string.Equals(@from, to))
				throw new ArgumentException("from equals to");
	    }

	    /// <summary>
		/// пункт отправления
		/// </summary>
		public string From { get; private set; }

		/// <summary>
		/// Пункт назанчения
		/// </summary>
		public string To { get; private set; }
    }

}
