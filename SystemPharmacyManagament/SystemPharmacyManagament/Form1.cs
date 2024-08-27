﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemPharmacyManagament
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (txtUsername.Text == "root" && txtPassword.Text == "root")
                {
                    frmAdmin admin = new frmAdmin();
                    admin.Show();
                    this.Hide();
                }

            }
            else
            {
                query = "select * from users where username = '" + txtUsername.Text + "' and pass= '" + txtPassword.Text + "'";
                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Admin")
                    {
                        frmAdmin admin = new frmAdmin(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "User")
                    {
                        frmUser user = new frmUser();
                        user.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu sai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




            if (txtUsername.Text == "duy" && txtPassword.Text == "adm")
            {
                frmAdmin admin = new frmAdmin();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lỗi Username hay Password", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
