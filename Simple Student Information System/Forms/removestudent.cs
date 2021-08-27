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
    public partial class removestudent : Form
    {
        public removestudent()
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Search button
            try
            {
                var dbget = firebaseClient.Get("Csharp/Students/" + textBox1.Text);
                StudentDatabase dbread = dbget.ResultAs<StudentDatabase>();
                MessageBox.Show("Student Name: " + dbread.firstname + " " + dbread.middlename + " " + dbread.lastname);
            }
            catch (Exception)
            {

                MessageBox.Show("Student not found!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Remove button
            try
            {
                var dbget = firebaseClient.Get("Csharp/Students/" + textBox1.Text);
                StudentDatabase dbread = dbget.ResultAs<StudentDatabase>();

                var dbdelete = firebaseClient.Delete("Csharp/Students/" + textBox1.Text);
                textBox1.Clear();
                MessageBox.Show("Deleted! Student Name: " + dbread.firstname + " " + dbread.middlename + " " + dbread.lastname);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Student ID!");
            }
        }

        private void removestudent_Load(object sender, EventArgs e)
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
