using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

public class GuestBook
{
    // Stores all guestbook entries
    private List<GuestbookEntry> entries;

    // File where JSON data is saved
    private string filePath = "guestbook.json";

    // Constructor: create list and load file if it exists
    public GuestBook()
    {
        entries = new List<GuestbookEntry>();
        LoadFromFile();
    }

    // Add a new entry and save to file
    public void AddEntry(string owner, string message)
    {
        entries.Add(new GuestbookEntry(owner, message));
        SaveToFile();
    }

    // Remove an entry by index and save to file
    public void RemoveEntry(int index)
    {
        if (index >= 0 && index < entries.Count)
        {
            entries.RemoveAt(index);
            SaveToFile();
        }
        else
        {
            Console.WriteLine("Invalid index. No entry was removed.");
        }
    }

    // Return the list of entries
    public List<GuestbookEntry> GetEntries()
    {
        return entries;
    }

    // Save entries to JSON file
    private void SaveToFile()
    {
        string json = JsonSerializer.Serialize(entries);
        File.WriteAllText(filePath, json);
    }

    // Load entries from JSON file if it exists
    private void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            List<GuestbookEntry> loadedEntries =
                JsonSerializer.Deserialize<List<GuestbookEntry>>(json);

            if (loadedEntries != null)
            {
                entries = loadedEntries;
            }
        }
    }
}
