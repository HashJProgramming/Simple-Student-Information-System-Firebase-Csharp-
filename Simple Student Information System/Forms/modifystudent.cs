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
using System.IO;

namespace Simple_Student_Information_System
{
    public partial class modifystudent : Form
    {
        public modifystudent()
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
        private void button3_Click(object sender, EventArgs e)
        {
            // Clear button
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            dateTimePicker1.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox10.Text = null;
            pictureBox1.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Update button
            MemoryStream mstream = new MemoryStream();
            pictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arrImage = mstream.GetBuffer();
            UInt32 FileSize;
            FileSize = (uint)mstream.Length;
            mstream.Close();
            StudentDatabase db = new StudentDatabase()
            {
                firstname = textBox1.Text,
                middlename = textBox2.Text,
                lastname = textBox3.Text,
                contactno = textBox4.Text,
                birthdate = dateTimePicker1.Text,
                email = textBox5.Text,
                address = textBox6.Text,
                section = textBox7.Text,
                course = textBox8.Text,
                id = textBox9.Text,
                age = textBox10.Text,
                picture = arrImage

            };
            var dbset = firebaseClient.Update("Csharp/Students/" + textBox9.Text, db);
            MessageBox.Show("Done!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Search button
            try
            {
                var dbget = firebaseClient.Get("Csharp/Students/" + textBox9.Text);
                StudentDatabase dbread = dbget.ResultAs<StudentDatabase>();
                textBox1.Text = dbread.firstname;
                textBox2.Text = dbread.middlename;
                textBox3.Text = dbread.lastname;
                textBox4.Text = dbread.contactno;
                dateTimePicker1.Text = dbread.birthdate;
                textBox5.Text = dbread.email;
                textBox6.Text = dbread.address;
                textBox7.Text = dbread.section;
                textBox8.Text = dbread.course;
                textBox10.Text = dbread.age;

                var ms = new MemoryStream(dbread.picture);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch (Exception)
            {

                MessageBox.Show("Student not exist!");
            }

        }

        private void modifystudent_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Upload button
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
