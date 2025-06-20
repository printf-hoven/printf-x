// Install-Package ModelContextProtocol -prerelease
// Install-Package ModelContextProtocol.AspNetCore -prerelease

using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddMcpServer()
  .WithHttpTransport()
  .WithToolsFromAssembly();

var app = builder.Build();

app.MapMcp();

app.Run("https://localhost:5001/");

// ---- 

[McpServerToolType]
public sealed class EchoTool
{
  [McpServerTool, Description("Gives the square of a number")]
  public static int MakeSquare(int n)
  {
    return n * n;
  }

  [McpServerTool, Description("Gives the cube of a number")]
  public static int MakeCube(int n)
  {
    return n * n * n;
  }
}
