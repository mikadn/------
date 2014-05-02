﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Dobavlenie
{
    public partial class DVrach : Form
    {
        public DVrach()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met14 d = new Met14();
                if (d.prov_id(Convert.ToInt32(textBox2.Text)) == true)
                {
                    d.ADD(textBox1.Text, Convert.ToInt32(textBox2.Text), d.RaschetZarplat2(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox5.Text),Convert.ToInt32(textBox4.Text) ), DateTime.Today.ToString(), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    this.Close();
                }
                else { MessageBox.Show("ID должности не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

   
    }
}
