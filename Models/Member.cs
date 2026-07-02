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
            return $" Member: {Name} | Email: {Email} | " +
              $"\nDate: {JoinDate} ";

        }

        public bool MatchesQuery(string query)
        {
            query = query.ToLower();

            return Name.ToLower().Contains(query) ||
                   Email.ToLower().Contains(query);
        }
    }
}
