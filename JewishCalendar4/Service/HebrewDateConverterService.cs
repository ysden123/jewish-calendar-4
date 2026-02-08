using Google.GenAI;
using StulSoft.JewishCalendar4.Data;
using System.Net.Http;

namespace StulSoft.JewishCalendar4.Service
{
    internal class HebrewDateConverterService
    {
        public static Task<string?> GetHebrewDateAsync(DateTime gregDate)
        {
            return Task.Run(() =>
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
                        return Task.FromResult<string?>("ERROR. Cannot get hebrew date");
                    }
                    else
                    {
                        string resultPart1 = $"{hebrewDate.Hy}, {hebrewDate.Hm}, {hebrewDate.Hd}, {hebrewDate.Hebrew}\n";
                        var apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY");
                        var gminiClient = new Client(null, apiKey);
                        var gminiRequest = $"Когда в {DateTime.UtcNow.Year} году будет {hebrewDate.Hm}, {hebrewDate.Hd} (одной строкой)?";
                        string resultPart2;
                        var gminiTask = Task.Run(() => gminiClient.Models.GenerateContentAsync(
                                              model: "gemini-3-flash-preview", contents: gminiRequest
                                              ));
                        gminiTask.Wait();
                        if (gminiTask.IsCompletedSuccessfully)
                        {
                            resultPart2 = "Failed to extract text from the Gemini API response.\n";
                            var response = gminiTask.Result;
                            if (response != null && response.Candidates != null && response.Candidates.Count > 0)
                            {
                                var candidate = response.Candidates[0];
                                var content = candidate?.Content;
                                var parts = content?.Parts;
                                if (parts != null && parts.Count > 0 && parts[0]?.Text != null)
                                {
                                    resultPart2 = parts[0].Text!;
                                }
                            }
                        }
                        else
                        {
                            resultPart2 = "Failed to get a response from the Gemini API.\n";
                        }

                        return Task.FromResult<string?>(resultPart1 + resultPart2);
                    }
                }
                catch (Exception exc)
                {
                    return Task.FromResult<string?>($"An error occurred: {exc.Message}");
                }
            });
        }
    }
}
