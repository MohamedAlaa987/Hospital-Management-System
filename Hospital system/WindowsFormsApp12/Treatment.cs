using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Treatment
    {
        private int TID;
        private string tname;
        private int tcost;
        private int PID;
        private database db;
        private string insquery = "";

        public int TID1 { get => TID; set => TID = value; }
        public string Tname { get => tname; set => tname = value; }
        public int Tcost { get => tcost; set => tcost = value; }
        public int PID1 { get => PID; set => PID = value; }

        public Treatment(string tname, int tcost, int pID1)
        {
            Tname = tname;
            Tcost = tcost;
            PID1 = pID1;
            TID= ID_count() + 1;
        }

        public Treatment()
        {
        }

        

        private int ID_count()
        {
            try
            {
                insquery = "SELECT MAX(TID)  FROM treatment";
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

        public void inesert_treatment()
        {
            Bill bi = new Bill();
            insquery = $"insert into treatment(TID,tname,tcost,PID) values('{TID}', '{tname}','{tcost}','{PID}')";
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
                bi.Tcost = this.tcost;
                bi.Bcost += this.tcost;
                bi.PID1 = this.PID;
                bi.Billdate = DateTime.Now.ToString();
                string col = "tcost";
                string val = bi.Tcost.ToString();
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
                bi.Tcost = this.tcost;
                bi.Bcost = this.tcost;
                bi.PID1 = this.PID;
                bi.Billdate = DateTime.Now.ToString();
                bi.inesert_bill();
            }
            
        }
    }
}
