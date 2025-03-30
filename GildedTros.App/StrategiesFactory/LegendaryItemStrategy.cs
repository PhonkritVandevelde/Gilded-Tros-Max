namespace GildedTros.App.StrategiesFactory
{
    public class LegendaryItemStrategy : IUpdateStrategy
    {
        //	- "B-DAWG Keychain", being a legendary item, never has to be sold or decreases in Quality
        //  - Legendary items always have Quality 80.
        public void Update(Item item)
        {
            item.Quality = 80;
            return;
        }
    }
}