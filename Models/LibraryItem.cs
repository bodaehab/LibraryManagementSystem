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
        protected LibraryItem(int id, string? title,DateTime dateTime)
        {
            Id = id;
            Title = title;
            AddedDate = dateTime;
        }
        public  abstract string GetInfo();

       

    }
}
