using System;
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
    public partial class US_AddMedicine : UserControl
    {
        function fn = new function();
        String query;
        public US_AddMedicine()
        {
            InitializeComponent();
        }

        private void btnAddP_Click(object sender, EventArgs e)
        {
           if(txtMediId.Text != "" && txtMediName.Text != "" && txtMediNumber.Text != "" && txtQuantity.Text != "" && txtPricePerUnit.Text != "")
            {
                String mid = txtMediId.Text;
                String mname = txtMediName.Text;
                String mnumber = txtMediNumber.Text;
                String mdate = txtManuFact.Text;
                String edate = txtExpriceMedi.Text;
                Int64 quantity = Int64.Parse(txtQuantity.Text);
                Int64 perunit = Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic (mid, mname, mnumber, mDate, eDate, quantity, perUnit) values ('" + mid + "','" + mname + "','" + mnumber + "','" + mdate + "','" + edate + "'," + quantity + "," + perunit + ")";
                fn.setData(query, "Thuốc được thâm vào dữ liệu");
            } else
            {
                MessageBox.Show("Nhập tất cả dữ liệu.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtMediId.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtPricePerUnit.Clear();
            txtQuantity.Clear();
            txtManuFact.ResetText();
            txtExpriceMedi.ResetText();
        }
    }
}
