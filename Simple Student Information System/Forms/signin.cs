using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Simple_Student_Information_System
{
    public partial class signin : Form
    {
        public signin()
        {
            InitializeComponent();
        }

        // Firebase Config
        IFirebaseConfig firebaseConnection = new FirebaseConfig()
        {
            // Check https://console.firebase.google.com
            AuthSecret = "LfmNoEXifdcFNXU0eB4xcDxxqdfGXkXpa0WwQszu",
            BasePath = "https://hashjdatabase-default-rtdb.asia-southeast1.firebasedatabase.app/"

        };
        IFirebaseClient firebaseClient;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // User Sign Button
            dashboard Dashboard = new dashboard();
            
            try
            {
                byte[] byt = System.Text.Encoding.UTF8.GetBytes(textBox2.Text);
                var dbget = firebaseClient.Get("Csharp/Users/" + textBox1.Text);
                AdminDatabase dbread = dbget.ResultAs<AdminDatabase>();
            
                string username = dbread.username;
                string password = dbread.password;
                if (textBox1.Text == username && Convert.ToBase64String(byt) == password)
                {
                    security_layer.password = textBox2.Text;
                    Dashboard.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password please try again!");
                }
            }
            catch (Exception)
            {
               
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // User Sign up Button
            signup Signup = new signup();
            Signup.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // User Forgot Password Button
            forgotaccount Forgot = new forgotaccount();
            Forgot.ShowDialog();
        }

        private void signin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form Closed 
            addstudent Addstudent = new addstudent();
            dashboard Dashboard = new dashboard();
            modifystudent Modifystudent = new modifystudent();
            removestudent Removestudent = new removestudent();
            searchstudent Searchstudent = new searchstudent();
            signup Signup = new signup();
            Addstudent.Close();
            Dashboard.Close();
            Modifystudent.Close();
            Removestudent.Close();
            Searchstudent.Close();
            Signup.Close();
            Application.Exit();
        }

        private void signin_Load(object sender, EventArgs e)
        {
            // Startup 
            try
            {
                firebaseClient = new FireSharp.FirebaseClient(firebaseConnection);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect to the database");
                throw;
            }
        }
    }
}
