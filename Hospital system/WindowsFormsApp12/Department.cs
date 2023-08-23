using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Department
    {
        private int DID;
        private string dname;
        private string insquery;
        private database db;
        public int DID1 { get => DID; set => DID = value; }
        public string Dname { get => dname; set => dname = value; }

        public Department(string dname)
        {
            Dname = dname;
            DID1= ID_count() + 1;
        }
        public Department()
        {

        }

        private int ID_count()
        {
            try
            {
                insquery = "SELECT MAX(DID)  FROM department";
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



        public static int intcheck(string a)
        {
            int b;
            if (int.TryParse(a, out b) == true)
            {
                return int.Parse(a);
            }
            return 0;
        }




        public void inesert_department()
        {
            insquery = $"insert into department(DID,dname,EID) values('{DID}', '{dname}','{16}')";
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
