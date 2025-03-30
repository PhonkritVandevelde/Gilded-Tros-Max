using System;

namespace GildedTros.App.StrategiesFactory
{
    public class RegularItemStrategy : IUpdateStrategy
    {
        // Once the sell by date has passed, Quality degrades twice as fast
        public virtual void Update(Item item)
        {
            DecreaseSellIn(item);
            DecreaseQuality(item, item.SellIn < 0 ? 2 : 1);
        }

        protected void DecreaseSellIn(Item item) => item.SellIn--;

        protected void DecreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}