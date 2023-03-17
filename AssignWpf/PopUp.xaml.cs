using System;
using System.Windows;
using CommandLineUI.Commands;


namespace AssignWpf
{
    public partial class PopupWindow : Window
    {
        private MainWindow mainWindow;

        public int SelectedCommand { get; set; }
        public string Response { get; private set; }

        public PopupWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number1 = int.Parse(numberTextBox1.Text);
                int number2 = int.Parse(numberTextBox2.Text);

                CommandFactory commandFactory = new CommandFactory();
                Command command = commandFactory.CreateCommand(SelectedCommand);

                // Execute the command and get the result
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
