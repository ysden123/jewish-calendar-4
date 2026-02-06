using StulSoft.JewishCalendar4.Data;

namespace StulSoft.TestProject.Data
{
    public class CandleLightItemTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeserializationTest()
        {
            string json = """
                {               
                  "category": "candles",
                  "date": "2024-04-19T18:51:00+03:00",
                  "hebrew": "\u05d4\u05d3\u05dc\u05e7\u05ea \u05e0\u05e8\u05d5\u05ea",
                  "memo": "Parashat Metzora",
                  "title": "Candle lighting: 18:51",
                  "title_orig": "Candle lighting"
                }
                """;
            CandleLightItem? candleLightItem = Utils.CandleLightItemFromJson(json);
            Assert.That(candleLightItem, Is.Not.Null);
            Assert.That(candleLightItem.Category, Is.EqualTo("candles"));
            Assert.Pass();
        }
    }
}
