using System.Diagnostics;
using System.Reflection;

namespace Module13.Task1;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string text = GetEmbeddedText();
        List<char> charList = new List<char>(text);
        LinkedList<char> charLinkedList = new LinkedList<char>(text); 

        TimeSpan t1 = MeasureExecutionTime(() => charList.Insert(0, ' '));
        TimeSpan t2 = MeasureExecutionTime(() => charLinkedList.AddFirst(' '));

        Console.WriteLine($"Вставка в начало List: {t1}");
        Console.WriteLine($"Вставка в начало LinkedList: {t2}");
        Console.ReadKey();
    }

    public static string GetEmbeddedText()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string text = String.Empty;

        using (Stream? stream = assembly.GetManifestResourceStream("Module13.Task1.Text1.txt"))
        {
            if (stream != null)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
            }
        }
        return text;
    }

    static TimeSpan MeasureExecutionTime(Action operation)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        operation.Invoke();
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
}