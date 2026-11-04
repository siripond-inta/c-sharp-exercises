using System;
using System.Collections.Generic;

namespace HangmanGame
{
    public enum GuessResult
    {
        Correct = 0,
        Incorrect = 1,
        Duplicate = 2
    }

    public class HangmanService
    {
        private const int MaxTries = 10; // จำนวนครั้งในการเดา
        private readonly string[] words =
        {
            "Softsquaregroup", "Traveller", "Software", "Engineering",
            "Developer", "Project", "Computer", "Technology"
        };

        private string targetWord;
        private List<char> guessedCharacters;
        private int remainingTries;
        private readonly Random random = new Random();

        public HangmanService()
        {
            Restart();
        }

       
        // เริ่มเกมใหม่
        public void Restart()
        {
            targetWord = words[random.Next(words.Length)];
            guessedCharacters = new List<char>();
            remainingTries = MaxTries;
        }

        // แสดงผลปัจจุบัน
        public string GetDisplay()
        {
            string lowerTarget = targetWord.ToLower();
            var display = new System.Text.StringBuilder();

            for (int i = 0; i < targetWord.Length; i++)
            {
                if (i > 0) display.Append(' ');

                display.Append(
                    guessedCharacters.Contains(lowerTarget[i])
                        ? targetWord[i].ToString()
                        : "_"
                );
            }

            return display.ToString();
        }

        // เช็คตัวอักษรที่ผู้เล่นป้อน
        public GuessResult Input(char character)
        {
            char lower = char.ToLower(character);

            // ตรวจซ้ำ
            if (guessedCharacters.Contains(lower))
                return GuessResult.Duplicate;

            guessedCharacters.Add(lower);

            bool isCorrect = targetWord.ToLower().IndexOf(lower) >= 0;

            if (!isCorrect)
                remainingTries--;

            return isCorrect ? GuessResult.Correct : GuessResult.Incorrect;
        }

        // จำนวนครั้งที่เหลือในการเดา
        public int GetRemainingTry() => remainingTries;

        // ตรวจว่าชนะรึยัง
        public bool IsWon() => !GetDisplay().Contains('_');

        // เฉลย
        public string GetTargetWord() => targetWord;
    }

    // ── Entry Point ─────────────────────────────────────────────────────────

    class Program
    {
        static void Main(string[] args)
        {
            HangmanService game = new HangmanService();

            Console.WriteLine("=== Welcome to Hangman Game ===");
            Console.WriteLine("(Press Enter without a character to restart)");
            Console.WriteLine();

            while (true)
            {
                // แสดงสถานะปัจจุบัน
                Console.WriteLine(game.GetDisplay());
                Console.Write("please enter character: ");
                string input = Console.ReadLine();

                // กด Enter เปล่า → Restart
                if (input == "")
                {
                    Console.WriteLine("\n--- Restarting Game ---\n");
                    game.Restart();
                    continue;
                }

                char guessedChar = input[0];
                // ดักสัญลักษณ์ ที่ไม่ใช่ตัวอักษร
                if (!char.IsLetter(guessedChar))
                {
                    Console.WriteLine("Please enter a letter only.");
                    continue;
                }

                GuessResult result = game.Input(guessedChar);

                Console.WriteLine();
                // ใช้ switch แทน if else
                switch (result)
                {
                    case GuessResult.Correct:
                        Console.WriteLine(game.GetDisplay());       // แสดง progress ทันที
                        if (game.IsWon())
                        {
                            Console.WriteLine("\nCongratulation, you're win.");
                            Console.WriteLine("\n--- Starting new game ---\n");
                            game.Restart();
                        }
                        break;

                    case GuessResult.Incorrect:
                        Console.WriteLine($"Sorry, you're wrong. Remaining {game.GetRemainingTry()}");
                        if (game.GetRemainingTry() <= 0)
                        {
                            Console.WriteLine($"\nGame Over! The word was: {game.GetTargetWord()}");
                            Console.WriteLine("\n--- Starting new game ---\n");
                            game.Restart();
                        }
                        break;

                    case GuessResult.Duplicate:
                        Console.WriteLine("you have already tried this character.");
                        break;
                }

                Console.WriteLine("------------------------------");
            }
        }
    }
}
