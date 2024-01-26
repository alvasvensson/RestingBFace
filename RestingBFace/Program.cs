using System.IO;
using System.Text.Json;
using RestSharp;

bool wannaPlay = true;
while (wannaPlay == true)
{

    Console.WriteLine("what artist?");
    string artist = Console.ReadLine();
    Console.WriteLine("what song title?");
    string songTitle = Console.ReadLine();
    RestClient client = new("https://api.lyrics.ovh/v1");

    RestRequest request = new($"{artist}/{songTitle}");
    RestResponse response = client.GetAsync(request).Result;

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        // File.WriteAllText("lyric.Json", response.Content.Replace("\\n", "\n"));
        Console.WriteLine(response.Content.Replace("\\n", "\n"));
    }
    else
    {
        Console.WriteLine($"Couldn't find {songTitle} by {artist}.");
    }

    Console.WriteLine("do you want to search again?");
    string answer = Console.ReadLine();

    if (answer == "no" || answer == "n")
    {
        wannaPlay = false;
    }
}