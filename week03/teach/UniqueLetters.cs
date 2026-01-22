public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text) {
        // Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency

        // The function checks an string to check if there are duplicates letters
        // Return false in case the text contains duplicates
        // Return true in case the text does not contains duplicates

        HashSet<char> letters = [];

        for (var index = 0; index < text.Length; ++index) {
            // original

            // for (var j = 0; j < text.Length; ++j) {
            //     // Don't want to compare to yourself ... that will always result in a match
            //     if (i != j && text[i] == text[j])
            //         return false;
            // }

            // solution 1
            
            // get the letter on the given index
            // char letter = text[index];

            // check if the hash set contains the letter, if exists return false
            // if (letters.Contains(letter))
            // {
            //     return false;
            // }
            // add letter to the hash set
            // letters.Add(letter);

            // solution 2

            // get the letter on the given index
            char letter = text[index];

            // if the item was added then continue, otherwise already exists
            if (!letters.Add(letter))
            {
                return false;
            }
        }

        return true;
    }
}