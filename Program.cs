using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
//Library library = new Library();

//library.SeedData();

//int choice;

//do
//{
//    Console.WriteLine("\n===== Library System =====");
//    Console.WriteLine("1- Add Book");
//    Console.WriteLine("2- Register Member");
//    Console.WriteLine("3- Borrow Book");
//    Console.WriteLine("4- Return Book");
//    Console.WriteLine("5- Search");
//    Console.WriteLine("6- Available Books");
//    Console.WriteLine("7- Member History");
//    Console.WriteLine("8- Late Report");
//    Console.WriteLine("0- Exit");

//    choice = int.Parse(Console.ReadLine());

//    try
//    {
//        switch (choice)
//        {
//            case 1:
//                // Add Book
//                break;

//            case 2:
//                // Register Member
//                break;

//            case 3:
//                // Borrow Book
//                break;

//            case 4:
//                // Return Book
//                break;

//            case 5:
//                // Search
//                break;

//            case 6:
//                library.ViewAvailableBooks();
//                break;

//            case 7:
//                // History
//                break;

//            case 8:
//                library.LateReturnReport();
//                break;
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }

//} while (choice != 0);

Library library = new Library();

library.SeedData();

int choice;

do
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("      Library Management");
    Console.WriteLine("=================================");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Register Member");
    Console.WriteLine("3. Borrow Book");
    Console.WriteLine("4. Return Book");
    Console.WriteLine("5. Search");
    Console.WriteLine("6. View Available Books");
    Console.WriteLine("7. Member Borrowing History");
    Console.WriteLine("8. Late Return Report");
    Console.WriteLine("0. Exit");
    Console.Write("\nChoose: ");

    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid Choice.");
        Console.ReadKey();
        continue;
    }

    try
    {
        switch (choice)
        {
            case 1:

                Console.Write("Title: ");
                string? title = Console.ReadLine();

                Console.Write("Author: ");
                string? author = Console.ReadLine();

                Console.Write("Year: ");
                int year = int.TryParse(Console.ReadLine(), out int parsedYear) ? parsedYear : 0;

                Console.Write("Genre: ");
                string? genre = Console.ReadLine();

                library.AddBook(title, author, year, genre);

                Console.WriteLine("Book Added Successfully.");
                break;

            case 2:

                Console.Write("Name: ");
                string? name = Console.ReadLine();

                Console.Write("Email: ");
                string? email = Console.ReadLine();

                Console.Write("Premium Member? (y/n): ");
                bool premium = Console.ReadLine().ToLower() == "y";

                library.RegisterMember(name, email, premium);

                Console.WriteLine("Member Registered Successfully.");
                break;

            case 3:

                Console.Write("Book Id: ");
                int bookId = int.TryParse(Console.ReadLine(), out int parsedBookId) ? parsedBookId : 0;

                Console.Write("Member Id: ");
                int memberId = int.TryParse(Console.ReadLine(), out int parsedMemberId) ? parsedMemberId : 0;

                library.BorrowBook(bookId, memberId);

                Console.WriteLine("Book Borrowed Successfully.");
                break;

            case 4:

                Console.Write("Book Id: ");
                int returnBookId = int.TryParse(Console.ReadLine(), out int parsedReturnBookId) ? parsedReturnBookId : 0;

                library.ReturnBook(returnBookId);

                Console.WriteLine("Book Returned Successfully.");
                break;

            case 5:

                Console.Write("Search: ");
                string? query = Console.ReadLine();

                library.SearchCatalog(query);

                break;

            case 6:

                library.ViewAvailableBooks();

                break;

            case 7:

                Console.Write("Member Id: ");
                int historyId = int.TryParse(Console.ReadLine(), out int parsedHistoryId) ? parsedHistoryId : 0;

                library.MemberBorrowingHistory(historyId);

                break;

            case 8:

                library.LateReturnReport();

                break;

            case 0:

                Console.WriteLine("Good Bye!");
                break;

            default:

                Console.WriteLine("Invalid Choice.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError: {ex.Message}");
    }

    if (choice != 0)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

} while (choice != 0);
