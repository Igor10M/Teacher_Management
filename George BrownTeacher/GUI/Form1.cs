using George_BrownTeacher.Bac;
using George_BrownTeacher.Business;
using George_BrownTeacher.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace George_BrownTeacher
{
    public partial class Form1 : Form
    {
        private const string ExpectedUserID = "44444";
        private const string ExpectedPassword = "Rose_1237";

        public Form1()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserTXT.Text == ExpectedUserID && PassTXT.Text == ExpectedPassword)
            {
                MessageBox.Show("User logged in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form2 form2 = new Form2();
                form2.Show();

                this.Hide(); // or this.Close();
            }
            else
            {
                MessageBox.Show("UserID or password incorrect.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
