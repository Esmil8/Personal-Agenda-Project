using ContactManagerPro.Operations;

List<int> ids = [];
Dictionary<int, string> names = [];
Dictionary<int, string> lastnames = [];
Dictionary<int, string> addresses = [];
Dictionary<int, string> telephones = [];
Dictionary<int, string> emails = [];
Dictionary<int, int> ages = [];
Dictionary<int, bool> bestFriends = [];

bool exit = false;

while (!exit)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("   MENU  ");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View Contacts");
    Console.WriteLine("3. Search Contact");
    Console.WriteLine("4. Modify Contact");
    Console.WriteLine("5. Delete Contact");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");

    string? option = Console.ReadLine();

    try
    {
        switch (option)
        {
            case "1":
                ContactOperations.AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                break;
            case "2":
                ContactOperations.ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                break;
            case "3":
                ContactOperations.SearchContact(ids, names, lastnames, telephones, emails);
                break;
            case "4":
                ContactOperations.ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                break;
            case "5":
                ContactOperations.DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                break;
            case "6":
                exit = true;
                Console.WriteLine("Exiting program...");
                break;
            default:
                Console.WriteLine(" Invalid option. Try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" Error: {ex.Message}");
    }

    if (!exit)
    {
        Console.WriteLine("\n Press any key to continue...");
        Console.ReadKey();
    }
}
