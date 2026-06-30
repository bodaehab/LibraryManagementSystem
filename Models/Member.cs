using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    internal class Member : ISearchable
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;

        public string Email { get; set; }=string.Empty;
        public DateTime JoinDate { get; set; }
        public Book[] BorrowedBooks { get; set; } = Array.Empty<Book>();

        public virtual string GetInfo()
        {
            return $"Premium Member: {Name} | Email: {Email} | " +
              $"\nDate: {JoinDate} ";

        }

        public bool MatchesQuery(string query)
        {
            return Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
               Email.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}
