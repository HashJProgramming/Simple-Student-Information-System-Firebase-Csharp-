using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Student_Information_System.Forms
{
    public partial class secure : Form
    {
        int attempt = 0;
        public secure()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == security_layer.password)
            {
                security_layer.pass = true;
                Close();
            }else if (attempt == 3)
            {
                Application.Exit();
            }
            else
            {
                attempt += 1;
                MessageBox.Show("Wrong Password! Attempt: " + attempt.ToString());
            }

            

        }
    }
}
