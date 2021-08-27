using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json.Linq;
using Simple_Student_Information_System.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Student_Information_System
{
    public partial class dashboard : Form
    {
        public dashboard()
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
            // Refresh button
            int total_student = 0;
            ListViewItem list;
            listView1.Items.Clear();
            var dbget = firebaseClient.Get("Csharp/Students/");
            label1.Text = "Dashboard";
            var jsondata = JObject.Parse(dbget.Body);

            
            foreach (var item in jsondata)
            {
                total_student += 1;
                list = listView1.Items.Add(item.Key);
                var profile = firebaseClient.Get("Csharp/Students/" + item.Key);
                StudentDatabase dbread = profile.ResultAs<StudentDatabase>();
                list.SubItems.Add(dbread.firstname);
                list.SubItems.Add(dbread.middlename);
                list.SubItems.Add(dbread.lastname);
                list.SubItems.Add(dbread.age);
                list.SubItems.Add(dbread.course);
                list.SubItems.Add(dbread.section);
                list.SubItems.Add(dbread.contactno);
                list.SubItems.Add(dbread.email);
                list.SubItems.Add(dbread.address);
                label4.Text = total_student.ToString();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addstudent Addstudent = new addstudent();
            // Add Student button
            if (security_layer.pass == true)
            {
                Addstudent.ShowDialog();
                security_layer.pass = false;
            }
            else
            {
                secure security = new secure();
                security.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Modify Student button
            modifystudent Modifystudent = new modifystudent();
            if (security_layer.pass == true)
            {
                Modifystudent.ShowDialog();
                security_layer.pass = false;
            }
            else
            {
                secure security = new secure();
                security.ShowDialog();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Remove Student button
            removestudent Removestudent = new removestudent();
            if (security_layer.pass == true)
            {
                Removestudent.ShowDialog();
                security_layer.pass = false;
            }
            else
            {
                secure security = new secure();
                security.ShowDialog();
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            signin Signin = new signin();
            Signin.Show();
            Hide();
            // Sign out button
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "Dashboard - " + listView1.FocusedItem.Text + " | " + listView1.FocusedItem.SubItems[1].Text + " " + listView1.FocusedItem.SubItems[2].Text + " " + listView1.FocusedItem.SubItems[3].Text + " ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Hide & Show List
            if (security_layer.pass == true)
            {
               if (listView1.Visible == true) 
                {
                    listView1.Visible = false;
                    button5.Text = "Show List";
                }
                else
                {
                    listView1.Visible = true;
                    button5.Text = "Hide List";
                }
                security_layer.pass = false;
            }
            else
            {
                secure security = new secure();
                security.ShowDialog();
            }
        }
    }
}
