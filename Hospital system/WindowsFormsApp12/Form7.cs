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
    public partial class Form7 : Form
    {


        SqlConnection cnn;
        List<Employee> arr = new List<Employee>();
        

        database db = new database();
        string empquery = "SELECT fname,lname,type,EID FROM employee ";
        string patquery = "select SEID from patient";


        public Form7()
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
            label24.Text = moveToToolStripMenuItem.DropDownItems[6].Text;
        }



        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int c;
            bool f = true;
            string name, address, email ,phone="",bloodtype,disease,birthdate,gender="";
            c = check();
            if (c == 9)
            {

                if(Patient.strcheck(guna2TextBox1.Text).Equals(""))
                {
                    f = false;
                }
                name = Patient.strcheck(guna2TextBox1.Text);
                email = guna2TextBox3.Text;
                bloodtype= guna2ComboBox3.Text;
                disease = guna2TextBox5.Text;
                birthdate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                address = guna2TextBox5.Text;
                disease = guna2TextBox6.Text;
                if (Patient.gendercheck(radioButton1.Checked.ToString()) == true)
                {
                    gender ="m";
                }
                if (Patient.gendercheck(radioButton2.Checked.ToString()) == true)
                {
                    gender = "f";
                }
                if (f == true)
                {
                    Patient pat = new Patient(name, disease, birthdate, gender, phone, address, bloodtype, email, getIDDoctorNurse()["doc"], getIDDoctorNurse()["nus"]);
                    pat.inesert_patient();
                    MessageBox.Show($"successful created");
                    clear();
                }
            }
        }
        private void clear()
        {
            guna2ComboBox1.SelectedItem = null;
            guna2ComboBox2.SelectedItem = null;
            guna2ComboBox3.SelectedItem = null;
            guna2TextBox1.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
            guna2TextBox5.Clear();
            guna2TextBox6.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private Dictionary<string,int> getIDDoctorNurse()
        {
            Dictionary<string, int> dic= new Dictionary<string, int>();
            foreach (Employee x in arr)
            {
                if(guna2ComboBox1.Text== x.Fname + " " + x.Lname&&x.Type=="doctor")
                {
                    dic.Add("doc", x.EID1);
                }
                if (guna2ComboBox2.Text == x.Fname + " " + x.Lname && x.Type == "nurse")
                {
                    dic.Add("nus", x.EID1);
                }

            }
            return dic;
        }



        private int check()
        {
            int c = 0;
            if (guna2TextBox1.Text.Equals(""))
            {
                label13.Text = "Name required";
                label13.Visible = true;
            }
            else
            {
                c++;
                label13.Visible = false;
            }
            if (guna2ComboBox3.Text.Equals(""))
            {
                label16.Text = "email required";
                label16.Visible = true;
            }
            else
            {
                c++;
                label16.Visible = false;
            }
            if (guna2ComboBox3.Text.Equals(""))
            {
                label17.Text = "Blood Type required";
                label17.Visible = true;
            }
            else
            {
                c++;
                label17.Visible = false;
            }
            if (guna2TextBox5.Text.Equals(""))
            {
                label18.Text = "Disease required";
                label18.Visible = true;
            }
            else
            {
                c++;
                label18.Visible = false;
            }
            if (guna2TextBox5.Text.Equals(""))
            {
                label19.Text = "address required";
                label19.Visible = true;
            }
            else
            {
                c++;
                label19.Visible = false;
            }
            if (guna2TextBox6.Text.Equals(""))
            {
                label20.Text = "phone required";
                label20.Visible = true;
            }
            else
            {
                c++;
                label20.Visible = false;
            }
            if (guna2ComboBox1.Text.Equals(""))
            {
                label21.Text = "Doctor required";
                label21.Visible = true;
            }
            else
            {
                c++;
                label21.Visible = false;
            }
            if (guna2ComboBox2.Text.Equals(""))
            {
                label22.Text = "nurse required";
                label22.Visible = true;
            }
            else
            {
                c++;
                label22.Visible = false;
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                label23.Text = "gender required";
                label23.Visible = true;
            }
            else
            {
                c++;
                label23.Visible = false;
            }
            return c;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Nurse nun = new Nurse();
            nun.Update_num_of_patient();
            try
            {
                db.openconnection();

                SqlCommand comd = new SqlCommand(empquery, cnn);

                SqlDataReader data;
                data = comd.ExecuteReader();

                while (data.Read())
                {
                    Employee em = new Employee();
                    em.Fname = data.GetString(0);
                    em.Lname = data.GetString(1);
                    em.Type = data.GetString(2);
                    em.EID1 = data.GetInt32(3);
                    arr.Add(em);
                }
                data.Close();
                foreach(Employee x in arr)
                {
                    if (x.Type == "doctor")
                    {
                        guna2ComboBox1.Items.Add(x.Fname + " " + x.Lname);
                    }
                    if (x.Type == "nurse")
                    {
                        guna2ComboBox2.Items.Add(x.Fname + " " + x.Lname);
                    }

                }
            }
            catch(Exception ee)
            {
                throw ee;
            }

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
