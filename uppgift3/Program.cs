using System;

public class Program
{
    // Program starts here
    static void Main(string[] args)
    {
        GuestBook guestBook = new GuestBook();
        bool running = true;

        while (running)
        {
            // Clear screen before printing menu
            Console.Clear();

            // Title
            Console.WriteLine("============================");
            Console.WriteLine("   ||  Okla Guestbook   ||"); 
            Console.WriteLine("============================\n");

            // Show all entries
            var entries = guestBook.GetEntries();
            Console.WriteLine("Current Entries:\n");

            if (entries.Count == 0)
            {
                Console.WriteLine("(No entries yet)");
            }
            else
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    Console.WriteLine($"[{i}] {entries[i].Owner} - {entries[i].Message}");
                }
            }

            // Menu
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. Remove entry");
            Console.WriteLine("X. Exit");

            Console.Write("\nChoose an option: ");
            string input = Console.ReadLine();
                 
            switch (input.ToUpper())
            {
                case "1":
                    // Add entry
                    Console.Clear();
                    Console.WriteLine("Add New Entry\n");

                    string owner = "";
                    while (string.IsNullOrWhiteSpace(owner))
                    {
                        Console.Write("Enter owner name: ");
                        owner = Console.ReadLine();
                    }

                    string message = "";
                    while (string.IsNullOrWhiteSpace(message))
                    {
                        Console.Write("Enter message: ");
                        message = Console.ReadLine();
                    }

                    guestBook.AddEntry(owner, message);

                    Console.WriteLine("\nEntry added! Press any key...");
                    Console.ReadKey();
                    break;

                case "2":
                    // Remove entry (show list before asking index)
                    Console.Clear();
                    Console.WriteLine("Remove Entry\n");

                    entries = guestBook.GetEntries();

                    if (entries.Count == 0)
                    {
                        Console.WriteLine("Guestbook is empty. Nothing to remove.");
                        Console.WriteLine("\nPress any key...");
                        Console.ReadKey();
                        break;
                    }

                    // Show entries with indexes
                    for (int i = 0; i < entries.Count; i++)
                    {
                        Console.WriteLine($"[{i}] {entries[i].Owner} - {entries[i].Message}");
                    }

                    Console.Write("\nEnter Guest index to remove: ");



                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        //Check if index exist in the guesbook
                        if (index >= 0 && index < entries.Count)
                        {
                            //Save before delete
                            string removedOwner = entries[index].Owner;
                            string removedMessage = entries[index].Message;
                            //remove
                            guestBook.RemoveEntry(index);
                            //Print MEssage
                            Console.WriteLine($"\nGuest '{removedOwner}' with message '{removedMessage}' was removed!");

                        }
                        else
                        {
                            Console.WriteLine("Invalid index.");
                        }



                    }


                    Console.WriteLine("\nPress any key...");                  
                    Console.ReadKey();
                    break;

                case "X":
                    // Clear screen on exit so old output doesn't stack
                    Console.Clear();
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option! Press any key...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
