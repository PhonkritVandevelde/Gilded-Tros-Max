namespace GildedTros.App.StrategiesFactory
{
    public class SmellyItemStrategy : RegularItemStrategy
    {
        // Smelly items ("Duplicate Code", "Long Methods", "Ugly Variable Names") degrade in Quality twice as fast as normal items

        public override void Update(Item item)
        {
            DecreaseSellIn(item);
            DecreaseQuality(item, item.SellIn < 0 ? 4 : 2);
        }
    }
}