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
    public partial class UserRegistrationForm : Form
    {
        private readonly LibraryManagement library = new LibraryManagement();
        public UserRegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string gender = comboBox1.Text;
            string idNumber = textBox2.Text;
            string address = textBox3.Text;
            string email = textBox4.Text;

            string result = library.RegisterUser(name, gender, idNumber, address, email);
            MessageBox.Show(result);
        }
    }
}
