﻿using AssignWpf.Domain;
using CommandLineUI.Commands;
using CommandLineUI;
using DTOs;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AssignWpf.Services
{
    public class ViewAllBooksAction : IMenuItemAction
    {
        private ICommandFactory commandFactory;
        private IDtoConverter dtoConverter;
        private DataGrid responseDataGrid;

        public ViewAllBooksAction(ICommandFactory commandFactory, IDtoConverter dtoConverter, DataGrid responseDataGrid)
        {
            this.commandFactory = commandFactory;
            this.dtoConverter = dtoConverter;
            this.responseDataGrid = responseDataGrid;
        }

        public void Execute()
        {
            Command command = commandFactory.CreateCommand(RequestUseCase.VIEW_ALL_BOOKS);
            command.Execute();
            string result = command.GetResult();
            ObservableCollection<BookDTO> bookDTOs = dtoConverter.ConvertResultToBookDTOs(result);
            responseDataGrid.ItemsSource = bookDTOs;
        }
    }
}