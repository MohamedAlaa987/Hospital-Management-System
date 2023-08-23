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

    public partial class Form3 : Form
    {
        SqlConnection cnn;
        List<Department> arr = new List<Department>();
        database db = new database();
        private string query = "SELECT DID ,dname FROM department ";
        /*(fname,mname,lname,gender,birth_data,type,salid,email,address) values('Roxanne',' O ',' Rodriguez ','female','6/4/1986',' parnment,' 1','434-420-9223','aileen.donnel@gmail.com','865 Queens Lane,Lynchburg, Virginia(VA)')*/
       



        public Form3()
        {
            InitializeComponent();
            cnn = db.getconnection();
            guna2Panel1.Visible = false;
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
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int c,presult;
            bool f = true;
            string fname = "", lname = "", mname = "", address = "", email = "", gender = "", phone = "", birthdate = "", type="";
            int salary=0, eid = 0, did=0;
            c = check();
            if (c == 11)
            {
                fname = Employee.strcheck(guna2TextBox1.Text);
                mname = Employee.strcheck(guna2TextBox2.Text);
                lname = Employee.strcheck(guna2TextBox3.Text);
                email = guna2TextBox4.Text;
                type = guna2TextBox5.Text.ToLower();
                address = guna2TextBox7.Text;
                phone = (Employee.intcheck(guna2TextBox8.Text)).ToString();
                birthdate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                salary = Employee.intcheck(guna2TextBox6.Text);
                foreach (Department x in arr)
                {
                    if (guna2ComboBox1.Text == x.Dname) { did = x.DID1; }
                }
                if (guna2TextBox5.Text.ToLower() != "doctor" && guna2TextBox5.Text.ToLower() != "nurse")
                {
                   
                    

                    if (Employee.strcheck(fname) == "")
                    {
                        MessageBox.Show("first name must only characters");
                        f = false;
                    }
                    if (Employee.strcheck(mname) == "")
                    {
                        MessageBox.Show("middel name must only characters");
                        f = false;
                    }
                    if (Employee.strcheck(lname) == "")
                    {
                        MessageBox.Show("lname name must only characters");
                        f = false;
                    }
                    if ((Employee.intcheck(guna2TextBox6.Text)) == 0 && guna2TextBox6.Text.Equals("0") == false)
                    {
                        MessageBox.Show("salary must only digits");
                        f = false;
                    }
                    if (did == 0 && guna2ComboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("must entre Department");
                        f = false;
                    }
                    if (phone == "0" || Employee.intcheck(phone) == 0)
                    {
                        MessageBox.Show("phone must only digits");
                        f = false;
                    }
                    if (f == true)
                    {
                        if (radioButton2.Checked == true)
                        {
                            gender = "female";
                        }
                        else
                        {
                            gender = "male";
                        }

                        Employee emp = new Employee(fname, lname, mname, salary, birthdate, gender, phone, address, type, email, did);
                        emp.inesert_empolyee();
                        MessageBox.Show("Employee created  ");
                        clearitems();
                    }
                }
                else
                {
                    if (guna2TextBox5.Text.ToLower() == "doctor")
                    {
                       
                            Doctor doc = new Doctor(fname, lname, mname, salary, birthdate, gender, phone, address, type, email, did, guna2TextBox9.Text);
                        doc.inset_doctor();
                        MessageBox.Show("Employee created  ");
                        clearitems();


                    }
                    else if (guna2TextBox5.Text.ToLower()== "nurse")
                    {
                        Nurse doc = new Nurse(fname, lname, mname, salary, birthdate, gender, phone, address, type, email, did, 0);
                        doc.inset_nurse();
                        MessageBox.Show("Employee created  ");
                        clearitems();
                    }
                }
                
            }
        }












        private void clearitems()
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
            guna2TextBox5.Clear();
            guna2TextBox6.Clear();
            guna2TextBox7.Clear();
            guna2TextBox8.Clear();
            guna2TextBox9.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            guna2ComboBox1.SelectedItem = null;
        }










        


        private int check()
        {
            int c = 0;
            if (guna2TextBox1.Text.Equals(""))
            {
                label13.Text = "first name required";
                label13.Visible = true;
            }
            else
            {
                c++;
                label13.Visible = false;
            }
            if (guna2TextBox2.Text.Equals(""))
            {
                label14.Text = "middel name required";
                label14.Visible = true;
            }
            else
            {
                c++;
                label14.Visible = false;
            }
            if (guna2TextBox3.Text.Equals(""))
            {
                label15.Text = "last name required";
                label15.Visible = true;
            }
            else
            {
                c++;
                label15.Visible = false;
            }
            if (guna2TextBox4.Text.Equals(""))
            {
                label16.Text = "email required";
                label16.Visible = true;
            }
            else
            {
                c++;
                label16.Visible = false;
            }
            if (guna2TextBox5.Text.Equals(""))
            {
                label17.Text = "type required";
                label17.Visible = true;
            }
            else
            {
                c++;
                label17.Visible = false;
            }
            if (guna2TextBox6.Text.Equals(""))
            {
                label18.Text = "salary required";
                label18.Visible = true;
            }
            else
            {
                c++;
                label18.Visible = false;
            }
            if (guna2TextBox7.Text.Equals(""))
            {
                label19.Text = "address required";
                label19.Visible = true;
            }
            else
            {
                c++;
                label19.Visible = false;
            }
            if (guna2TextBox8.Text.Equals(""))
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
                label22.Text = "department  required";
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
            if (guna2TextBox9.Text.Equals("")&& guna2TextBox5.Text.Equals("doctor"))
            {
                label21.Text = "  Qualification required";
                label21.Visible = true;
            }
            else
            {
                c++;
                label21.Visible = false;
            }
            return c;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            try
            {



                db.openconnection();

                SqlCommand comd = new SqlCommand(query, cnn);

                SqlDataReader data;
                data = comd.ExecuteReader();

                while (data.Read())
                {
                    Department dm = new Department();
                    dm.Dname = data.GetString(1);
                    dm.DID1 = data.GetInt32(0);
                    arr.Add(dm);


                }
                db.closeconnection();
                foreach (Department i in arr)
                {
                    guna2ComboBox1.Items.Add(i.Dname);
                }

            }

            catch (Exception ee)
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







        private void guna2GradientButton2_Click(object sender, EventArgs e)
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

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text.ToLower() == "doctor")
            {
                guna2Panel1.Visible = true;
            }
            else
            {
                guna2Panel1.Visible = false;
            }
        }
    }
}
