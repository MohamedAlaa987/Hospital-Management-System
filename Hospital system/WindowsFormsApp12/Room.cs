using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class Room
    {
        private int RID;
        private string rname;
        private int rcost;
        private string rtype;
        private int PID;
        private database db;
        private string insquery = "";

        public int RID1 { get => RID; set => RID = value; }
        public string Rname { get => rname; set => rname = value; }
        public int Rcost { get => rcost; set => rcost = value; }
        public string Rtype { get => rtype; set => rtype = value; }
        public int PID1 { get => PID; set => PID = value; }

        public Room( string rname, int rcost, string rtype, int pID1)
        {
            Rname = rname;
            Rcost = rcost;
            Rtype = rtype;
            PID1 = pID1;
            RID= ID_count() + 1;
        }

        public Room()
        {
        }
        public bool check_ID(int ID)
        {
            try
            {
                insquery = $"SELECT PID FROM room where PID={ID}";
                db = new database();
                SqlConnection cnn;
                cnn = db.getconnection();
                db.openconnection();
                SqlCommand comd = new SqlCommand(insquery, cnn);
                SqlDataReader data;
                data = comd.ExecuteReader();
                Room bi = new Room();
                while (data.Read())
                {
                    
                    bi.PID = data.GetInt32(0);
                    if (bi.PID != 0) { return true; }
                    
                }
                db.closeconnection();

            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }
        private int ID_count()
        {
            try
            {
                insquery = "SELECT MAX(RID)  FROM room";
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

        public void inesert_room()
        {
            Bill bi = new Bill();
            if (check_ID(this.PID) == true)
            {
                delete();
            }
            insquery = $"insert into room(RID,rname,rcost,rtype,PID) values('{RID}', '{rname}','{rcost}','{rtype}','{PID}')";
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
            if (bi.PID1==this.PID) {

                bi.Rcost = this.rcost;
                bi.Bcost += this.rcost;
                bi.PID1 = this.PID;
                bi.Billdate = DateTime.Now.ToString();
                string col = "rcost";
                string val = bi.Rcost.ToString();
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
                bi.Rcost = this.rcost;
                bi.Bcost = this.rcost;
                bi.PID1 = this.PID;
                bi.Billdate = DateTime.Now.ToString();
                bi.inesert_bill();
            }

        }
        private void delete()
        {
            insquery = $"delete from room where PID={PID}";
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
