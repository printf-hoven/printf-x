
using ModelContextProtocol.Client;

var clientTransport = new SseClientTransport(new SseClientTransportOptions()
{
  Endpoint = new Uri("https://localhost:5001/"),
  Name = "My_Client"
});

IMcpClient? mcpClient_t = null;

try
{
  mcpClient_t = await McpClientFactory.CreateAsync(clientTransport);
}
catch (Exception ex)
{
  Console.WriteLine($"ERROR McpClientFactory.CreateAsync {ex.Message}");

  Console.WriteLine("HAVE YOU STARTED THE SERVER?");

  return;
}

await using IMcpClient mcpClient = mcpClient_t!;

IList<McpClientTool>? tools = null;

try
{
  tools = await mcpClient.ListToolsAsync();
}
catch (Exception ex)
{
  Console.WriteLine($"Error ListToolsAsync {ex.Message}");

  return;
}

if (!tools.Any())
{
  Console.WriteLine("No tools found on the server. Quitting...");

  return;
}

Console.WriteLine("Connected to server with tools:");

foreach (var tool in tools)
{
  Console.WriteLine($"{tool.Name}, {tool.Description}");
}

Console.WriteLine($"Calling the first tool...");

var result = await tools[0].CallAsync(new Dictionary<string, object?>() { ["n"] = 9 });

Console.Write("Response is: ");
Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

// for more ->
// https://github.com/modelcontextprotocol/csharp-sdk/tree/main/samples



