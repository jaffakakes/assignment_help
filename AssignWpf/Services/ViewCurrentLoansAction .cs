using AssignWpf.Domain;
using CommandLineUI.Commands;
using CommandLineUI;
using System.Collections.ObjectModel;
using System.Windows.Controls;

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

        public void Execute()
        {
            Command command = commandFactory.CreateCommand(RequestUseCase.VIEW_CURRENT_LOANS);
            command.Execute();
            string result = command.GetResult();
            ObservableCollection<LoanDisplayDTO> loanDTO = dtoConverter.ConvertResultToLoanDTOs(result);
            responseDataGrid.ItemsSource = loanDTO;
        }
    }
}
