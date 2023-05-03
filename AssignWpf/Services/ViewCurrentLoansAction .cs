using AssignWpf.Domain;
using CommandLineUI.Commands;
using CommandLineUI;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Diagnostics;

namespace AssignWpf.Services
{
    public class ViewCurrentLoansAction : IMenuItemAction
    {
        private ICommandFactory commandFactory;
        private IDtoConverter dtoConverter;
        private DataGrid responseDataGrid;

        public ViewCurrentLoansAction(ICommandFactory commandFactory, IDtoConverter dtoConverter, DataGrid responseDataGrid)
        {
            this.commandFactory = commandFactory;
            this.dtoConverter = dtoConverter;
            this.responseDataGrid = responseDataGrid;
        }

        public void Execute(List<string> serverResponse)
        {
            string result = serverResponse[0];
            Debug.WriteLine(result);
            ObservableCollection<LoanDisplayDTO> loanDTO = dtoConverter.ConvertResultToLoanDTOs(result);
            responseDataGrid.ItemsSource = loanDTO;
        }
    }
}
