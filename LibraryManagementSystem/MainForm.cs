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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoanForm loanForm = new LoanForm();
            loanForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnForm returnForm = new ReturnForm();
            returnForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InquiryForm inquiryForm = new InquiryForm();
            inquiryForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BookRegistrationForm bookRegistrationForm = new BookRegistrationForm();
            bookRegistrationForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserRegistrationForm userRegistrationForm = new UserRegistrationForm();
            userRegistrationForm.Show();
        }
    }
}
