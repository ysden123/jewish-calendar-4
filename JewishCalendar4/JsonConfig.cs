using System.Text.Json;

namespace StulSoft.JewishCalendar4
{
    internal class JsonConfig
    {
        public static readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
