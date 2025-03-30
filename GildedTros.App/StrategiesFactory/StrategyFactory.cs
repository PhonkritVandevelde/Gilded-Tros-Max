namespace GildedTros.App.StrategiesFactory
{
    internal static class StrategyFactory
    {
        public static IUpdateStrategy GetStrategy(string itemName)
        {
            return itemName switch
            {
                "B-DAWG Keychain" => new LegendaryItemStrategy(),
                "Good Wine" => new GoodWineStrategy(),
                var name when name.Contains("Backstage passes") => new BackstagePassesStrategy(),
                "Duplicate Code" or "Long Methods" or "Ugly Variable Names" => new SmellyItemStrategy(),
                _ => new RegularItemStrategy(),
            };
        }
    }
}
