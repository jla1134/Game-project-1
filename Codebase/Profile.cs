using System;
using System.IO;
using System.Collections.Generic;
using CsvHelper;
using system.Globalization;

public class CsvHandler
{
    // Write data to CSV
    public static void SaveToCsv<T>(List<T> items, string filePath, string[] headers)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write headers
                writer.WriteLine(string.Join(",", headers));

                // Write data
                foreach (var item in items)
                {
                    var values = item.GetType().GetProperties()
                        .Select(p => p.GetValue(item)?.ToString() ?? "")
                        .ToArray();
                    writer.WriteLine(string.Join(",", values));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving CSV: {ex.Message}");
        }
    }

    // Read data from CSV
    public static List<string[]> ReadFromCsv(string filePath)
    {
        List<string[]> data = new List<string[]>();
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Skip header if needed
                string headerLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    data.Add(values);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV: {ex.Message}");
        }
        return data;
    }
}

// Example saving Familiars to CSV
public class FamiliarDataManager
{
    private const string CSV_PATH = "familiars.csv";
    private static readonly string[] HEADERS = new[]
    {
        "ID", "Name", "Level", "HP", "ATK", "DEF", "WIS", "AGI",
        "HPScale", "ATKScale", "DEFScale", "WISScale", "AGIScale",
        "Skill1", "Skill2", "Skill3"
    };

    public static void SaveFamiliars(List<Familiar> familiars)
    {
        CsvHandler.SaveToCsv(familiars, CSV_PATH, HEADERS);
    }

    public static List<Familiar> LoadFamiliars()
    {
        List<Familiar> familiars = new List<Familiar>();
        var data = CsvHandler.ReadFromCsv(CSV_PATH);

        foreach (var row in data)
        {
            try
            {
                Familiar familiar = new Familiar
                {
                    ID = Convert.ToInt32(row[0]),
                    Name = row[1],
                    Level = Convert.ToInt32(row[2]),
                    HP = Convert.ToInt32(row[3]),
                    ATK = Convert.ToInt32(row[4]),
                    DEF = Convert.ToInt32(row[5]),
                    WIS = Convert.ToInt32(row[6]),
                    AGI = Convert.ToInt32(row[7]),
                    HPScale = Convert.ToInt32(row[8]),
                    ATKScale = Convert.ToInt32(row[9]),
                    DEFScale = Convert.ToInt32(row[10]),
                    WISScale = Convert.ToInt32(row[11]),
                    AGIScale = Convert.ToInt32(row[12]),
                    Skill1 = Convert.ToInt32(row[13]),
                    Skill2 = Convert.ToInt32(row[14]),
                    Skill3 = Convert.ToInt32(row[15])
                };
                familiars.Add(familiar);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing familiar data: {ex.Message}");
            }
        }

        return familiars;
    }
}
