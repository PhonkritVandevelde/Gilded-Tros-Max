using System;

namespace GildedTros.App.StrategiesFactory
{
    public class BackstagePassesStrategy : IUpdateStrategy
    {
        /*	- "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches;
			Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
			Quality drops to 0 after the conference
        */
        public void Update(Item item)
        {
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            int qualityIncrease = 1;

            if (item.SellIn <= 5)
                qualityIncrease = 3;
            else if (item.SellIn <= 10)
                qualityIncrease = 2;

            // Apply Quality = 50 if item.Quality + increase exceed 50
            item.Quality = Math.Min(50, item.Quality + qualityIncrease);
        }
    }

}