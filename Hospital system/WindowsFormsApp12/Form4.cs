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
    public partial class Form4 : Form
    {

        Dictionary<string, string> Namesoftypes = new Dictionary<string, string>(){  { "First Name","fname" } ,  { "Middel Name", "mname" } ,  { "Last Name", "lname" } ,  { "Birthdate", "birthdate" } ,  { "Gender", "gender" } , { "Phone Number", "phone" } ,  { "Address", "address" } ,  { "Email", "email" } ,  { "Salary", "salary" } ,  { "Type", "type" } , { "Department", "DID" }  };
        Dictionary<string, string> Namesoftypes2 = new Dictionary<string, string>() { { "qualification", "qualification" }, { "number of patient", "numberofpatient" } };
        List <Employee> arr = new List<Employee>();
        Dictionary<int, string> dic = new Dictionary<int, string>();
        private string empquery = "select * from Employee";
        private string depquery = "SELECT DID ,dname FROM department ";
        private string type = "";

        public Form4()
        {
            InitializeComponent();
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
            label24.Text = moveToToolStripMenuItem.DropDownItems[2].Text;
        }






        private void Form4_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.AddRange( Namesoftypes.Keys.ToList().ToArray());
            
            try
            {


                database db = new database();
                SqlConnection cnn = db.getconnection();
                db.openconnection();
                
                    SqlCommand comd = new SqlCommand(empquery, cnn);
                   
                    SqlDataReader data;
                    data = comd.ExecuteReader();

                    while (data.Read())
                    {
                        Employee em = new Employee();
                        em.EID1 = data.GetInt32(0);
                        em.Mname = data.GetString(1);
                        em.Lname = data.GetString(2);
                        em.Fname = data.GetString(3);
                        em.Type= data.GetString(4);
                        em.Email = data.GetString(5);
                        em.Gender = data.GetString(6);
                        em.Birthdate= data.GetString(7);
                        em.Salary = data.GetInt32(8);
                        em.Address = data.GetString(9);
                        em.Phone = data.GetString(10);
                        em.DID1 = data.GetInt32(11);
                        arr.Add(em);


                    }
                    data.Close();
                        comd.CommandText =depquery;
                        data=comd.ExecuteReader();
                    while (data.Read())
                    {
                        dic.Add(data.GetInt32(0), data.GetString(1));
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
            foreach (Employee x in arr)
            {
                int index =guna2DataGridView1.Rows.Add();
                DisplayResult(index,x);
                
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string input = guna2TextBox1.Text;
            checkInput(input);
        }


        private void checkInput(string input)
        {
           guna2DataGridView1.Rows.Clear();
            foreach (Employee x in arr)
            {
                if(x.Fname==input|| x.Lname == input|| x.Mname == input|| x.Salary.ToString()== input|| x.Birthdate == input|| x.Gender == input|| x.Phone == input|| x.Address == input|| x.Type == input|| x.Email == input)
                {
                    int index =guna2DataGridView1.Rows.Add();
                    DisplayResult(index, x);
                }
            }
        }
        private void  DisplayResult(int index,Employee x)
        {
           guna2DataGridView1.Rows[index].Cells[0].Value = x.EID1;
           guna2DataGridView1.Rows[index].Cells[1].Value = x.Fname;
           guna2DataGridView1.Rows[index].Cells[2].Value = x.Mname;
           guna2DataGridView1.Rows[index].Cells[3].Value = x.Lname;
           guna2DataGridView1.Rows[index].Cells[4].Value = x.Birthdate;
           guna2DataGridView1.Rows[index].Cells[5].Value = x.Gender;
           guna2DataGridView1.Rows[index].Cells[6].Value = x.Phone;
           guna2DataGridView1.Rows[index].Cells[7].Value = x.Address;
           guna2DataGridView1.Rows[index].Cells[8].Value = x.Email;
           guna2DataGridView1.Rows[index].Cells[9].Value = x.Salary;
           guna2DataGridView1.Rows[index].Cells[10].Value = x.Type;

           guna2DataGridView1.Rows[index].Cells[11].Value = dic[x.DID1];
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            type = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[10].Value.ToString();
            if (guna2TextBox1.Text == ""&& guna2DataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("search about Employee to update it ");
            }
            else if(guna2DataGridView1.SelectedRows.Count==0){
                MessageBox.Show("mark  Employee in table you when to update ");
            }
            else
            {
                guna2Panel1.Location=guna2DataGridView1.Location;
                
                if (type == "doctor"){
                    if (guna2ComboBox1.Items.Count==11)
                    {
                        guna2ComboBox1.Items.Add(Namesoftypes2.Keys.First());
                    }
                }
                if (type == "nurse")
                {
                    if (guna2ComboBox1.Items.Count==11)
                    {
                        guna2ComboBox1.Items.Add(Namesoftypes2.Keys.Last());
                    }
                }
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
            col1 = "EID";
            val2 = ID;
            if (type == "doctor"&&Namesoftypes2.ContainsKey(col)==true)
            {
                Doctor doc = new Doctor();
                doc.update_doctor(Namesoftypes2[col], val, col1, val2);
                MessageBox.Show("doctor updated");
            }
            else if (type == "nurse"&& Namesoftypes2.ContainsKey(col) == true)
            {
                Nurse num = new Nurse();
                num.update_nurse(Namesoftypes2[col], val, col1, val2);
                MessageBox.Show("nurse updated");
            }
            else
            {
                Employee emp = new Employee();
                emp.update_empolyee(col, val, col1, val2);
                MessageBox.Show("employee updated");
            }
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
