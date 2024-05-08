using StulSoft.JewishCalendar4.Data;
using System.Net.Http;

namespace StulSoft.JewishCalendar4.Service
{
    internal class CandleService
    {
        public static string? GetCandleLightDate()
        {
            var client = new HttpClient();
            try
            {
                var task = Task.Run(() => client.GetStringAsync("https://www.hebcal.com/shabbat?cfg=json&geo=293397&city=IL-Tel%20Aviv&m=50&leyning=off&b=22"));
                task.Wait();
                var response = Utils.CandleLightResponseFromJson(task.Result);
                if (response != null)
                {
                    var items = from item in response.Items
                                where item.Title_orig == "Candle lighting" && item.Category == "candles"
                                select item;
                    if (items != null && items.Count() > 0)
                    {
                        try
                        {
                            var firstDate = items.First().Date;
                            if (firstDate != null)
                            {
                                return Utils.ExtractDate(firstDate).ToString();
                            }
                            else
                            {
                                return "No date";
                            }
                        }catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    }
                    else
                    {
                        return "ERROR2";
                    }
                }
                else
                {
                    return "No response";
                }
                
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
