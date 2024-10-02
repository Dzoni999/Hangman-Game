namespace Hagman_v1_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Welcome to Hangman GAME ---");
           
            string word = "hello"; // word that user needs to guess
            int maxLives = 7;
            int currentLives = maxLives;
            bool win = false;
            List<char> guessedLetters = new List<char>();

            while (currentLives > 0 && !win)
            {

                Console.Write("Word: ");
                foreach (char c in word)
                {
                    if (guessedLetters.Contains(c))
                        Console.Write(c);
                    else
                        Console.Write("_");
                }

                Console.WriteLine();


                Console.WriteLine(currentLives + "/" + maxLives + " lives remaining.");


                char guess;
                while (true)
                {
                    Console.Write("Please guess a letter: ");
                    string input = Console.ReadLine();

                    // Check for typed character
                    if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
                    {
                        guess = char.ToLower(input[0]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a single letter.");
                    }
                }

                // Check is letter correct
                if (word.Contains(guess) && !guessedLetters.Contains(guess))
                {
                    Console.WriteLine("Correct!");
                }
                else if (!guessedLetters.Contains(guess))
                {
                    Console.WriteLine("Incorrect!");
                    currentLives--;
                }
                else
                {
                    Console.WriteLine("You've already guessed that letter.");
                }

                guessedLetters.Add(guess);

                // Checking for a word
                bool wordComplete = true;
                foreach (char c in word)
                {
                    if (!guessedLetters.Contains(c))
                        wordComplete = false;
                }

                win = wordComplete;

                //Console.Clear();
            }

            // End of the game
            if (win)
                Console.WriteLine("Congratulations, you win!");
            else
                Console.WriteLine("You lose..");
        }
    }
}
