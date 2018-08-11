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
        private NNTools.Layer brain;
        private float cash = 1000.00f;
        private float holdingsValue = 0.00f;
        private List<int> holdings = new List<int>(); //numer of holdings of each stock, ordered same as current network inputs/outputs order

        // Public objects
        public float PortfolioValue => cash + holdingsValue;
        public int Fitness = 0;
        public NNTools.Trainer BrainTrainer { get; }

        // Default Class Constructor
        public StockTrader()
        {
            BrainTrainer = new NNTools.Trainer();
            brain = new NNTools.Layer(BrainTrainer);
        }

        // Class Constructor with initial cash position input
        public StockTrader(float initialFolioValue)
        {
            cash = initialFolioValue;
            BrainTrainer = new NNTools.Trainer();
            brain = new NNTools.Layer(BrainTrainer);
        }

        // Class Constructor with initial cash position and brain inputs; private, for Breeding action only
        private StockTrader(float initialFolioValue, NNTools.Layer newBrain)
        {
            cash = initialFolioValue;
            brain = newBrain;
        }

        // Method to update brain network to reflect exit of a stock from the market
        public void RemoveStock(int index)
        {
            holdings.RemoveAt(index);
            brain.RemoveInput(index);
        }

        // Method to determine trade choices from input current market prices
        public float Trade(IEnumerable<float> currentPrices, float costPerTrade)
        {
            // Check need for new outputs
            while (brain.NodeCount < currentPrices.Count())
            {
                brain.AddNode();
                holdings.Add(0);
            }
            // Run NN brain
            List<int> newHoldings = new List<int>();
            brain.Activate(currentPrices);
            foreach (float o in brain.GetOutputs)
            {
                newHoldings.Add((int)o);
            }
            // Update cash and holdings
            float totalValue = PortfolioValue;
            holdingsValue = 0.0f;
            IEnumerator<float> pricesEnumerator = currentPrices.GetEnumerator();
            for (int i = 0; pricesEnumerator.MoveNext(); i++)
            {
                if (holdings[i] - newHoldings[i] != 0)
                {
                    cash += pricesEnumerator.Current * (holdings[i] - newHoldings[i]) - costPerTrade;
                }
                holdingsValue += pricesEnumerator.Current * newHoldings[i];
                holdings[i] = newHoldings[i];
            }
            // Return percent change in portfolio value
            float pctChg = (totalValue - cash - holdingsValue) / totalValue;
            return pctChg;
        }

        // Method to train brain
        public void Learn(float performance)
        {
            brain.Train(performance);
        }

        // Method to alter NN trainer through breeding
        public StockTrader Breed(StockTrader mate, float newFolioValue)
        {
            return new StockTrader(newFolioValue, new NNTools.Layer(BrainTrainer.Breed(mate.BrainTrainer)));
        }
    }
}
