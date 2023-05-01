using System;
using System.Windows;
using CommandLineUI.Commands;
using System.Collections.Generic;


namespace AssignWpf
{
    public partial class PopupWindow : Window
    {
        private MainWindow mainWindow;
        private List<string> serverResponse;

        public int SelectedCommand { get; set; }
        public string Response { get; private set; }

        public PopupWindow(MainWindow mainWindow, List<string> serverResponse)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.serverResponse = serverResponse;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number1 = int.Parse(numberTextBox1.Text);
                int number2 = int.Parse(numberTextBox2.Text);

                CommandFactory commandFactory = new CommandFactory();
                Command command = commandFactory.CreateCommand(int.Parse(serverResponse[0]), number1, number2);

                // Execute the command
                command.Execute();

                // Get the result
                string result = command.GetResult();

                // Set the response
                Response = $"Result: {result}";

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
