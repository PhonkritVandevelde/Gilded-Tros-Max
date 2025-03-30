namespace GildedTros.App.StrategiesFactory
{
    public class GoodWineStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            /*
               - "Good Wine" actually increases in Quality the older it gets
	           - The Quality of an item is never more than 50
             */
            item.SellIn--;
            if (item.Quality < 50) item.Quality++;
        }
    }
}