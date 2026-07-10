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
        public Book[] BorrowedBooks { get; set; } 



        public Member()
        {
            BorrowedBooks = new Book[5]; 
        }
        public virtual string GetInfo()
        {
            string borrowedBooksInfo;
            if (BorrowedBooks == null) {

                borrowedBooksInfo = "None";
            }
            else
            {
                borrowedBooksInfo = string.Join(", ",
            BorrowedBooks
                .Where(b => b != null)
                .Select(b => b.Title));
            }
        
           
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Email: {Email}\n" +
                   $"Join Date: {JoinDate:d}\n"+
                   $" Borrowed Books: \n[{borrowedBooksInfo}]";

            
        }

        public bool MatchesQuery(string query)
        {
            query = query.ToLower();

            return Name.ToLower().Contains(query) ||
                   Email.ToLower().Contains(query);
        }
    }
}
