﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemPharmacyManagament.User
{
    public partial class US_ViewCheckValidity : UserControl
    {
        function fn = new function();
        String query;
        public US_ViewCheckValidity()
        {
            InitializeComponent();
        }

        private void setDataGridView(String query, String lblName, Color col)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            lblSet.Text = lblName;
            lblSet.ForeColor = col;
        }
        private void US_ViewCheckValidity_Load(object sender, EventArgs e)
        {
            lblSet.Text = "";
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCheck.SelectedIndex == 0)
            {
                query = "select * from medic where eDate >= getdate()";
                setDataGridView(query, "Valid Medicine", Color.Black);
            } 
            else if (txtCheck.SelectedIndex == 1)
            {
                query = "select * from medic where eDate <= getdate()";
                setDataGridView(query, "Expried Medicine", Color.Red);
            } 
            else if (txtCheck.SelectedIndex == 2)
            {
                query = "select * from medic";
                setDataGridView(query, "", Color.Black);
            }
        }
    }
}
