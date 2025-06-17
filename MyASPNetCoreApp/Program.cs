// add reference to ASPNETCore SDK
#:sdk Microsoft.NET.Sdk.Web

using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;

//---- code starts here -----//

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/weather", (CancellationToken cancellationToken) =&gt;
{
  return TypedResults.ServerSentEvents(
    WeatherRecord.GetNextRecord(cancellationToken), eventType: "onRecord");
});

app.Run();

//----- records, classes and structs ----------//

public record WeatherRecord(float temperature, int humidity)
{
  public static async IAsyncEnumerable&lt;WeatherRecord&gt; GetNextRecord(
      [EnumeratorCancellation] CancellationToken cancellationToken
    )
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      yield return new WeatherRecord(
        (float)Random.Shared.Next(500, 1000) / 10.0f,
        Random.Shared.Next(10, 99)
        );

      // get next reading. we are adding a delay to simulate
      await Task.Delay(2000, cancellationToken);
    }
  }
}