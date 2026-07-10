using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LibraryManagementSystem.Models
{
    internal class PremiumMember : Member
    {
        public int MaxBorrowLimit { get;  } = 10;
        public int LoanDays { get;  } = 30;


        public PremiumMember() {
        BorrowedBooks=new Book[MaxBorrowLimit];
        }

        public override string GetInfo()
        {
            return base.GetInfo() +
                  $"\nMember Type: Premium" +
                  $"\nMax Borrow Limit: {MaxBorrowLimit}" +
                  $"\nLoan Days: {LoanDays}";
        }
    }
}
