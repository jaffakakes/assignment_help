using DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignWpf.Domain
{
    public interface IDtoConverter
    {
        ObservableCollection<BookDTO> ConvertResultToBookDTOs(string result);
        ObservableCollection<MemberDTO> ConvertResultToMemberDTOs(string result);
        ObservableCollection<LoanDisplayDTO> ConvertResultToLoanDTOs(string result);
    }

}
