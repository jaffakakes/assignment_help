using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignWpf
{
    public class LoanDisplayDTO
    {
        public string Title { get; set; }
        public string Borrower { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Renewals { get; set; }

        public LoanDisplayDTO(string title, string borrower, DateTime loanDate, DateTime dueDate, int renewals)
        {
            Title = title;
            Borrower = borrower;
            LoanDate = loanDate;
            DueDate = dueDate;
            Renewals = renewals;
        }
    }

}

