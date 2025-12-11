using System;
using System.Linq;

namespace Utils
{
    /// Console helper for unified UI, input and validation
    public static class ConsoleHelper
    {
        // UI MESSAGES

        // success
        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ {message}");
            Console.ResetColor();
        }

        // error
        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ {message}");
            Console.ResetColor();
            Console.ReadKey();
        }

        // warning
        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"⚠ {message}");
            Console.ResetColor();
        }

        // info
        public static void WriteInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ℹ {message}");
            Console.ResetColor();
        }

        // simple header
        public static void WriteHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n=== {title} ===\n");
            Console.ResetColor();
        }

        // clear console
        public static void Clear()
        {
            Console.Clear();
            Console.ResetColor();
        }

        // INPUT BASE

        // basic prompt
        public static string Prompt(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine() ?? "";
        }

        // ESC + editable input
        public static string PromptWithEscape(string message)
        {
            Console.Write($"{message}: ");
            string input = "";

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input.Trim();
                }

                // ESC -> cancel
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    return "<ESC>";
                }

                // Backspace edit
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Remove(input.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
        }

        // SQL INJECTION FILTER

        public static bool HasSqlInjectionRisk(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            string[] blocked =
            {
                "'", "\"", ";", "--", "/*", "*/", " OR ", " AND ", "1=1",
                " UNION ", " DROP ", " DELETE ", " INSERT ", " UPDATE ", " SELECT ", " FROM ", " WAITFOR "
            };

            foreach (var item in blocked)
            {
                if (input.ToUpper().Contains(item))
                    return true;
            }

            return false;
        }

        // secure input loop
        public static string SafePrompt(string message)
        {
            while (true)
            {
                var input = PromptWithEscape(message);

                if (input == "<ESC>") return "<ESC>";

                if (HasSqlInjectionRisk(input))
                {
                    WriteError("Potential SQL Injection blocked.");
                    continue;
                }

                return input.Trim();
            }
        }

        // EXTRA HELPERS

        // name cleaner (letters only)
        public static string CleanName(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "";
            return new string(input.Where(char.IsLetter).ToArray()).Trim();
        }

        // waits for user after success/error/info
        // ENTER -> return to menu
        // ESC -> go one step back
        public static void WaitForContinue()
        {
            Console.WriteLine("\nPress ENTER to return or ESC to go back...");

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape)
                {
                    Clear();
                    return;
                }
            }
        }
        public static bool Confirm(string msg)
        {
            Console.Write($"{msg} (Y/N): ");
            var key = Console.ReadKey(true).Key;
            Console.WriteLine();
            return key == ConsoleKey.Y;
        }



    }
}
