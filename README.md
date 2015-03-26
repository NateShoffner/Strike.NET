# Strike.NET

C# wrapper for the [Strike](https://getstrike.net/) API.

## Requirements
* .NET 3.5

## Dependencies
* [RestSharp](http://restsharp.org/)
* [JSON.NET](http://www.newtonsoft.com/json) - Used for API v1 compatibility

### License
* [MIT License](https://github.com/NateShoffner/Strike.NET/blob/master/LICENSE)

## Download & Installation
Nuget Package [Strike.NET](https://www.nuget.org/packages/Strike.NET/)

```

Install-Package Strike.NET

```

## Examples

### Searching
```csharp
var strike = new StrikeApi();
var results = strike.Search("Debian");

Console.WriteLine("Found {0} results:", results.Count());

foreach (var result in results)
{
	Console.WriteLine(result.TorrentTitle);
}
```

### Info
```csharp
var strike = new StrikeApi();

var info = strike.GetInfo("2875DA262892568665D580B2043E5C0D49BD409F");

Console.WriteLine(info.TorrentTitle);
Console.WriteLine("Leeches: {0}", info.Leeches);
Console.WriteLine("Seeds: {0}", info.Seeds);
```

###  Download
```csharp
var strike = new StrikeApi();
var url = strike.GetDownloadLink("2875DA262892568665D580B2043E5C0D49BD409F");

Console.WriteLine(url);
```