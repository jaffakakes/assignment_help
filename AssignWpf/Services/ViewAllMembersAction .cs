﻿using AssignWpf.Domain;
using CommandLineUI.Commands;
using CommandLineUI;
using DTOs;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;

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
            MessageBox.Show(string.Join("\n", serverResponse));
            Command command = commandFactory.CreateCommand(RequestUseCase.VIEW_ALL_MEMBERS);
            command.Execute();
            string result = command.GetResult();
            ObservableCollection<MemberDTO> membersDTOs = dtoConverter.ConvertResultToMemberDTOs(result);
            responseDataGrid.ItemsSource = membersDTOs;
        }
    }
}
