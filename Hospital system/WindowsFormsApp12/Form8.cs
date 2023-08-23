using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    public partial class Form8 : Form
    {
        private bool button1Clicked1 = false;
        private bool button1Clicked2 = false;
        private bool button1Clicked3 = false;
        SqlConnection cnn;
        database db = new database();
        List<Patient> arr = new List<Patient>();
        string patquery = "select PID ,pname from patient";
        int PID = 0;
        public Form8()
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
            label24.Text = moveToToolStripMenuItem.DropDownItems[9].Text;
        }


        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                db.openconnection();

                SqlCommand comd = new SqlCommand(patquery, cnn);

                SqlDataReader data;
                data = comd.ExecuteReader();

                while (data.Read())
                {
                    Patient pat = new Patient();
                    pat.PID1 = data.GetInt32(0);
                    pat.Pname = data.GetString(1);
                    arr.Add(pat);
                }
                data.Close();
                foreach (Patient x in arr) { 
                    guna2ComboBox1.Items.Add(x.Pname); 
                }
                
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            button1Clicked1 = true;
            
            int c = 1;
            if (guna2ComboBox1.Text.Equals(""))
            {
                c--;
                MessageBox.Show("must select patient name");
                
            }
            if (c == 1)
            {
                PID = checkID();
                generateroom("room");
                guna2Panel1.Visible = true;
                guna2Panel2.Visible = true;
            }

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            button1Clicked2 = true;
            int c = 1;
            if (guna2ComboBox1.Text.Equals(""))
            {
                c--;
                MessageBox.Show("must select patient name");

            }
            if (c == 1)
            {
                PID = checkID();
                generateroom("treat");
                guna2Panel1.Visible = true;
                guna2Panel2.Visible = false;
            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            button1Clicked3 = true;
            int c = 1;
            if (guna2ComboBox1.Text.Equals(""))
            {
                c--;
                MessageBox.Show("must select patient name");

            }
            if (c == 1)
            {
                PID = checkID();
                generateroom("medical");
                guna2Panel1.Visible = true;
                guna2Panel2.Visible = false;
            }
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            int cost = -1;
            if (int.TryParse(guna2TextBox1.Text, out cost) == false)
            {
                MessageBox.Show("cost must be munbers");
            }
            else if (int.TryParse(guna2TextBox1.Text, out cost) == true)
            {
                if (button1Clicked1 == true)
                {
                    Room rom = new Room(guna2ComboBox2.Text, cost, guna2ComboBox3.Text, PID);
                    rom.inesert_room();
                    MessageBox.Show("Room assigned");
                    clear();
                    guna2ComboBox2.Items.Clear();
                    guna2ComboBox3.Items.Clear();
                    button1Clicked1 = false;
                }
                else if(button1Clicked2 == true)
                {
                    Treatment treat = new Treatment(guna2ComboBox2.Text, cost, PID);
                    treat.inesert_treatment();
                    MessageBox.Show("treatment assigned");
                    clear();
                    guna2ComboBox2.Items.Clear();
                    button1Clicked2 = false;
                }
                 else if(button1Clicked3 == true)
                {
                    Medicaltest test = new Medicaltest(guna2ComboBox2.Text, cost, PID);
                    test.inesert_Medicaltest();
                    MessageBox.Show("medicaltest assigned");
                    clear();
                    guna2ComboBox2.Items.Clear();
                    button1Clicked3 = false;
                }
            }
        }
        private void clear()
        {
            if (button1Clicked1)
            {
                guna2ComboBox3.SelectedItem = null;

            }
            guna2ComboBox2.SelectedItem = null;
            guna2TextBox1.Clear();
            guna2Panel1.Visible = false;
        }




        private int  checkID()
        {
            foreach(Patient x in arr)
            {
                if(x.Pname== guna2ComboBox1.Text)
                {
                    return x.PID1;
                }
                
            }
            return 0;
        }
        private void generateroom(string input )
        {
            if (input == "room")
            {
                for (int i = 1010; i <= 1030; i++)
                {
                    guna2ComboBox2.Items.Add(i);
                }
                guna2ComboBox3.Items.AddRange(new string[] { "normal", "vip" });
            }
            else if (input == "treat")
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.AddRange(new string[]
                {
                    "CROCINE",
"ASPIRIN",
"NAMOSLATE",
"GLUCOSE",
"TARIVID",
"CANESTEN",
"DICLOFENAC",
"ANTACIDS",
"VERMOX",
"OVEX",
"OMEE",
"AVIL",
"HIDRASEC",
"PARIET",
"UTINOR",
"PARIET",
"CIPROXIN",
"CYPROSTAT",
"ANDROCUR",
"ANDROCUR",
"DESTOLIT",
"URSOFALK",
"ORS",
"URSOGAL",
"OMNI GEL",
"DETTOL",
"DETTOL",
"BETADINE",
"LIVER-52",
"METHYLPHENIDATE",
"BETA-BLOCKER",
"BENZODIAZEPINES",
"Z-DRUG",
"ANTIPSYCHOTIC",
"SSRI-ANTIDEPRESSANT",
"MAOI-DRUG",
"BICASUL",
"NASAL DECONGESTANTS",
"EXPECTORANTS",
"ANTI HISTAMINES",
"COUGH SUPRESSANTS",
"ACETAMINOPHEN",
"HPV VACCINE",
"SYRINGE",
"INJECTION",
"MORFIN",
"ORLISTAT",
"ZALASTA",
"ZANTAC",
"ZEFFIX",
"ZINNAT",
"ZOFRAN",
"ZOCOR"
                });
            }
            else if (input == "medical")
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.AddRange(new string[]
                {
"X-RAY",
"BLOOD TEST",
"URINE TEST",
"MRI SCAN",
"ENDOSCOPY",
"BIOPSY",
"ULTRASOUND",
"CT-SCAN",
"CBC",
"FLU TEST",
                });
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
