﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Annon.Xuanxing
{
    public partial class AAonRating : Form
    {
        int findclicktimes = 0;


        public AAonRating()
        {
            InitializeComponent();
            panel3.Visible = false;
            panel4.Top = panel1.Top + panel1.Height;

            panel7.Controls.Clear();
            orders order = new orders();
            order.TopLevel = false;
            order.Parent = panel7;
            order.Dock = DockStyle.Fill;
            order.Show();
            panel7.Dock = DockStyle.Fill;
            button9.Dock = DockStyle.Bottom;
            this.button8.Dock = DockStyle.Top;

            this.Height = panel1.Top + panel1.Height + panel2.Height + panel4.Height;

            chose_comboBox.SelectedIndex = 0;

        }

        private void hBMasterSpecsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
               // this.textbox.text = this.openFileDialog1.FileName;
            }  

        }

        private void aboutAAONEcat32ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex.ToString();
            comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp;
            tmp = chose_comboBox.SelectedItem.ToString();
            if(tmp!="Search In")
                chose_textBox.Text = chose_comboBox.SelectedItem.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            findclicktimes++;
            int tmp = panel4.Top;

            if (findclicktimes % 2 == 1)
            {
                panel3.Visible = true;
                panel4.Top = tmp + panel3.Height;
            }
            else
            {
                panel3.Visible = false;
                panel4.Top = tmp - panel3.Height;
            }
        }

      

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel7.Controls.Clear();
            orders order = new orders();
            order.TopLevel = false;
            order.Parent = panel7;
            order.Dock = DockStyle.Fill;
            order.Show();

            //this.panel7.Visible = true;
            //this.panel8.Visible = false;
            panel7.Dock = DockStyle.Fill;
            button8.Dock = DockStyle.Top;
            this.button9.Dock = DockStyle.Bottom;
            //this.panel7.Dock = DockStyle.Fill;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //this.panel7.Visible = false;
            //this.panel8.Visible = true;
            panel7.Controls.Clear();
            ordersummary ordersum = new ordersummary();
            ordersum.TopLevel = false;
            ordersum.Parent = panel7;
            ordersum.Show();

            panel7.Dock = DockStyle.Fill;
            button9.Dock = DockStyle.Top;
            this.button8.Dock = DockStyle.Top;
            //this.panel8.Dock = DockStyle.Fill;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
 
}
