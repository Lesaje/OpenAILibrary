using System.Text.Json.Serialization;

namespace OpenAILibrary.Model;

//see https://platform.openai.com/docs/api-reference/chat/create
[JsonIncludePrivateFields]
public class Request
{
    private Message[] messages;
    private string model;
    private double frequency_penalty;
    //"None is not of type 'object' - 'logit_bias'", https://github.com/openai/openai-python/issues/288
    //private object logit_bias;
    private int? max_tokens;    //do not change to non-nullable
    private int n;
    private double presence_penalty;
    private string[] stop;
    private bool stream;
    private double temperature;
    private double top_p;
    private string user;

    public Request(
        Message[] messages,
        string model,
        RequestOptions options)
    {
        this.messages = messages;
        this.model = model;
        frequency_penalty = options.frequencyPenalty;
        max_tokens = options.maxTokens;
        n = options.n;
        presence_penalty = options.presencePenalty;
        stop = options.stop;
        stream = options.stream;
        temperature = options.temperature;
        top_p = options.topP;
        user = options.user;
    }
}

public record RequestOptions(
    double frequencyPenalty = 0,
    int? maxTokens = null,
    int n = 1,
    double presencePenalty = 0,
    string[]? stop = null,
    bool stream = false,
    double temperature = 1,
    double topP = 1,
    string user = "optional");

public static class RequestFactory
{
  
    public static Request CreateRequestGPT4_Turbo(Message[] messages, RequestOptions? options = null)
    {
        return CreateRequest(messages, "gpt-4-1106-preview", options);
    }
    
    public static Request CreateRequestGPT4_32K(Message[] messages, RequestOptions? options = null)
    {
        return CreateRequest(messages, "gpt-4-32k", options);
    }
    
    public static Request CreateRequestGPT4_8K(Message[] messages, RequestOptions? options = null)
    {
        return CreateRequest(messages, "gpt-4", options);
    }
    
    public static Request CreateRequestGPT3_16K(Message[] messages, RequestOptions? options = null)
    {
        return CreateRequest(messages, "gpt-3.5-turbo-16k", options);
    }
    
    public static Request CreateRequestGPT3_4K(Message[] messages, RequestOptions? options = null)
    {
        return CreateRequest(messages, "gpt-3.5-turbo", options);
    }
    
    public static Request CreateRequest(Message[] messages, string model, RequestOptions? options = null)
    {
        if (options is null)
        {
            return new Request(messages, model, new RequestOptions());
        }
        return new Request(messages, model, options);
    }
}