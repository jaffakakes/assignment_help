using System.Windows;
using System.Windows.Controls;
using CommandLineUI.Menu;
using CommandLineUI;
using CommandLineUI.Commands;
using DTOs;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AssignWpf
{
    public partial class MainWindow : Window
    {
        private MenuUI menuUI;

        public MainWindow()
        {
            InitializeComponent();

            MenuFactory menuFactory = MenuFactory.INSTANCE;
            Menus menu = (Menus)menuFactory.Create();
            menuUI = new MenuUI(menu);

            // Populate the ListBox with menu items
            menuUI.DisplayInListBox(menuListBox);
        }

        private ObservableCollection<BookDTO> ConvertResultToBookDTOs(string result)
        {
            string[] lines = result.Split(Environment.NewLine);
            ObservableCollection<BookDTO> bookDTOs = new ObservableCollection<BookDTO>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                int id = int.Parse(parts[0].Trim());
                string title = parts[1].Trim();
                string author = parts[2].Trim();
                string isbn = parts[3].Trim();
                string state = parts[4].Trim();

                bookDTOs.Add(new BookDTO(id, author, isbn, title, state));
            }

            return bookDTOs;
        }

        private ObservableCollection<MemberDTO> ConvertResultToMemberDTOs(string result)
        {
            string[] lines = result.Split(Environment.NewLine);
            ObservableCollection<MemberDTO> memberDTOs = new ObservableCollection<MemberDTO>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                int id = int.Parse(parts[0].Trim());
                string name = parts[1].Trim();

                memberDTOs.Add(new MemberDTO(id, name));
            }

            return memberDTOs;
        }

        private ObservableCollection<LoanDisplayDTO> ConvertResultToLoanDTOs(string result)
        {
            // Return an empty collection if the input is empty or consists only of whitespace characters
            if (string.IsNullOrWhiteSpace(result))
            {
                return new ObservableCollection<LoanDisplayDTO>();
            }

            // Split the input string using different newline characters
            string[] lines = Regex.Split(result, @"\r\n|\r|\n");
            ObservableCollection<LoanDisplayDTO> loanDisplayDTOs = new ObservableCollection<LoanDisplayDTO>();

            // Update the loop condition to process single line input as well
            for (int i = 0; i < lines.Length; i++)
            {
                Debug.WriteLine("Processing line " + (i + 1) + ": " + lines[i].Trim());
                // Split the line using a regular expression that matches multiple spaces
                string[] parts = Regex.Split(lines[i], @"\s\s+");

                string title = parts[0].Trim();
                string borrower = parts[1].Trim();
                DateTime loanDate = DateTime.Parse(parts[2].Trim());
                DateTime dueDate = DateTime.Parse(parts[3].Trim());
                int renewals = int.Parse(parts[4].Trim());

                loanDisplayDTOs.Add(new LoanDisplayDTO(title, borrower, loanDate, dueDate, renewals));
            }

            return loanDisplayDTOs;
        }











        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menuListBox.SelectedItem != null)
            {
                MenuItems menuItem = (MenuItems)menuListBox.SelectedItem;

                CommandFactory commandFactory = new CommandFactory();
                if (menuItem.Id == RequestUseCase.VIEW_CURRENT_LOANS)
                {
                    Command command = commandFactory.CreateCommand(menuItem.Id);
                    command.Execute();
                    string result = command.GetResult();
                    ObservableCollection<LoanDisplayDTO> LoanDTO = ConvertResultToLoanDTOs(result);
                    responseDataGrid.ItemsSource = LoanDTO;
                }
               else if (menuItem.Id == RequestUseCase.VIEW_ALL_MEMBERS)
                {
                    Command command = commandFactory.CreateCommand(menuItem.Id);
                    command.Execute();
                    string result = command.GetResult();
                    ObservableCollection<MemberDTO> MembersDTOs = ConvertResultToMemberDTOs(result);
                    responseDataGrid.ItemsSource = MembersDTOs;
                }

                else if (menuItem.Id == RequestUseCase.VIEW_ALL_BOOKS)
                {
                    Command command = commandFactory.CreateCommand(menuItem.Id);
                    command.Execute();
                    string result = command.GetResult();

                    // Convert the result string to a collection of BookDTO objects
                    ObservableCollection<BookDTO> bookDTOs = ConvertResultToBookDTOs(result);

                    // Set the ItemsSource of the DataGrid
                    responseDataGrid.ItemsSource = bookDTOs;
                }
                else if(menuItem.Id == RequestUseCase.BORROW_BOOK || menuItem.Id == RequestUseCase.RETURN_BOOK || menuItem.Id == RequestUseCase.RENEW_LOAN)
                {
                    PopupWindow popupWindow = new PopupWindow(this);
                    popupWindow.SelectedCommand = menuItem.Id; // Set the selected command
                    popupWindow.ShowDialog(); // Show the popup window as a modal dialog

                    if (!string.IsNullOrEmpty(popupWindow.Response))
                    {
                        responseTextBlock.Text = popupWindow.Response;
                    }
                }
                else if(menuItem.Id == RequestUseCase.EXIT)
                {
                    this.Close();
                }

                menuListBox.SelectedItem = null; // Deselect the item in the ListBox
            }
        }
    }
    }




