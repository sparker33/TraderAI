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
        private NNTools.FloatToBoolNetwork brain; //need to replace this with a FloatToIntNetwork
        private float cash;
        private List<int> holdings; //numer of holdings of each stock, ordered same as current network inputs/outputs order

        // Public objects
        //reserved

        // Default Class Constructor
        public StockTrader()
        {

        }

        // Class Constructor with initial cash position input
        public StockTrader(float initialFolioValue)
        {
            cash = initialFolioValue;
        }

        // Class Constructor with initial cash position and brain inputs; private, for Breeding action only
        private StockTrader(float initialFolioValue, NNTools.FloatToBoolNetwork newBrain)
        {
            cash = initialFolioValue;
            brain = newBrain;
        }

        // Method to update brain network to reflect exit of a stock from the market
        public void RemoveStock(int index)
        {
            holdings.RemoveAt(index);
            brain.RemoveOutput(index);
            //brain.RemoveInput(index); This method needs to be added to NNTools.FloatToBoolNetwork
        }

        // Method to determine trade choices from input current market prices
        public float Trade(IEnumerable<float> currentPrices, float costPerTrade)
        {
            // Check  need for new outputs
            //reserved
            // Run NN brain
            //reserved
            // Update cash and holdings
            //reserved
            // Return percent change in portfolio value
            return 0.0f;
        }

        // Method to train brain
        public void Learn(float performance)
        {

        }

        // Method to alter NN trainer through breeding
        public StockTrader Breed(StockTrader mate, float newFolioValue)
        {
            NNTools.FloatToBoolNetwork childBrain = new NNTools.FloatToBoolNetwork();
            return new StockTrader(newFolioValue, childBrain);
        }
    }
}
