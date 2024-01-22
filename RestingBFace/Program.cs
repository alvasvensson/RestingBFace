using System.IO;
using System.Text.Json;
using RestSharp;

Console.WriteLine("what artist?");
string artist = Console.ReadLine();
Console.WriteLine("what song title?");
string songTitle = Console.ReadLine();
RestClient client = new("https://api.lyrics.ovh/v1");

RestRequest request = new($"{artist}/{songTitle}");
RestResponse response = client.GetAsync(request).Result;


File.WriteAllText("lyric.Json", response.Content.Replace("\\n", "\n"));
Console.WriteLine(response.Content.Replace("\\n", "\n"));
Console.ReadLine();