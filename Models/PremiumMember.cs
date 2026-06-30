using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LibraryManagementSystem.Models
{
    internal class PremiumMember : Member
    {
        public int MaxBorrowLimit { get; set; } = 10;
        public int LoanDays { get; set; } = 30;

        public override string GetInfo()
        {
            return $"Premium Member: {Name} | Email: {Email} | " +
                   $"\nBorrow Limit: {MaxBorrowLimit} | Loan Days: {LoanDays}";
        }
    }
}
