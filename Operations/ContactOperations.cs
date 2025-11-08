namespace ContactManagerPro.Operations;

public static class ContactOperations
{
    public static void AddContact(
        List<int> ids,
        Dictionary<int, string> names,
        Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses,
        Dictionary<int, string> telephones,
        Dictionary<int, string> emails,
        Dictionary<int, int> ages,
        Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("\n--- Add New Contact ---");

        string name = InputValidator.GetValidatedString("Enter the person's name: ", 5);
        string lastname = InputValidator.GetValidatedString("Enter the person's last name: ", 5);
        string address = InputValidator.GetValidatedString("Enter the address: ", 10);
        string phone = InputValidator.GetValidatedPhone("Enter the telephone number: ", 10);
        string email = InputValidator.GetValidatedEmail("Enter the email: ");
        int age = InputValidator.GetValidatedInt("Enter the age numbers only: ");
        bool isBestFriend = InputValidator.GetYesNo("Is this your best friend? Pull 1 = Yes, 2 = No: ");

        int id = ids.Count + 1;

        ids.Add(id);
        names[id] = name;
        lastnames[id] = lastname;
        addresses[id] = address;
        telephones[id] = phone;
        emails[id] = email;
        ages[id] = age;
        bestFriends[id] = isBestFriend;

        Console.WriteLine(" Contact added successfully ");
    }

    public static void ShowContacts(
        List<int> ids,
        Dictionary<int, string> names,
        Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses,
        Dictionary<int, string> telephones,
        Dictionary<int, string> emails,
        Dictionary<int, int> ages,
        Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("\n--- Contact List ---");

        if (ids.Count == 0)
        {
            Console.WriteLine("No contacts available.");
            return;
        }

        Console.WriteLine($"{"ID",-4} {"Name",-12} {"Lastname",-15} {"Address",-20} {"Phone",-12} {"Email",-20} {"Age",-5} {"Best Friend"}");
        Console.WriteLine(new string('-', 95));

        foreach (var id in ids)
        {
            string bestFriendText = bestFriends[id] ? "Yes" : "No";
            Console.WriteLine($"{id,-4} {names[id],-12} {lastnames[id],-15} {addresses[id],-20} {telephones[id],-12} {emails[id],-20} {ages[id],-5} {bestFriendText}");
        }
    }

   public static void SearchContact(
    List<int> ids,
    Dictionary<int, string> names,
    Dictionary<int, string> lastnames,
    Dictionary<int, string> telephones,
    Dictionary<int, string> emails)
{
    Console.Write("\n Enter name or last name to search: ");
    string term = Console.ReadLine()?.Trim().ToLower() ?? "";

    var matches = ids
        .Where(id =>
            names[id].ToLower().Contains(term) ||
            lastnames[id].ToLower().Contains(term))
        .ToList();

    if (matches.Count == 0)
    {
        Console.WriteLine(" No contacts found.");
        return;
    }

    Console.WriteLine("\n--- Search Results ---");
    foreach (var id in matches)
    {
        Console.WriteLine($"{id}. {names[id]} {lastnames[id]} - {telephones[id]} - {emails[id]}");
    }
}


    public static void ModifyContact(
    List<int> ids,
    Dictionary<int, string> names,
    Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses,
    Dictionary<int, string> telephones,
    Dictionary<int, string> emails,
    Dictionary<int, int> ages,
    Dictionary<int, bool> bestFriends)
{
    Console.Write("\n Enter the contact ID to modify: ");
    if (!int.TryParse(Console.ReadLine(), out int id) || !ids.Contains(id))
    {
        Console.WriteLine(" Invalid ID.");
        return;
    }

        Console.WriteLine($"\nEditing contact: {names[id]} {lastnames[id]}");
        
    Console.WriteLine("""
    What do you want to edit?
    1. Name
    2. Last Name
    3. Address
    4. Phone
    5. Email
    6. Age
    7. Best Friend
    8. Edit All
    """);

    Console.Write("Select option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            names[id] = InputValidator.GetValidatedString("New name: ", 5);
            break;
        case "2":
            lastnames[id] = InputValidator.GetValidatedString("New last name: ", 5);
            break;
        case "3":
            addresses[id] = InputValidator.GetValidatedString("New address: ", 10);
            break;
        case "4":
            telephones[id] = InputValidator.GetValidatedPhone("New phone: ", 10);
            break;
        case "5":
            emails[id] = InputValidator.GetValidatedEmail("New email: ");
            break;
        case "6":
            ages[id] = InputValidator.GetValidatedInt("New age: ");
            break;
        case "7":
            bestFriends[id] = InputValidator.GetYesNo("Is best friend? 1 = Yes, 2 = No: ");
            break;
        case "8":
            names[id] = InputValidator.GetValidatedString("New name: ", 5);
            lastnames[id] = InputValidator.GetValidatedString("New last name: ", 5);
            addresses[id] = InputValidator.GetValidatedString("New address: ", 10);
            telephones[id] = InputValidator.GetValidatedPhone("New phone: ", 10);
            emails[id] = InputValidator.GetValidatedEmail("New email: ");
            ages[id] = InputValidator.GetValidatedInt("New age: ");
            bestFriends[id] = InputValidator.GetYesNo("Is best friend? 1 = Yes, 2 = No: ");
            break;
        default:
            Console.WriteLine(" Invalid option.");
            return;
    }

    Console.WriteLine(" Contact updated successfully.");
}


    public static void DeleteContact(
    List<int> ids,
    Dictionary<int, string> names,
    Dictionary<int, string> lastnames,
    Dictionary<int, string> addresses,
    Dictionary<int, string> telephones,
    Dictionary<int, string> emails,
    Dictionary<int, int> ages,
    Dictionary<int, bool> bestFriends)
{
    Console.Write("\nEnter the contact ID to delete: ");
    if (!int.TryParse(Console.ReadLine(), out int id) || !ids.Contains(id))
    {
        Console.WriteLine(" Invalid ID.");
        return;
    }

    Console.WriteLine($"\nYou are about to delete: {names[id]} {lastnames[id]}");
    bool confirm = InputValidator.GetYesNo("Are you sure? (1 = Yes, 2 = No): ");

    if (!confirm)
    {
        Console.WriteLine(" Deletion cancelled.");
        return;
    }

    ids.Remove(id);
    names.Remove(id);
    lastnames.Remove(id);
    addresses.Remove(id);
    telephones.Remove(id);
    emails.Remove(id);
    ages.Remove(id);
    bestFriends.Remove(id);

    Console.WriteLine(" Contact deleted successfully.");
}

}
