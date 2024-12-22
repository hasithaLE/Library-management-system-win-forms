using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem
{
    public class LibraryManagement
    {
        private readonly string connectionString = "Data Source=THAMARA;Initial Catalog=LibraryManagementSystem;Integrated Security=True;Trust Server Certificate=True";

        // Loan Process
        public string LoanBook(int userNumber, int bookId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the user already borrowed 5 books
                var countCmd = connection.CreateCommand();
                countCmd.CommandText = "SELECT COUNT(*) FROM BorrowedBooks WHERE UserNumber = @userNumber AND Returned = 0";
                countCmd.Parameters.AddWithValue("@userNumber", userNumber);
                int borrowedCount = (int)countCmd.ExecuteScalar();
                if (borrowedCount >= 5)
                    return "You have reached the maximum number of borrowed books.";


                // Check if the book is available and borrowable
                var checkCmd = connection.CreateCommand();
                checkCmd.CommandText = "SELECT Copies, IsReference FROM Books WHERE BookID = @bookId";
                checkCmd.Parameters.AddWithValue("@bookId", bookId);

                using (var reader = checkCmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return "Book not found!";
                    int copies = reader.GetInt32(0);
                    bool isReference = reader.GetBoolean(1);

                    if (copies <= 0)
                        return "No copies available!";
                    if (isReference)
                        return "This book is reference-only and cannot be borrowed.";
                }

                // Add a record in BorrowedBooks
                var loanCmd = connection.CreateCommand();
                loanCmd.CommandText = @"
                    INSERT INTO BorrowedBooks (UserNumber, BookID, BorrowDate, DueDate, Returned)
                    VALUES (@userNumber, @bookId, GETDATE(), DATEADD(DAY, 14, GETDATE()), 0)";
                loanCmd.Parameters.AddWithValue("@userNumber", userNumber);
                loanCmd.Parameters.AddWithValue("@bookId", bookId);
                loanCmd.ExecuteNonQuery();

                // Decrease the number of copies
                var updateCmd = connection.CreateCommand();
                updateCmd.CommandText = "UPDATE Books SET Copies = Copies - 1 WHERE BookID = @bookId AND Copies > 0";
                updateCmd.Parameters.AddWithValue("@bookId", bookId);
                updateCmd.ExecuteNonQuery();

                return "Book loaned successfully!";
            }
        }

        // Return Process
        public string ReturnBook(int bookId, int userNumber)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // check user reserved the book reservation id
                var checkCmd1 = connection.CreateCommand();
                checkCmd1.CommandText =
                    "SELECT TOP(1) BorrowID FROM BorrowedBooks WHERE BookID = @bookId AND UserNumber = @userNumber AND Returned = 0";
                checkCmd1.Parameters.AddWithValue("@bookId", bookId);
                checkCmd1.Parameters.AddWithValue("@userNumber", userNumber);
                using (var reader = checkCmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //get returned ID and udpate the BorrowedBooks table to mark the book as returned
                        int borrowId = reader.GetInt32(0);
                        // close the opened datareader
                        reader.Close();
                        checkCmd1.Dispose();
                        var updateCmd1 = connection.CreateCommand();
                        updateCmd1.CommandText = "UPDATE BorrowedBooks SET Returned = 1 WHERE BorrowID = @borrowId";
                        updateCmd1.Parameters.AddWithValue("@borrowId", borrowId);
                        updateCmd1.ExecuteNonQuery();
                        updateCmd1.Dispose();
                    }
                }

                // Check for reservations
                var reservationCmd = connection.CreateCommand();
                reservationCmd.CommandText = @"
                    SELECT TOP 1 UserNumber FROM Reservations
                    WHERE BookID = @bookId and Notified = 0
                    ORDER BY ReservationDate Desc";
                reservationCmd.Parameters.AddWithValue("@bookId", bookId);

                using (var reader = reservationCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int nextUser = reader.GetInt32(0);
                        reader.Close();
                        reservationCmd.Dispose();
                        NotifyUser(nextUser, "Your reserved book is now available.");

                        // Update the Reservations table marking the user as notified
                        var updateNotifiedCmd = connection.CreateCommand();
                        updateNotifiedCmd.CommandText = "UPDATE Reservations SET Notified = 1 WHERE UserNumber = @userNumber and BookID = @bookId";
                        updateNotifiedCmd.Parameters.AddWithValue("@userNumber", nextUser);
                        updateNotifiedCmd.Parameters.AddWithValue("@bookId", bookId);
                        updateNotifiedCmd.ExecuteNonQuery();
                        updateNotifiedCmd.Dispose();

                        // mark book as borrowed by the next user
                        var loanCmd = connection.CreateCommand();
                        loanCmd.CommandText = @"
                            INSERT INTO BorrowedBooks (UserNumber, BookID, BorrowDate, DueDate, Returned)
                            VALUES (@userNumber, @bookId, GETDATE(), DATEADD(DAY, 14, GETDATE()), 0)";
                        loanCmd.Parameters.AddWithValue("@userNumber", nextUser);
                        loanCmd.Parameters.AddWithValue("@bookId", bookId);
                        loanCmd.ExecuteNonQuery();
                        loanCmd.Dispose();

                        return "Book returned successfully! Next reserved user has been notified & Borrowed";
                    }
                    else
                    {
                        reader.Close();
                        reservationCmd.Dispose();
                        // Increase the number of copies if no reservations
                        var updateCmd = connection.CreateCommand();
                        updateCmd.CommandText = "UPDATE Books SET Copies = Copies + 1 WHERE BookID = @bookId";
                        updateCmd.Parameters.AddWithValue("@bookId", bookId);
                        updateCmd.ExecuteNonQuery();
                        updateCmd.Dispose();
                    }
                }
                connection.Close();

                return "Book returned successfully!";
            }
        }

        // Reservation Process
        public string ReserveBook(int userNumber, int bookId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Add a record in Reservations
                var reserveCmd = connection.CreateCommand();
                reserveCmd.CommandText = "INSERT INTO Reservations (UserNumber, BookID, ReservationDate, Notified) VALUES (@userNumber, @bookId, GETDATE(), 0)";
                reserveCmd.Parameters.AddWithValue("@userNumber", userNumber);
                reserveCmd.Parameters.AddWithValue("@bookId", bookId);
                reserveCmd.ExecuteNonQuery();

                return "Book reserved successfully!";
            }
        }

        // User Registration
        public string RegisterUser(string name, string sex, string idNumber, string address, string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert into Users table
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Users (Name, Sex, IDNumber, Address, Email) VALUES (@name, @sex, @idNumber, @address, @email)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@idNumber", idNumber);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();

                return "User registered successfully!";
            }
        }

        // Book Registration
        public string AddBook(string title, string author, string publisher, int copies, bool isReference)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert into Books table
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Books (Title, Author, Publisher, IsReference, Copies)
                    VALUES (@title, @author, @publisher, @isReference, @copies)";
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                cmd.Parameters.AddWithValue("@isReference", isReference ? 1 : 0);
                cmd.Parameters.AddWithValue("@copies", copies);
                cmd.ExecuteNonQuery();

                return "Book added successfully!";
            }
        }

        // Helper Method: Notify User
        private void NotifyUser(int userNumber, string message)
        {
            // Placeholder for notification logic (e.g., email or SMS)
            //Console.WriteLine($"Notify User {userNumber}: {message}");
        }
    }
}
