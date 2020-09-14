using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BootCamp.Chapter
{
    public static class TextTable
    {
        public static string Build(string message, int padding)
        {
            if (string.IsNullOrEmpty(message)) return "";

            StringBuilder sb = new StringBuilder();
            var allWords = SplitWords(message);
            var longestWordLength = FindLongestWordLength(allWords);
            var horizontalLineWidth = longestWordLength + 2 * padding;

            BuildHorizontalLine(horizontalLineWidth, sb);
            BuildPadding(padding, horizontalLineWidth, sb);
            for (var i = 0; i < allWords.Length; i++)
            {
                sb.Append(Environment.NewLine);
                sb.Append("|");
                sb.Append(allWords[i].PadLeft(allWords[i].Length + padding).PadRight(horizontalLineWidth));
                sb.Append("|");
            }
            BuildPadding(padding, horizontalLineWidth, sb);
            sb.Append(Environment.NewLine);
            BuildHorizontalLine(horizontalLineWidth, sb);
            sb.Append(Environment.NewLine);
            var boxedMessage = sb.ToString();

            return boxedMessage;

        }

        private static void BuildHorizontalLine(int length, StringBuilder sb)
        {
            sb.Append('+');
            sb.Append('-', length);
            sb.Append('+');
        }

        private static void BuildPadding(int padding, int width, StringBuilder sb)
        {
            for (var i = 0; i < padding; i++)
            {
                sb.Append(Environment.NewLine);
                sb.Append("|".PadRight(width + 1));
                sb.Append("|");
            }
        }

        private static string[] SplitWords(string message)
        {
            var words = message.Split("\r\n");
            return words;
        }

        private static int FindLongestWordLength(string[] words)
        {
            string longestWord = "";
            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length) longestWord = words[i];
            }
            return longestWord.Length;
        }
    }
}
