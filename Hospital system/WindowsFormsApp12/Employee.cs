using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Employee
    {
        private string fname;
        private string lname;
        private string mname;
        private int salary;
        private string birthdate;
        private string gender;
        private string phone;
        private string address;
        private int EID;
        private string type;
        private string email;
        private int DID;
        private database db;
        private string insquery = "";

        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Mname { get => mname; set => mname = value; }
        public int Salary { get => salary; set => salary = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public int EID1 { get => EID; set => EID = value; }
        public string Type { get => type; set => type = value; }
        public string Email { get => email; set => email = value; }
        public int DID1 { get => DID; set => DID = value; }

        public Employee(string fname, string lname, string mname, int salary, string birthdate, string gender, string phone, string address, string type, string email, int dID1)
        {
            Fname = fname;
            Lname = lname;
            Mname = mname;
            Salary = salary;
            Birthdate = birthdate;
            Gender = gender;
            Phone = phone;
            Address = address;
            Type = type;
            Email = email;
            DID1 = dID1;
            EID = ID_count()+1;
        }
        public Employee()
        {

        }
        private int ID_count() 
        {
            try
            {
                insquery = "SELECT MAX(EID)  FROM employee";
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
            catch(Exception e)
            {
                throw e;
            }
            return 0;
        }
        public static string  strcheck(string a)
        {
            int c = 0;
            foreach(char x in a)
            {
                if(x>='a'&& x <= 'z' || x >= 'A' && x <= 'Z')
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
        public void inesert_empolyee()
        {
            insquery = $"insert into employee(EID,fname, mname, lname, gender, birthdate, type, salary, phone, email, address, DID) values('{EID}', '{fname}','{mname}','{lname}', '{gender}','{birthdate}','{type}','{salary}','{phone}','{email}','{address}','{DID}')";
            db = new database();
            SqlConnection cnn = db.getconnection();
            db.openconnection();
            SqlCommand comd = new SqlCommand(insquery, cnn);
            int data =comd.ExecuteNonQuery();
            if (data < 0)
            {
                throw new Exception(" erorr in database");
            }

        }
        public  void update_empolyee(string col ,string val,string col2,int val2)
        {
            insquery = $"UPDATE employee SET {col}='{val}' WHERE {col2} = {val2}";
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
