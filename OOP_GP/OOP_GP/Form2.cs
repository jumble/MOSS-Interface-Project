﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace OOP_GP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "000000";
            const string userRoot = "HKEY_CURRENT_USER";
            const string subKey = "MossApplicationUserID";
            const string keyName = userRoot + "\\" + subKey;
            maskedTextBox1.Text = (string)Registry.GetValue(keyName, "", "");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subKey = "MossApplicationUserID";
            const string keyName = userRoot + "\\" + subKey;
            Registry.SetValue(keyName, "", maskedTextBox1.Text);
            GlobalVar.GlobalInt = maskedTextBox1.Text;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subKey = "MossApplicationLanguageFilter";
            const string keyName = userRoot + "\\" + subKey;
            Registry.SetValue(keyName, "", this.comboBox1.GetItemText(this.comboBox1.SelectedItem));
            GlobalVar.GlobalValue = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            toolTip1.ToolTipTitle = "Invalid Input";
            toolTip1.Show("Invalid UserID", maskedTextBox1, maskedTextBox1.Location, 5000);
        }
    }
}
