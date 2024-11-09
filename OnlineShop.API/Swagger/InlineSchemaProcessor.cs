using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace OnlineShop.API.Swagger
{
    public class InlineSchemaProcessor : IDocumentProcessor
    {
        public void Process(DocumentProcessorContext context)
        {
            // Duyệt qua tất cả các path trong tài liệu OpenAPI
            foreach (var pathItem in context.Document.Paths)
            {
                // Duyệt qua từng phương thức HTTP (GET, POST, PUT, DELETE, v.v.)
                if (pathItem.Value.TryGetValue("get", out var getOperation))
                {
                    ProcessOperation(getOperation);
                }

                if (pathItem.Value.TryGetValue("post", out var postOperation))
                {
                    ProcessOperation(postOperation);
                }

                if (pathItem.Value.TryGetValue("put", out var putOperation))
                {
                    ProcessOperation(putOperation);
                }

                if (pathItem.Value.TryGetValue("delete", out var deleteOperation))
                {
                    ProcessOperation(deleteOperation);
                }
            }
        }

        private void ProcessOperation(OpenApiOperation operation)
        {
            if (operation.RequestBody != null && operation.RequestBody.Content.ContainsKey("application/json"))
            {
                var refSchema = operation.RequestBody.Content["application/json"].Schema;
                if (refSchema != null && refSchema.Type == JsonObjectType.Object && refSchema.HasReference)
                {
                    var refName = refSchema.Reference?.Id;
                    if (!string.IsNullOrEmpty(refName))
                    {
                        // Log hoặc xử lý theo yêu cầu
                        System.Console.WriteLine($"Reference for schema: {refName}");
                    }
                }
            }
        }
    }
}
