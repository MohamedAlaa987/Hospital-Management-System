using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    class database
    {

        private string connection = @"Data Source=DESKTOP-BHE3EI6;Initial Catalog=hosptial;User ID=sa;Password=123456789";
        private SqlConnection cnn;

        public SqlConnection Cnn { get => cnn; set => cnn = value; }

        public database()
        {
        }
        

        public  void openconnection()
        {
            Cnn.Open();
        }
        public void closeconnection()
        {
            Cnn.Close();
        }
       public  SqlConnection getconnection()
        {
            this.Cnn = new SqlConnection(this.connection);
            return Cnn ;
        }

    }
}
