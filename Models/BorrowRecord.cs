using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    internal class BorrowRecord
    {
        public int Id { get; set; }

        public Book Book { get; set; } = null!;

        public PremiumMember Member { get; set; } = null!;

        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsLate()
        {
           
            if (ReturnDate == null)
            {
               
                return DateTime.Now > BorrowDate.AddDays(Member.LoanDays);
            }

            
            return ReturnDate > BorrowDate.AddDays(Member.LoanDays);
        }
    }
}
