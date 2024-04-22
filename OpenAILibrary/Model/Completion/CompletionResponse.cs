namespace OpenAILibrary.Model.Completion;

public record CompletionResponse(
    string id,
    string @object,
    int created,
    string model,
    Choices[] choices,
    Usage usage
);

public record Choices(
    int index,
    Message message,
    string finish_reason
);

public record Usage(
    int prompt_tokens,
    int completion_tokens,
    int total_tokens
);



