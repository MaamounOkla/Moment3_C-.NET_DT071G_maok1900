using System;

public class GuestbookEntry
{
    // Name of the person who wrote the entry
    public string Owner { get; set; }

    // The message text
    public string Message { get; set; }

    // Empty constructor (needed for JSON)
    public GuestbookEntry()
    {
    }

    // Constructor to create a new entry quickly
    public GuestbookEntry(string owner, string message)
    {
        Owner = owner;
        Message = message;
    }
}
