namespace OpenAILibrary.Model.Embedding;

//see https://platform.openai.com/docs/api-reference/embeddings/create
[JsonIncludePrivateFields]
public class EmbeddingRequest
{
    private string input; 
    private string model;
    private string encoding_format;
    private int? dimensions;
    private string user;
    
    public EmbeddingRequest(
        string input,
        string model,
        EmbeddingRequestOptions options)
    {
        this.input = input;
        this.model = model;
        dimensions = options.dimensions;
        encoding_format = options.encoding_format;
        user = options.user;
    }
}

public record EmbeddingRequestOptions(
    string encoding_format = "float",
    int dimensions = 1536,
    string user = "optional");

public static class EmbeddingRequestFactory
{
    public static EmbeddingRequest CreateRequestModelLarge(string input, EmbeddingRequestOptions? options = null)
    {
        return CreateRequest(input, "text-embedding-3-large", options);
    }
    
    public static EmbeddingRequest CreateRequestModelSmall(string input, EmbeddingRequestOptions? options = null)
    {
        return CreateRequest(input, "text-embedding-3-small", options);
    }
    
    public static EmbeddingRequest CreateRequest(string input, string model, EmbeddingRequestOptions? options = null)
    {
        return new EmbeddingRequest(input, model, options ?? new EmbeddingRequestOptions());
    }
}
    