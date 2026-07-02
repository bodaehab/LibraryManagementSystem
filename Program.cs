using LibraryManagementSystem.Models;

int choice;
do
{
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Register Member");
    Console.WriteLine("3. Borrow Book");
    Console.WriteLine("4. Return Book");
    Console.WriteLine("5. Search");
    Console.WriteLine("6. Available Books");
    Console.WriteLine("7. Borrow History");
    Console.WriteLine("8. Late Report");
    Console.WriteLine("0. Exit");

     choice = int.TryParse(Console.ReadLine(), out int parsedChoice) ? parsedChoice : 0;

} while (choice != 0);


