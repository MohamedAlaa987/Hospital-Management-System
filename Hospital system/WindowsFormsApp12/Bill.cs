using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Bill
    {
        private string billdate;
        private int tcost;
        private int mtcost;
        private int rcost;
        private int BID;
        private int bcost;
        private int PID;
        private database db;
        private string insquery = "";

        public string Billdate { get => billdate; set => billdate = value; }
        public int Tcost { get => tcost; set => tcost = value; }
        public int Mtcost { get => mtcost; set => mtcost = value; }
        public int Rcost { get => rcost; set => rcost = value; }
        public int BID1 { get => BID; set => BID = value; }
        public int Bcost { get => bcost; set => bcost = value; }
        public int PID1 { get => PID; set => PID = value; }

        public Bill(int tcost, int mtcost, int rcost, int bID1, int bcost, int pID1)
        { 
            Tcost = tcost;
            Mtcost = mtcost;
            Rcost = rcost;
            BID1 = bID1;
            Bcost = bcost;
            PID1 = pID1;
            BID = ID_count() + 1;
        }

        public Bill()
        {
            BID = ID_count() + 1;
        }

        private int ID_count()
        {
            try
            {
                insquery = "SELECT MAX(BID)  FROM bill";
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

        public Bill check_ID(int ID )
        {
            try
            {
                insquery = $"SELECT BID,tcost,rcost ,MTcost,billcost,billdate,PID FROM Bill where PID={ID}";
                db = new database();
                SqlConnection cnn;
                cnn = db.getconnection();
                db.openconnection();
                SqlCommand comd = new SqlCommand(insquery, cnn);
                SqlDataReader data;
                data = comd.ExecuteReader();
                Bill bi = new Bill();
                while (data.Read())
                {
                    bi.BID = data.GetInt32(0);
                    bi.tcost = data.GetInt32(1);
                    bi.rcost = data.GetInt32(2);
                    bi.mtcost = data.GetInt32(3);
                    bi.bcost = data.GetInt32(4);
                    bi.billdate = data.GetString(5);
                    bi.PID = data.GetInt32(6);
                }
                db.closeconnection();
                return bi;
                
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void inesert_bill()
        {

            insquery = $"insert into bill(BID,tcost,rcost,mtcost,billcost,billdate,PID) values('{BID}', '{tcost}','{rcost}','{mtcost}','{bcost}','{billdate}','{PID}')";
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
        public void update_bill(string col, string val, string col2, int val2)
        {
            insquery = $"UPDATE bill SET {col}='{val}' WHERE {col2} = {val2}";
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
