using StulSoft.JewishCalendar4.Data;
using System.Net.Http;

namespace StulSoft.JewishCalendar4.Service
{
    internal class HebrewDateConverterService
    {
        public static string? GetHebrewDate(DateTime gregDate)
        {
            var client = new HttpClient();
            try
            {
                string year = gregDate.Year.ToString();
                string month = gregDate.Month.ToString();
                string day = gregDate.Day.ToString();
                var url = $"https://www.hebcal.com/converter?cfg=json&gy={year}&gm={month}&gd={day}&g2h=1";
                var task = Task.Run(() => client.GetStringAsync(url));
                task.Wait();
                var hebrewDate = Utils.HebDateFromJson(task.Result);
                if (hebrewDate == null)
                {
                    return "ERROR";
                }
                else
                {
                    return $"{hebrewDate.Hy}, {hebrewDate.Hm}, {hebrewDate.Hd}, {hebrewDate.Hebrew}";
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
