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
    public partial class ReturnForm : Form
    {
        private LibraryManagement library = new LibraryManagement();
        public ReturnForm()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(txtBookID.Text);
            int userNumber = int.Parse(txtUserNumber.Text);

            string result = library.ReturnBook(bookId, userNumber);
            MessageBox.Show(result);
        }
    }
}
