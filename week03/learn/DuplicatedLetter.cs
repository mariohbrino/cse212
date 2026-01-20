public class DuplicatedLetter
{
    public static void Run()
    {
        // Define the variables and initial states
        HashSet<char> wordChars = new HashSet<char>();
        string word = "summary"; // given word example
        char[] letters = word.ToCharArray(); // empty list of letters (chars)
        int index = 0; // index start at zero
        int duplicatedIndex = 0; // duplicated starts in zero
        char duplicateChar = new char(); // empty duplicated char

        Console.WriteLine($"Given word: {word}");
        Console.WriteLine($"List of letters: {String.Join(", ", letters)}");

        // loop through the list of letters with performance O(n) in case no duplicates are found
        foreach (char letter in letters)
        {
            // check if was added to the list of letters
            if (wordChars.Add(letter))
            {
                index += 1;
            }
            else
            {
                // in case the letter exists on the hash set then set index and letter and stop loop
                duplicatedIndex = index;
                duplicateChar = letter;
                break;
            }
        }

        // handle possible errors in case there are no duplicates
        if (duplicatedIndex > 0)
        {
            Console.WriteLine($"Duplicated letter: {duplicateChar}");
            Console.WriteLine($"Duplicated index: {duplicatedIndex}");
        }
        else
        {
            Console.WriteLine("No duplicates found.");
        }
    }
}