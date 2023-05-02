using AssignWpf.Domain;
using CommandLineUI.Commands;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Generic;


namespace AssignWpf.Services
{
    public class ViewAllMembersAction : IMenuItemAction
    {
        private ICommandFactory commandFactory;
        private IDtoConverter dtoConverter;
        private DataGrid responseDataGrid;

        public ViewAllMembersAction(ICommandFactory commandFactory, IDtoConverter dtoConverter, DataGrid responseDataGrid)
        {
            this.commandFactory = commandFactory;
            this.dtoConverter = dtoConverter;
            this.responseDataGrid = responseDataGrid;
        }

        public void Execute(List<string> serverResponse)
        {
            // Assume that the server returns the result of the command as a JSON string
            string result = serverResponse[0];
            Debug.WriteLine(serverResponse[0]);
            Debug.WriteLine(serverResponse);



            ObservableCollection<DTOs.MemberDTO> loanDTOs = dtoConverter.ConvertResultToMemberDTOs(result);
            responseDataGrid.ItemsSource = loanDTOs;
        }
    }
}
