using System;
using System.Windows;
using CommandLineUI.Commands;
using System.Collections.Generic;
using ClientSide;

namespace AssignWpf
{
    public partial class PopupWindow : Window
    {
        private MainWindow mainWindow;
        private List<string> serverResponse;
        private ServerConnection serverConnection;

        public int SelectedCommand { get; set; }
        public string Response { get; private set; }

        public PopupWindow(MainWindow mainWindow, ServerConnection serverConnection, int selectedCommand)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.serverResponse = serverResponse;
            this.serverConnection = serverConnection;
            SelectedCommand = selectedCommand;

        }

        private  void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number1 = int.Parse(numberTextBox1.Text);
                int number2 = int.Parse(numberTextBox2.Text);

                List<string> serverResponse =  serverConnection.SendAction(SelectedCommand, number1, number2);


                string result = serverResponse[0];

                // Set the response
                Response = result;

                // Close the popup window
                this.Close();
            }
            catch (FormatException)
            {
                // Display the warning message
                warningTextBlock.Text = "Please enter valid numbers.";
            }
        }
    }
}
