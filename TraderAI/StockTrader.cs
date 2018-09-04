using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderAI
{
	public class StockTrader
	{
		// Private objects
		private float cash = 1000.00f;
		private float holdingsValue = 0.00f;

		// Public objects
		public float PortfolioValue => cash + holdingsValue;

		/// <summary>
		/// Default Class Constructor
		/// </summary>
		public StockTrader()
		{

		}

		/// <summary>
		/// Class Constructor with initial cash position input
		/// </summary>
		/// <param name="initialFolioValue"> Initial cash holdings. </param>
		public StockTrader(float initialFolioValue)
		{
			cash = initialFolioValue;
		}
	}
}
