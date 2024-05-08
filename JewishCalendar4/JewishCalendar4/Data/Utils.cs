using System.Text.Json;

namespace StulSoft.JewishCalendar4.Data
{
    internal class Utils
    {
        public static CandleLightItem? CandleLightItemFromJson(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<CandleLightItem>(json, JsonConfig.options);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static CandleLightResponse? CandleLightResponseFromJson(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<CandleLightResponse>(json, JsonConfig.options);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? ExtractDate(string date)
        {
            return DateTime.Parse(date);
        }

        public static HebDate? HebDateFromJson(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<HebDate>(json, JsonConfig.options);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
