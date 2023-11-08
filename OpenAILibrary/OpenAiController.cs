using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using OpenAILibrary.Model;

namespace OpenAILibrary;

public class OpenAiController
{
    private readonly HttpClient _httpClient;
    
    public OpenAiController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<string> PostAsync(Request request)
    {
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { Serialization.AddPrivateFieldsModifier }
            }
        };
        
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(request, options),
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await _httpClient.PostAsync(
            "https://api.openai.com/v1/chat/completions",
            jsonContent);

        var jsonResponse = await response.Content.ReadAsStringAsync();

        return await response.Content.ReadAsStringAsync();
    }
}
