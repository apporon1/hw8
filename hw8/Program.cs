class Program
{
    static void Main()
    {
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        try
        {
            IEnumerable<string> uniqueSortedLines = ProcessFile(inputFilePath);

            SaveToFile(outputFilePath, uniqueSortedLines);

            Console.WriteLine("Результат:");
            foreach (var line in uniqueSortedLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Обработка завершена. Результат сохранен в output.txt.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static IEnumerable<string> ProcessFile(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            var lines = new HashSet<string>();
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    lines.Add(line.Trim());
                }
            }
            return lines.OrderBy(l => l);
        }
    }

    static void SaveToFile(string filePath, IEnumerable<string> lines)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }
}
