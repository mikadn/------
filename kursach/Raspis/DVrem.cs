﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Raspis
{
    public partial class DVrem : Form
    {
        public DVrem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met15 d = new Met15();
                string[] str2 = dateTimePicker2.Value.ToString().Split(new char[] { ' ' });
                string[] str = dateTimePicker1.Value.ToString().Split(new char[] { ' ' });                
                d.ADD(comboBox1.Items[comboBox1.SelectedIndex].ToString(),str[1] , str2[1]);
                    this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void DVrem_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
        }
    }
}
