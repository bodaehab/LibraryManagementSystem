using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    internal class Book:LibraryItem,ISearchable
    {
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public Book(int id, string title, string author, int year,string genre,DateTime addedDate,bool isAvailable)
        : base(id, title, addedDate)
        {
            Author = author;
            Year = year;
            Genre = genre;
            IsAvailable = isAvailable;
        }
      

        public override string GetInfo()
        {
            string Avaliable = IsAvailable  ? "Available" : "not Available";

            return $"({Id}) Book: {Title} by {Author} ({Year}) AddedTime:{AddedDate:N0} Genre:{Genre} IsAvaliable:{Avaliable}";
        }

        public bool MatchesQuery(string query)
        {
            query = query.ToLower();

            return Title!.ToLower().Contains(query) ||
                   Author.ToLower().Contains(query) ||
                   Genre.ToLower().Contains(query);
        }
    }
}
