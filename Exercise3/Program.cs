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
        private string[] words = { "Software", "Engineering", "Developer", "Project", "Computer","Technology" };
        private string targetWord;
        private List<char> guessedCharacters;
        private int remainingTries;
        private Random random = new Random();

        public HangmanService()
        {
            Restart();
        }

        public void Restart()
        {
            // สุ่มคำศัพท์จาก Array
            int index = random.Next(words.Length);
            targetWord = words[index];
            guessedCharacters = new List<char>();
            remainingTries = 10; // กำหนดให้ตอบผิดได้ 10 ครั้ง
        }

        public string GetDisplay()
        {
            string display = "";
            for (int i = 0; i < targetWord.Length; i++)
            {
                char c = targetWord[i];
                char lowerC = char.ToLower(c);

                // เช็คว่าเคยทายไปรึยัง
                bool found = false;
                for (int j = 0; j < guessedCharacters.Count; j++)
                {
                    if (guessedCharacters[j] == lowerC)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    display += c + " ";
                }
                else
                {
                    display += "_ ";
                }
            }
            return display.TrimEnd();
        }

        public GuessResult Input(char character)
        {
            char lowerChar = char.ToLower(character);
            for (int i = 0; i < guessedCharacters.Count; i++)
            {
                if (guessedCharacters[i] == lowerChar)
                {
                    return GuessResult.Duplicate;
                }
            }

            guessedCharacters.Add(lowerChar);

            // ตรวจสอบว่ามีตัวอักษรนี้ในคำศัพท์หรือไม่
            bool isCorrect = false;
            string lowerTarget = targetWord.ToLower();
            for (int i = 0; i < lowerTarget.Length; i++)
            {
                if (lowerTarget[i] == lowerChar)
                {
                    isCorrect = true;
                    break;
                }
            }

            if (isCorrect)
            {
                return GuessResult.Correct;
            }
            else
            {
                remainingTries--;
                return GuessResult.Incorrect;
            }
        }

        public int GetRemainingTry()
        {
            return remainingTries;
        }

        public bool IsWon()
        {
            string currentDisplay = GetDisplay();
            for (int i = 0; i < currentDisplay.Length; i++)
            {
                if (currentDisplay[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        // เฉลย
        public string GetTargetWord()
        {
            return targetWord;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HangmanService game = new HangmanService();
            Console.WriteLine("=== Welcome to Hangman Game ===");
            Console.WriteLine("(กด Enter โดยไม่พิมพ์ตัวอักษรเพื่อ Restart เกมใหม่)");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine(game.GetDisplay());
                Console.Write("please enter character: ");
                string input = Console.ReadLine();

                // กดปุ่ม Enter แต่ไม่ได้พิมพ์ให้เริ่มเล่นใหม่
                if (input == "")
                {
                    Console.WriteLine("\n--- Restarting Game ---");
                    game.Restart();
                    continue;
                }

                char guessedChar = input[0];
                GuessResult result = game.Input(guessedChar);

                if (result == GuessResult.Correct)
                {
                    Console.WriteLine();
                    // ถ้าตอบถูกครบ
                    if (game.IsWon())
                    {
                        Console.WriteLine(game.GetDisplay());
                        Console.WriteLine("Congratulation, you're win.");
                        Console.WriteLine("\nเริ่มเกมใหม่...");
                        game.Restart();
                    }
                }
                else if (result == GuessResult.Incorrect)
                {
                    // ไม่มีในคำ
                    Console.WriteLine("Sorry, you're wrong. Remaining " + game.GetRemainingTry());
                }
                else if (result == GuessResult.Duplicate)
                {
                    // ตัวอักษรถูกทายไปแล้ว
                    Console.WriteLine("you have already tried this character.");
                }

                // จำนวนครั้งหมด
                if (game.GetRemainingTry() <= 0)
                {
                    Console.WriteLine("\nGame Over! The word was: " + game.GetTargetWord());
                    Console.WriteLine("เริ่มเกมใหม่...");
                    game.Restart();
                }

                Console.WriteLine("------------------------------");
            }
        }
    }
}