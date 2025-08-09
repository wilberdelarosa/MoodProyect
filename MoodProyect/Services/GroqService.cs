using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MoodProyect.Models;

namespace MoodProyect.Services;

public class GroqService : IGroqService
{
    private readonly HttpClient _httpClient;

    public GroqService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GroqResult> GetAdviceAsync(QuizSession session)
    {
        var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            return new GroqResult("No hay API key configurada.", "Configura GROQ_API_KEY.");
        }

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.groq.com/openai/v1/chat/completions");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var payload = new
        {
            model = "llama-3.1-70b-versatile",
            messages = new object[]
            {
                new { role = "system", content = "Coach breve en español, máximo 120 palabras, incluye un ejercicio <=3 pasos, sin diagnóstico médico." },
                new { role = "user", content = BuildUserPrompt(session) }
            }
        };

        request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);
            var content = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            if (string.IsNullOrWhiteSpace(content))
                return new GroqResult("No se obtuvo respuesta.", "Sigue adelante.");
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var advice = lines.FirstOrDefault() ?? content;
            var closing = lines.Length > 1 ? lines.Last() : "Sigue adelante.";
            return new GroqResult(advice, closing);
        }
        catch
        {
            return new GroqResult("No se pudo obtener consejo en este momento.", "Intenta nuevamente más tarde.");
        }
    }

    private static string BuildUserPrompt(QuizSession session)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Respuestas del usuario:");
        foreach (var item in session.Answers)
        {
            sb.AppendLine($"{item.Key}: {item.Value}");
        }
        sb.AppendLine("Proporciona un consejo breve y una frase de cierre motivadora.");
        return sb.ToString();
    }
}
