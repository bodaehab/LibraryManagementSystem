using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    internal class BorrowRecord
    {
        public int Id { get; set; }

        public Book Book { get; set; } = null!;

        public Member Member { get; set; } = null!;

        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }


        public bool IsLate()
        {
            int loanDays = Member is PremiumMember premiumMember? premiumMember.LoanDays: 14;

            return (DateTime.Now - BorrowDate).TotalDays > loanDays;
        
        }
    }
}
