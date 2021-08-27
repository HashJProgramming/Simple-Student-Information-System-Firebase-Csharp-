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
    public partial class addstudent : Form
    {
        public addstudent()
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
            // Upload Button
            MemoryStream memoryStream = new MemoryStream();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create Student button
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
            var dbset = firebaseClient.Set("Csharp/Students/" + textBox9.Text, db);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            pictureBox1.Image = null;
            MessageBox.Show("Done!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear button
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            pictureBox1.Image = null;
        }

        private void addstudent_Load(object sender, EventArgs e)
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
