using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // Problem 1 - ADD YOUR CODE HERE

        // Performance note:
        // The code below has a single loop that goes through each line in the file
        // once. There are no nested loops that makes the overall performance O(n).
        // e.g.: O(n) loop

        HashSet<string> set = [..words];    // O(n)
        HashSet<string> matches = [];

        foreach (string word in words)      // O(n) loop
        {
            if (word[0] == word[1])         // O(1)
                continue;

            string reversedWord = $"{word[1]}{word[0]}";    // O(1)

            if (set.Contains(reversedWord)) // O(1) average
            {
                matches.Add($"{word} & {reversedWord}");
                set.Remove(word);           // O(1) average
                set.Remove(reversedWord);   // O(1) average
            }
        }

        return [..matches];
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {

        // Performance note:
        // The code below has a single loop that goes through each line in the file
        // once. There are no nested loops that makes the overall performance O(n).
        // e.g.: O(n) loop

        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Problem 2 - ADD YOUR CODE HERE

            string degree = fields[3];                  // O(1)
            if (!degrees.TryGetValue(degree, out int value))    // O(1) average
                degrees.Add(degree, 1);                 // O(1) average
            else
                degrees[degree] = ++value;              // O(1) average
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Problem 3 - ADD YOUR CODE HERE

        // Performance note:
        // The code below has a single loop that goes through each line in the file
        // once. There are no nested loops that makes the overall performance O(n).
        // e.g.: O(n) + O(m) => O(n) + O(n) = O(2n) = O(n)

        word1 = word1.Replace(" ", "").ToLower();   // O(n) + O(n) = O(2n) = O(n)
        word2 = word2.Replace(" ", "").ToLower();   // O(m) + O(m) = O(2m) = O(m)

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> frequency = [];

        foreach (char letter in word1)              // O(n) loop
        {
            if (frequency.TryGetValue(letter, out int value))   // O(1) average
                frequency[letter]++;                // O(1) average
            else
                frequency[letter] = 1;              // O(1) average
        }

        foreach (char letter in word2)              // O(m) loop
        {
            if (!frequency.ContainsKey(letter))     // O(1) average
                return false;
            
            frequency[letter]--;                    // O(n) average
            if (frequency[letter] < 0)              // O(1)
                return false;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        // Performance note:
        // The code below has a single loop that goes through each line in the file
        // once. There are no nested loops that makes the overall performance O(n).
        // e.g.: O(n) loop

        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.

        List<string> results = [];

        DateTime today = DateTime.Today;

        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        foreach (var feature in featureCollection.Features)         // O(n) loop
        {
            long unixTimeMilliseconds = feature.Properties.Time;    // O(1)
            DateTime dateTimeFromMs = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds).LocalDateTime;
            
            if (dateTimeFromMs >= today)
            {
                results.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");  // O(1) average
            }
        }

        // 3. Return an array of these string descriptions.
        return [.. results];    // O(n)
    }
}