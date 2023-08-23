using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Patient
    {
        private string pname;
        private string  disease;
        private string birthdate;
        private string gender;
        private string phone;
        private string address;
        private int PID;
        private string bloodtype;
        private string email;
        private int DEID;
        private int NEID;
        private database db;
        private string insquery = "";

        public string Pname { get => pname; set => pname = value; }
        public string Disease { get => disease; set => disease = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public int PID1 { get => PID; set => PID = value; }
        public string Bloodtype { get => bloodtype; set => bloodtype = value; }
        public string Email { get => email; set => email = value; }
        public int DEID1 { get => DEID; set => DEID = value; }
        public int NEID1 { get => NEID; set => NEID = value; }

        public Patient(string pname, string disease, string birthdate, string gender, string phone, string address, string bloodtype, string email, int dEID1, int nEID1)
        {
            Pname = pname;
            Disease = disease;
            Birthdate = birthdate;
            Gender = gender;
            Phone = phone;
            Address = address;
            Bloodtype = bloodtype;
            Email = email;
            DEID1 = dEID1;
            NEID1 = nEID1;
            PID= ID_count() + 1;
        }
       public  Patient()
        {

        }
        private int ID_count()
        {
            try
            {
                insquery = "SELECT MAX(PID)  FROM patient";
                db = new database();
                SqlConnection cnn;
                cnn = db.getconnection();
                db.openconnection();
                SqlCommand comd = new SqlCommand(insquery, cnn);
                SqlDataReader data;
                data = comd.ExecuteReader();
                while (data.Read())
                {
                    return data.GetInt32(0);
                }
                db.closeconnection();
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        public static string strcheck(string a)
        {
            int c = 0;
            foreach (char x in a)
            {
                if (x >= 'a' && x <= 'z' || x >= 'A' && x <= 'Z')
                {
                    c++;
                }
            }

            if (c == a.Length)
            {
                return a;
            }

            return "";
        }

        public static int intcheck(string a)
        {
            int b;
            if (int.TryParse(a, out b) == true)
            {
                return int.Parse(a);
            }
            return 0;
        }
        public static bool gendercheck(string a)
        {
            if (a == "male")
            {
                return true;
            }
            else if (a == "female")
            {
                return true;
            }
            return false;
        }
        public void inesert_patient()
        {
            insquery = $"insert into patient(PID,pname, gender, birthdate, disease, bloodtype, phone, email, address, DEID,SEID) values('{PID}','{pname}', '{gender}','{birthdate}','{disease}','{bloodtype}','{phone}','{email}','{address}','{DEID}','{NEID}')";
            db = new database();
            SqlConnection cnn = db.getconnection();
            db.openconnection();
            SqlCommand comd = new SqlCommand(insquery, cnn);
            int data = comd.ExecuteNonQuery();
            if (data < 0)
            {
                throw new Exception(" erorr in database");
            }

        }
        public void update_patient(string col, string val, string col2, int val2)
        {
            insquery = $"UPDATE patient SET {col}='{val}' WHERE {col2} = {val2}";
            db = new database();
            SqlConnection cnn = db.getconnection();
            db.openconnection();
            SqlCommand comd = new SqlCommand(insquery, cnn);
            int data = comd.ExecuteNonQuery();
            if (data < 0)
            {
                throw new Exception(" erorr in database");
            }

        }
    }




}
