using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Nurse:Employee
    {
        private SqlConnection cnn;
        private database db = new database();
        private List<Patient> arr = new List<Patient>();
        private List<Nurse> arr1 = new List<Nurse>();
        private int number_of_patient;
        private string patquery = "select SEID from patient";
        private string nuquery = "select EID from nurse";
        private string insquery = "";


        public int Number_of_patient { get => number_of_patient; set => number_of_patient = value; }
        public Nurse(string fname, string lname, string mname, int salary, string birthdate, string gender, string phone, string address,string type, string email, int dID1, int number_of_patient) : base(fname, lname, mname, salary, birthdate, gender, phone, address,type, email, dID1)
        {

            Number_of_patient = number_of_patient;
        }

        public Nurse(int number_of_patient) : base()
        {
            Number_of_patient = number_of_patient;
        }
        public Nurse()
        {

        }
        public void Update_num_of_patient()
        {
            int sum=0;
            search();
            foreach(Nurse x in arr1)
            {
                foreach(Patient y in arr)
                {
                    if (x.EID1 == y.NEID1)
                    {
                        sum++;
                    }
                }
                x.number_of_patient = sum;
                sum = 0;
            }
        }
        private void  search()
        {
            cnn = db.getconnection();
            db.openconnection();
            SqlCommand comd = new SqlCommand(patquery, cnn);

            SqlDataReader data;
            data = comd.ExecuteReader();

            while (data.Read())
            {
                Patient pat = new Patient();
                pat.NEID1 = data.GetInt32(0);
                arr.Add(pat);
            }
            data.Close();
            comd.CommandText = nuquery;
            data = comd.ExecuteReader();
            while (data.Read())
            {
                Nurse nun = new Nurse();
                nun.EID1 = data.GetInt32(0);
                arr1.Add(nun);
            }
            db.closeconnection();

        }

        public void inset_nurse()
        {
            this.inesert_empolyee();
            insquery = $"insert into nurse (EID,numberofpatient) values('{this.EID1}','{this.number_of_patient}')";
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
        public void update_nurse(string col, string val, string col2, int val2)
        {
            insquery = $"UPDATE nurse SET {col}='{val}' WHERE {col2} = {val2}";
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
