using AssignWpf.Domain;
using DTOs;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AssignWpf.Services
{
    public class DtoConverter : IDtoConverter
    {
        public ObservableCollection<BookDTO> ConvertResultToBookDTOs(string result)
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

        public ObservableCollection<MemberDTO> ConvertResultToMemberDTOs(string result)
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

        public ObservableCollection<LoanDisplayDTO> ConvertResultToLoanDTOs(string result)
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
                // Split the line using a comma
                string[] parts = lines[i].Split(',');

                // Check if the parts array contains the expected number of elements
                if (parts.Length >= 5)
                {
                    string title = parts[0].Trim();
                    string borrower = parts[1].Trim();
                    DateTime loanDate = DateTime.Parse(parts[2].Trim());
                    DateTime dueDate = DateTime.Parse(parts[3].Trim());
                    int renewals = int.Parse(parts[4].Trim());

                    loanDisplayDTOs.Add(new LoanDisplayDTO(title, borrower, loanDate, dueDate, renewals));
                }
                else
                {
                    // Log an error or throw an exception if the parts array does not contain the expected number of elements
                    Debug.WriteLine("Error: The input line does not contain the expected number of elements.");
                }
            }

            return loanDisplayDTOs;
        }
    }
}
