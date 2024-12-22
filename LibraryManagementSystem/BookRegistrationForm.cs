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
    public partial class BookRegistrationForm : Form
    {
        private readonly LibraryManagement library = new LibraryManagement();
        public BookRegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string author = textBox2.Text;
            string publisher = textBox3.Text;
            int copies = int.Parse(textBox4.Text);
            bool isReference = checkBox1.Checked;

            string result = library.AddBook(title, author, publisher, copies, isReference);
            MessageBox.Show(result);
        }
    }
}
