using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class InquiryForm : Form
    {
        public InquiryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get text from the text box and find the book using the text as part of the title or part of author name or Book ID
            string search = textBox1.Text;
            if (search == "")
            {
                MessageBox.Show("Please enter a search term");
            }
            else
            {
                // search for the book
                string connectionString = "Data Source=THAMARA;Initial Catalog=LibraryManagementSystem;Integrated Security=True;Trust Server Certificate=True";
                string query = "SELECT * FROM Books WHERE Title LIKE '%" + search + "%' OR Author LIKE '%" + search + "%' OR BookID LIKE '%" + search + "%'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@search", search);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No book found");
                    }
                    else
                    {
                        dataGridView1.DataSource = table;
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtTopic.Text = "Book Details";

                string Copies = dataGridView1.SelectedRows[0].Cells["Copies"].Value.ToString() ?? string.Empty;
                string bookName = dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString() ?? string.Empty;
                string bookID = dataGridView1.SelectedRows[0].Cells["BookID"].Value?.ToString() ?? string.Empty;
                string author = dataGridView1.SelectedRows[0].Cells["Author"].Value?.ToString() ?? string.Empty;
                string publisher = dataGridView1.SelectedRows[0].Cells["Publisher"].Value?.ToString() ?? string.Empty;
                string isRef = dataGridView1.SelectedRows[0].Cells["IsReference"].Value?.ToString() ?? string.Empty;

                if (Convert.ToInt64(Copies) > 0)
                {
                    txtAvailability.Text = "Available";
                }
                else
                {
                    txtAvailability.Text = "Unavailable";
                }
                txtBookName.Text = bookName;
                txtBookID.Text = bookID;
                txtAuthor.Text = author;
                txtPublisher.Text = publisher;

                if (isRef == "True")
                {
                    txtIsRef.Text = "Yes";
                }
                else
                {
                    txtIsRef.Text = "No";
                }
                txtCopies.Text = Copies;
            }
        }
    }
}
