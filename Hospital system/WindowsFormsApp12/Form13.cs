﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp12
{
    public partial class Form13 : Form
    {
        public Form13()
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
            label24.Location = new Point((this.Width -171) / 2, 6);
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
