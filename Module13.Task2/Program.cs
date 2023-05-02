using Module13.Task1;
using System.Text;

namespace Module13.Task2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var wordsStatistics = GetWordStatistics(Task1.Program.GetEmbeddedText());
        var topPairs = wordsStatistics.OrderByDescending(pair => pair.Value).Take(10);
        foreach (var pair in topPairs)
        {
            Console.WriteLine($"{pair.Key}\t[{pair.Value}]");
        }
        Console.ReadKey();
    }

    static Dictionary<string, int> GetWordStatistics(string text)
    {
        string noPunctuationText = new(text.Where(c => !char.IsPunctuation(c)).ToArray());
        string[] words = noPunctuationText.Split(
            separator: new char[] { ' ', '\n', '\r', '\t' },
            options: StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> statistics = new();

        foreach (string word in words)
        {
            if (statistics.ContainsKey(word))
            {
                statistics[word]++;
            }
            else
            {
                statistics.Add(word, 1);
            }
        }
        return statistics;
    }
}