# OpenAI Library

This is a small library for making requests to OpenAI API. At the moment it only supports text models, but will be expanded in the future.

### How to use

You should create HttpClient and set OpenAI authentication code. This should look like follows:

```csharp
var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openApiServiceKey);
```
### Supported features:

- chat completions
- create requests with parameters by default or change them by using RequestOptions record
- create single messages from text
