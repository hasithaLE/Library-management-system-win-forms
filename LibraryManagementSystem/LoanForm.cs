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
    public partial class LoanForm : Form
    {
        private LibraryManagement library = new LibraryManagement();
        public LoanForm()
        {
            InitializeComponent();
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            int userNumber = int.Parse(txtUserNumber.Text);
            int bookId = int.Parse(txtBookID.Text);

            string result = library.LoanBook(userNumber, bookId);
            MessageBox.Show(result);
        }
    }
}
