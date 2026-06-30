using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    abstract class LibraryItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime AddedDate { get; set; }
        protected LibraryItem(int id, string? title)
        {
            Id = id;
            Title = title;
            AddedDate = DateTime.Now;
        }
        public  abstract string GetInfo();

       

    }
}
