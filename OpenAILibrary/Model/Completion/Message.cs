namespace OpenAILibrary.Model.Completion;

public record Message(
    string role,
    string content
);

public static class MessageFactory
{
    //change order of role, content
    public static Message[] CreateMessages(string[] content, string[] roles)
    {
        if (content.Length != roles.Length)
            throw new ArgumentException("content and roles must be of the same length");
        
        
        var messages = new Message[content.Length];
        for (var i = 0; i < content.Length; i++)
        {
            if (roles[i] != "system" && roles[i] != "user" && roles[i] != "assistant")
                throw new ArgumentException("role must be either 'system' or 'user' or 'assistant', see: " +
                                            "https://platform.openai.com/docs/api-reference/chat/create");
            messages[i] = new Message(content[i], roles[i]);
        }

        return messages;
    }
    
    public static Message[] CreateSystemMessage(string content)
    {
        return new Message[] {new Message("system", content)};
    }
    
    public static Message[] CreateUserMessage(string content)
    {
        return new Message[] {new Message("user", content)};
    }
    
    public static Message[] CreateAssistantMessage(string content)
    {
        return new Message[] {new Message("assistant", content)};
    }
}