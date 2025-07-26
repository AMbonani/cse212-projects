using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static List<string> FindPairs(List<string> words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word.Length != 2 || word[0] == word[1])
                continue;

            var reversed = new string(new[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result;
    }

    public static Dictionary<string, int> SummarizeDegrees(string filePath = "census.txt")
    {
        var degreeCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(',');
            if (parts.Length >= 4)
            {
                var degree = parts[3].Trim();
                if (!string.IsNullOrWhiteSpace(degree))
                {
                    if (!degreeCount.ContainsKey(degree))
                        degreeCount[degree] = 0;

                    degreeCount[degree]++;
                }
            }
        }

        return degreeCount;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string Clean(string word) => new string(word
            .ToLowerInvariant()
            .Where(char.IsLetter)
            .ToArray());

        var w1 = Clean(word1);
        var w2 = Clean(word2);

        if (w1.Length != w2.Length) return false;

        var dict = new Dictionary<char, int>();

        foreach (var c in w1)
        {
            if (!dict.ContainsKey(c)) dict[c] = 0;
            dict[c]++;
        }

        foreach (var c in w2)
        {
            if (!dict.ContainsKey(c)) return false;
            dict[c]--;
            if (dict[c] < 0) return false;
        }

        return dict.Values.All(v => v == 0);
    }

    public static string[] EarthquakeDailySummary()
    {
        using var client = new HttpClient();
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        var json = client.GetStringAsync(url).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<EarthquakeFeatureCollection>(json, options);

        return data.Features
            .Where(f => f.Properties.Place != null && f.Properties.Mag.HasValue)
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag.Value}")
            .ToArray();
    }
}

// Supporting classes for earthquake JSON data
public class EarthquakeFeatureCollection
{
    public List<EarthquakeFeature> Features { get; set; }
}

public class EarthquakeFeature
{
    public EarthquakeProperties Properties { get; set; }
}

public class EarthquakeProperties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}

