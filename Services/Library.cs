using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Services
{
    internal class Library
    {
     
        
            private Book[] books = new Book[100];
            private Member[] members = new Member[100];
            private BorrowRecord[] records = new BorrowRecord[1000];

            private int bookCount = 0;
            private int memberCount = 0;
            private int recordCount = 0;

            private int nextBookId = 1;
            private int nextMemberId = 1;
            private int nextRecordId = 1;

            public void AddBook(string title, string author, int year, string genre)
            {
                if (string.IsNullOrWhiteSpace(title) ||
                    string.IsNullOrWhiteSpace(author) ||
                    string.IsNullOrWhiteSpace(genre))
                {
                    throw new Exception("All fields are required.");
                }

                Book book = new Book(nextBookId++, title, author, year, genre, DateTime.Now, true);
               

                books[bookCount++] = book;
            }

            public void RegisterMember(string name, string email, bool isPremium)
            {
                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(email))
                {
                    throw new Exception("Name and Email are required.");
                }

                Member member;

                if (isPremium)
                {
                    member = new PremiumMember();
                }
                else
                {
                    member = new Member();
                }

                member.Id = nextMemberId++;
                member.Name = name;
                member.Email = email;
                member.JoinDate = DateTime.Now;

                members[memberCount++] = member;
            }

            public void BorrowBook(int bookId, int memberId)
            {
                Book book = FindBook(bookId);
                Member member = FindMember(memberId);

                if (book == null)
                    throw new Exception("Book not found.");

                if (member == null)
                    throw new Exception("Member not found.");

                if (!book.IsAvailable)
                    throw new Exception("Book is already borrowed.");

                BorrowRecord record = new BorrowRecord
                {
                    Id = nextRecordId++,
                    Book = book,
                    Member = member,
                    BorrowDate = DateTime.Now
                };

                records[recordCount++] = record;

                book.IsAvailable = false;

                AddBorrowedBook(member, book);
            }

            public void ReturnBook(int bookId)
            {
                for (int i = 0; i < recordCount; i++)
                {
                    if (records[i].Book.Id == bookId &&
                        records[i].ReturnDate == null)
                    {
                        records[i].ReturnDate = DateTime.Now;
                        records[i].Book.IsAvailable = true;
                        return;
                    }
                }

                throw new Exception("Borrow record not found.");
            }

            public void SearchCatalog(string query)
            {
                Console.WriteLine("Books:");

                for (int i = 0; i < bookCount; i++)
                {
                    if (books[i].MatchesQuery(query))
                    {
                        Console.WriteLine(books[i].GetInfo());
                    }
                }

                Console.WriteLine("\nMembers:");

                for (int i = 0; i < memberCount; i++)
                {
                    if (members[i].MatchesQuery(query))
                    {
                        Console.WriteLine(members[i].GetInfo());
                    }
                }
            }

            public void ViewAvailableBooks()
            {
                bool found = false;

                for (int i = 0; i < bookCount; i++)
                {
                    if (books[i].IsAvailable)
                    {
                        Console.WriteLine(books[i].GetInfo());
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No available books.");
                }
            }

            public void MemberBorrowingHistory(int memberId)
            {
                bool found = false;

                for (int i = 0; i < recordCount; i++)
                {
                    if (records[i].Member.Id == memberId)
                    {
                        found = true;

                        Console.WriteLine(
                            $"Book: {records[i].Book.Title} | " +
                            $"Borrowed: {records[i].BorrowDate:d} | " +
                            $"Returned: {(records[i].ReturnDate == null ? "Not Returned" : records[i].ReturnDate.ToString())}"
                        );
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No history found.");
                }
            }

            public void LateReturnReport()
            {
                bool found = false;

                for (int i = 0; i < recordCount; i++)
                {
                    if (records[i].IsLate())
                    {
                        found = true;
                        var loanDays = records[i].Member is PremiumMember premiumMember ? premiumMember.LoanDays : 14;

                         int daysLate = (int)(DateTime.Now - records[i].BorrowDate).TotalDays - loanDays;

                        Console.WriteLine(
                            $"Member: {records[i].Member.Name} | " +
                            $"Book: {records[i].Book.Title} | " +
                            $"Borrow Date: {records[i].BorrowDate:d} | " +
                            $"Days Overdue: {daysLate}"
                        );
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No late returns.");
                }
            }

            public void SeedData()
            {
                AddBook("Clean Code", "Robert Martin", 2008, "Programming");
                AddBook("The Pragmatic Programmer", "Andrew Hunt", 1999, "Programming");

                RegisterMember("Ahmed", "ahmed@gmail.com", false);
                RegisterMember("Mohamed", "mohamed@gmail.com", true);
            }

            private Book FindBook(int id)
            {
                for (int i = 0; i < bookCount; i++)
                {
                    if (books[i].Id == id)
                        return books[i];
                }

                return null;
            }

            private Member FindMember(int id)
            {
                for (int i = 0; i < memberCount; i++)
                {
                    if (members[i].Id == id)
                        return members[i];
                }

                return null;
            }

            private void  AddBorrowedBook(Member member, Book book)
            {
                for (int i = 0; i < member.BorrowedBooks.Length; i++)
                {
                    if (member.BorrowedBooks[i] == null)
                    {
                        member.BorrowedBooks[i] = book;
                        break;
                    }
                }
            }
        }
    }
