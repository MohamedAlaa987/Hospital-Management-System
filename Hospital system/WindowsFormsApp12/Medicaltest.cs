using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Medicaltest
    {
        private int MTID;
        private string mtname;
        private int mtcost;
        private int PID;
        private database db;
        private string insquery = "";

        public int MTID1 { get => MTID; set => MTID = value; }
        public string Mtname { get => mtname; set => mtname = value; }
        public int Mtcost { get => mtcost; set => mtcost = value; }
        public int PID1 { get => PID; set => PID = value; }

        public Medicaltest( string mtname, int mtcost, int pID1)
        {
            Mtname = mtname;
            Mtcost = mtcost;
            PID1 = pID1;
            MTID= ID_count() + 1;
        }

        public Medicaltest()
        {
        }


        private int ID_count()
        {
            try
            {
                insquery = "SELECT MAX(MTID)  FROM Medicaltest";
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

        public void inesert_Medicaltest()
        {
            Bill bi = new Bill();
            
            insquery = $"insert into Medicaltest(MTID,mtname,mtcost,PID) values('{MTID}', '{mtname}','{mtcost}','{PID}')";
            db = new database();
            SqlConnection cnn = db.getconnection();
            db.openconnection();
            SqlCommand comd = new SqlCommand(insquery, cnn);
            int data = comd.ExecuteNonQuery();
            if (data < 0)
            {
                throw new Exception(" erorr in database");
            }
            bi = bi.check_ID(this.PID);
            if (bi.PID1 == this.PID)
            {
                bi.Mtcost = this.mtcost;
                bi.Bcost += this.mtcost;
                bi.PID1 = this.PID;
                bi.Billdate = DateTime.Now.ToString();
                string col = "mtcost";
                string val = bi.Mtcost.ToString();
                string col1 = "PID";
                int val2 = this.PID;
                bi.update_bill(col, val, col1, val2);
                col = "billcost";
                val = bi.Bcost.ToString();
                col1 = "PID";
                val2 = this.PID;
                bi.update_bill(col, val, col1, val2);
            }
            else
            {
                bi.Mtcost = this.mtcost;
                bi.Bcost = this.mtcost;
                bi.PID1 = this.PID;
                bi.Billdate = DateTime.Now.ToString();
                bi.inesert_bill();
            }

        }



    }
}
