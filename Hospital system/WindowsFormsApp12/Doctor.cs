using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Doctor : Employee
    {
        private string qualification;
        private database db;
        private string insquery = "";

        public string Qualification { get => qualification; set => qualification = value; }

        public Doctor(string fname , string lname, string mname,int salary, string birthdate, string gender, string phone, string address,string type, string email, int dID1, string qualification):base(fname ,lname,mname,salary,birthdate,gender,phone,address,type,email,dID1)
        {

            Qualification = qualification;
        }
        public Doctor()
        {

        }
        public void  inset_doctor()
        {
            this.inesert_empolyee();
            insquery = $"insert into doctor (EID,qualification) values('{this.EID1}','{this.qualification}')";
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
        public void update_doctor(string col, string val, string col2, int val2)
        {
            insquery = $"UPDATE doctor SET {col}='{val}' WHERE {col2} = {val2}";
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
