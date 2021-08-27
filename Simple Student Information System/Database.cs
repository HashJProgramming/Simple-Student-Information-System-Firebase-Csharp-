using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Student_Information_System
{
    public static class security_layer
    {
        public static string password;
        public static bool pass = false;
    }

    class AdminDatabase
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }

    class StudentDatabase 
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string contactno { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string section { get; set; }
        public string course { get; set; }
        public string id { get; set; }
        public string age { get; set; }
        public byte[] picture { get; set; }

    }
}
