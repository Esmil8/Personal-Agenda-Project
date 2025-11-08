# ContactManagerPro

**ContactManagerPro** is a console application built with **C# (.NET 8)** that allows you to manage contacts (create, view, modify, delete, and search) while following modern programming practices, clean architecture, and secure input validation.

---

## Main Features

**Add Contacts** with validation:
- Name, Last Name, and Address min 3 characters  
- Age only between 0 and 120 years
- Email validated with regex `user@example.com`  
- Phone number digits only, min 10 digits  

 **View all contacts** in a formatted table  
 **Edit every field** of a contact  
 **Delete contacts** with confirmation  
 **Search contacts** by name, last name, phone, or email  
 **Centralized validation and error handling** via `InputValidator`



