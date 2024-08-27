using System;
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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            uS_Dashbord1.Visible = false;
            uS_AddMedicine1.Visible = false;
            uS_ViewMedicine1.Visible = false;
            uS_UpdateMedicine1.Visible = false;
            uS_ViewCheckValidity1.Visible = false;
            uS_SellMedicine1.Visible = true;
            btnDashbord.PerformClick();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uS_Dashbord1.Visible = true;
            uS_Dashbord1.BringToFront();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uS_AddMedicine1.Visible = true;
            uS_AddMedicine1.BringToFront();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uS_ViewMedicine1.Visible = true;
            uS_ViewMedicine1.BringToFront();
        }

        private void btnUpdateMedi_Click(object sender, EventArgs e)
        {
            uS_UpdateMedicine1.Visible = true;
            uS_UpdateMedicine1.BringToFront();
        }

        private void btnMeVaChk_Click(object sender, EventArgs e)
        {
            uS_ViewCheckValidity1.Visible = true;
            uS_ViewCheckValidity1.BringToFront();
        }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            uS_SellMedicine1.Visible = true;
            uS_SellMedicine1.BringToFront();
        }
    }
}
