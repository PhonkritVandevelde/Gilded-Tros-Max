using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void RegularItem_DecreasesSellInAndQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Regular Item", SellIn = 10, Quality = 20 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(19, items[0].Quality);
        }

        [Fact]
        public void RegularItem_QualityNeverNegative()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Regular Item", SellIn = 10, Quality = 0 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void GoodWine_IncreasesQualityOverTime()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Good Wine", SellIn = 10, Quality = 10 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void GoodWine_QualityCappedAt50()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Good Wine", SellIn = 10, Quality = 50 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(50, items[0].Quality); // Quality should not exceed 50
        }

        [Fact]
        public void BDAWGKeychain_QualityAndSellInNeverChange()
        {
            IList<Item> items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 10, Quality = 80 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(10, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_IncreaseQualityAsSellInApproaches()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 15, Quality = 20 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_IncreaseQualityBy2_When10DaysOrLess()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 10, Quality = 20 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(22, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_IncreaseQualityBy3_When5DaysOrLess()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 5, Quality = 20 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(23, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_QualityDropsToZero_AfterEvent()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 0, Quality = 20 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void SmellyItems_DegradeInQualityTwiceAsFast()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Duplicate Code", SellIn = 10, Quality = 20 }, new Item { Name = "Duplicate Code", SellIn = 0, Quality = 20 } };
            GildedTros app = new GildedTros(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(18, items[0].Quality);
            Assert.Equal(-1, items[1].SellIn);
            Assert.Equal(16, items[1].Quality);
        }


    }
}