using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace WindowsFormsApp12
{
    public partial class Form9 : Form
    {

        Dictionary<string, string> Namesoftypes = new Dictionary<string, string>(){  { "Name","Pname" }  ,  { "Birthdate", "birthdate" } ,  { "Gender", "gender" } , { "Phone Number", "phone" } ,  { "Address", "address" } ,  { "Email", "email" } ,  { "Disease", "disease" } ,  { "bloodType", "bloodtype" } , { "Doctor", "DEID" }, { "Nurse", "SEID" } };
        List<Patient> arr = new List<Patient>();
        Dictionary<int, string> dic = new Dictionary<int, string>();
        database db = new database();
        SqlConnection cnn;
        private string patquery = "select * from patient";
        private string depquery = "SELECT EID ,fname,lname FROM employee ";
        private string updatepatp = "";


        public Form9()
        {
            InitializeComponent();
            cnn = db.getconnection();
            initmenu();
        }
         
        



        private void initmenu()
        {
            moveToToolStripMenuItem.DropDownItems.Clear();
            moveToToolStripMenuItem.DropDownItems.Add("Main page");
            moveToToolStripMenuItem.DropDownItems[0].Click += toolStripMenuItem3_Click;
            moveToToolStripMenuItem.DropDownItems.Add("Add Employee");
            moveToToolStripMenuItem.DropDownItems[1].Click += guna2Button1_Click;
            moveToToolStripMenuItem.DropDownItems.Add("show Employees");
            moveToToolStripMenuItem.DropDownItems[2].Click += guna2Button2_Click;
            moveToToolStripMenuItem.DropDownItems.Add("Add Department");
            moveToToolStripMenuItem.DropDownItems[3].Click += guna2Button3_Click;
            moveToToolStripMenuItem.DropDownItems.Add("Medical Tests && Medicines");
            moveToToolStripMenuItem.DropDownItems[4].Click += guna2Button7_Click;
            moveToToolStripMenuItem.DropDownItems.Add("hospital Specialties");
            moveToToolStripMenuItem.DropDownItems[5].Click += guna2Button4_Click;
            moveToToolStripMenuItem.DropDownItems.Add("Add patient");
            moveToToolStripMenuItem.DropDownItems[6].Click += guna2Button5_Click;
            moveToToolStripMenuItem.DropDownItems.Add("show patients");
            moveToToolStripMenuItem.DropDownItems[7].Click += guna2Button6_Click;
            moveToToolStripMenuItem.DropDownItems.Add("Rooms");
            moveToToolStripMenuItem.DropDownItems[8].Click += guna2Button8_Click;
            moveToToolStripMenuItem.DropDownItems.Add("Patients Items");
            moveToToolStripMenuItem.DropDownItems[9].Click += guna2Button9_Click;
            moveToToolStripMenuItem.DropDownItems.Add("Patients Bills");
            moveToToolStripMenuItem.DropDownItems[10].Click += guna2Button10_Click;
            helpToolStripMenuItem.DropDownItems[0].Click += toolStripMenuItem6_Click;
            label24.Location = new Point((this.Width - 171) / 2, 6);
            label24.Text = moveToToolStripMenuItem.DropDownItems[7].Text;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.AddRange(Namesoftypes.Keys.ToList().ToArray());
            try
            {


                
                
                db.openconnection();
                
                    SqlCommand comd = new SqlCommand(patquery, cnn);
                   
                    SqlDataReader data;
                    data = comd.ExecuteReader();

                    while (data.Read())
                    {
                        Patient pat = new Patient();
                        pat.Bloodtype = data.GetString(0);
                        pat.Pname = data.GetString(1);
                        pat.Birthdate = data.GetString(2);
                        pat.Phone = data.GetString(3);
                        pat.Gender= data.GetString(4);
                        pat.PID1 = data.GetInt32(5);
                        pat.Email = data.GetString(6);
                        pat.Address= data.GetString(7);
                        pat.Disease = data.GetString(8);
                        pat.DEID1 = data.GetInt32(9);
                        pat.NEID1 = data.GetInt32(10);
                        arr.Add(pat);


                    }
                    data.Close();
                        comd.CommandText =depquery;
                        data=comd.ExecuteReader();
                    while (data.Read())
                    {
                        dic.Add(data.GetInt32(0),data.GetString(1)+""+data.GetString(2));
                    }
                db.closeconnection();

            }

            catch (Exception ee)
            {
                throw ee;

            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
           guna2DataGridView1.Rows.Clear();
            foreach (Patient x in arr)
            {
                int index =guna2DataGridView1.Rows.Add();
                DisplayResult(index,x);
                
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string input = guna2TextBox1.Text;
            int key = checkName_doc(input);
            checkInput(input,key);
        }


        private void checkInput(string input, int key )
        {
            guna2DataGridView1.Rows.Clear();
            foreach (Patient x in arr)
            {
                if (x.Pname == input  || x.Disease == input || x.Birthdate == input || x.Gender == input || x.Phone == input || x.Address == input || x.Bloodtype == input || x.Email == input||x.NEID1==key||x.DEID1==key)
                {
                    int index = guna2DataGridView1.Rows.Add();
                    DisplayResult(index, x);
                }
            }
        }
        private int checkName_doc(string input)
        {
            foreach(KeyValuePair<int,string> pair in dic)
            {
                if (EqualityComparer<string>.Default.Equals(pair.Value, input)) { return pair.Key; }
            }
            return 0;
        }
        private void  DisplayResult(int index,Patient x)
        {
           guna2DataGridView1.Rows[index].Cells[0].Value = x.PID1;
           guna2DataGridView1.Rows[index].Cells[1].Value = x.Pname;
           guna2DataGridView1.Rows[index].Cells[2].Value = x.Birthdate;
           guna2DataGridView1.Rows[index].Cells[3].Value = x.Gender;
           guna2DataGridView1.Rows[index].Cells[4].Value = x.Phone;
           guna2DataGridView1.Rows[index].Cells[5].Value = x.Address;
           guna2DataGridView1.Rows[index].Cells[6].Value = x.Email;
           guna2DataGridView1.Rows[index].Cells[7].Value = x.Bloodtype;
           guna2DataGridView1.Rows[index].Cells[8].Value = x.Disease;
           guna2DataGridView1.Rows[index].Cells[9].Value = dic[x.DEID1];
           guna2DataGridView1.Rows[index].Cells[10].Value = dic[x.NEID1];

          
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("search about Patient to update it ");
            }
            else if(guna2DataGridView1.SelectedRows.Count==0){
                MessageBox.Show("mark  Patient in table you when to update ");
            }
            else
            {
                guna2Panel1.Location=guna2DataGridView1.Location;
                guna2Panel1.Visible = true;
            }
        }
        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            string col = "";
            string val = "";
            string col1 = "";
            int val2 =0;
            int ID ;
            ID=int.Parse(guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            col = guna2ComboBox1.Text;
            val = guna2TextBox2.Text;
            col1 = "PID";
            val2 = ID;
            Patient pat = new Patient();
            pat.update_patient(col, val, col1, val2);
            MessageBox.Show("patient updated");
        guna2ComboBox1.SelectedItem = null;
            guna2TextBox2.Clear();
            guna2Panel1.Visible = false;

        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
            this.Hide();
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Hide();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.Show();
            this.Hide();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();
            f.Show();
            this.Hide();
        }





        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) { WindowState = FormWindowState.Maximized; }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

       
    }
    }
