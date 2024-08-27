using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemPharmacyManagament.Admin
{
    public partial class UC_AddUser : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            Int64 mobile = Int64.Parse(txtPhoneNumber.Text);
            String email = txtEmail.Text;
            String username = txtUserName.Text;
            String pass = txtPassword.Text;


            try
            {
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) values ('" + role + "', '" + name + "', '" + dob + "'," + mobile + ", '" + email + "', '" + username + "', '" + pass + "')";
                fn.setData(query, "Sign up Successful.");

            }catch (Exception)
            {
                MessageBox.Show("Username Allready exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtName.Clear();
            txtDob.ResetText();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtRole.SelectedIndex = -1;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username='" + txtUserName.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                pctrAddUser.ImageLocation = @"D:\SystemPharmacyManagament\image_pharmacy\image_pharmacy\yes.png";
            }
            else
            {
                pctrAddUser.ImageLocation = @"D:\SystemPharmacyManagament\image_pharmacy\image_pharmacy\no.png";

            }


            //query = "select * from users where username = '" + txtUserName.Text + "'";
            //DataSet ds = fn.getData(query);

            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    pictureBox1.ImageLocation = @"C:\Users\NGUYEN NHAT HUYNH\OneDrive\Máy tính\ALL_SUBJECT\LAPTRINH_WINDOWS\Product_KTCK\image_pharmacy\yes.png";
            //} 
            //else
            //{
            //    pictureBox1.ImageLocation = @"C:\Users\NGUYEN NHAT HUYNH\OneDrive\Máy tính\ALL_SUBJECT\LAPTRINH_WINDOWS\Product_KTCK\image_pharmacy\no.png";
            //}
        }

    }
}
