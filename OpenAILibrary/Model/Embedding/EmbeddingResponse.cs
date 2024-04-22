namespace OpenAILibrary.Model.Embedding;

public record EmbeddingResponse(
    string @object,
    Data[] data,
    string model,
    Usage usage
);

public record Data(
    string @object,
    double?[] embedding,
    int index
);

public record Usage(
    int prompt_tokens,
    int total_tokens
);

