using DTOs;
using CommandLineUI.Presenters.Visitor;
using System.Collections.Generic;
using UseCase;

namespace CommandLineUI.Presenters
{
    class CurrentLoansPresenter : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<LoanDTO> loans = ((LoanDTO_List)DataToPresent).List;
                LoanPrinter printer = new LoanPrinter();
                MembersWithLoansCounter counter = new MembersWithLoansCounter();

                GetVisitableLoans(loans)
                    .ForEach(
                        loan =>
                        {
                            loan.AcceptVisitFrom(printer);
                            loan.AcceptVisitFrom(counter);
                        });

                List<string> lines = new List<string>(loans.Count + 2);
               
             
                lines.AddRange(printer.Lines);
             

                return new CommandLineViewData(lines);
            }
        }

        private List<VisitableLoan> GetVisitableLoans(List<LoanDTO> loans)
        {
            List<VisitableLoan> list = new List<VisitableLoan>(loans.Count);

            loans.ForEach(loan => list.Add(new VisitableLoan(loan)));

            return list;
        }
    }
}
