# Strike.NET

C# wrapper for the [Strike](https://getstrike.net/) API.

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

## License

The MIT License (MIT)

Copyright (c) 2015 Nate Shoffner

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
