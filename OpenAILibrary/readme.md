# OpenAI Library

This is a small library for making requests to OpenAI API. At the moment it supports chat completions and embeddings.

### How to use
```csharp
var controller = new OpenAILibrary.OpenAiController("API_KEY");
```
For embeddings:
```csharp
var req = OpenAILibrary.Model.Embedding.EmbeddingRequestFactory.CreateRequestModelSmall("Hello, World!");
var res = controller.SendEmbeddingRequest(req).Result;
var resModel = JsonSerializer.Deserialize<EmbeddingResponse>(res);
Console.WriteLine(resModel.model);
```
For chat completions:
```csharp
var msg = MessageFactory.CreateUserMessage("Hello, World!");
var req = CompletionRequestFactory.CreateRequestGPT3_4K(msg);
var res = controller.SendCompletionRequest(req).Result;
var resModel = JsonSerializer.Deserialize<CompletionResponse>(res);
Console.WriteLine(resModel.choices[0].message.content);
```
### Supported features:

- chat completions
- embeddings
- create requests with parameters by default or change them by using corresponding Options record
