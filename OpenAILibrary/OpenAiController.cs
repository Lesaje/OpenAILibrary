using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using OpenAILibrary.Model;
using OpenAILibrary.Model.Completion;
using OpenAILibrary.Model.Embedding;

namespace OpenAILibrary;

public class OpenAiController
{
    private readonly HttpClient _httpClient;
    
    public OpenAiController(string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
    }
    
    public async Task<string> SendCompletionRequest(CompletionRequest completionRequest)
    {
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { Serialization.AddPrivateFieldsModifier }
            }
        };
        
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(completionRequest, options),
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await _httpClient.PostAsync(
            "https://api.openai.com/v1/chat/completions",
            jsonContent);

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> SendEmbeddingRequest(EmbeddingRequest embeddingRequest)
    {
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { Serialization.AddPrivateFieldsModifier }
            }
        };
        
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(embeddingRequest, options),
            Encoding.UTF8,
            "application/json");
        
        using HttpResponseMessage response = await _httpClient.PostAsync(
            "https://api.openai.com/v1/embeddings",
            jsonContent);
        
        return await response.Content.ReadAsStringAsync();
    }
}
