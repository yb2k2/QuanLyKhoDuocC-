using System;
using DGVPrinterHelper;
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
    public partial class US_SellMedicine : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        public US_SellMedicine()
        {
            InitializeComponent();
        }

        private void US_SellMedicine_Load(object sender, EventArgs e)
        {
            lstBoxMedicine.Items.Clear();
            query = "select mname from medic where eDate >= getdate() and quantity > '0'";
            ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lstBoxMedicine.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstBoxMedicine.Items.Clear();
            query = "select mname from medic where mname like '" + txtSearch.Text + "%' and eDate >= getdate() and quantity > '0'";
            ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                lstBoxMedicine.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            } 
        }

        private void lstBoxMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoOfUnit.Clear();

            String name = lstBoxMedicine.GetItemText(lstBoxMedicine.SelectedItem);

            txtMedicineName.Text = name;
            query = "select mid, eDate, perUnit from medic where mname = '" + name + "'";
            ds = fn.getData(query);
            txtMedicineId.Text = ds.Tables[0].Rows[0][0].ToString();
            txtExpriceDate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPricePerUnit.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void txtNoOfUnit_TextChanged(object sender, EventArgs e)
        {
            if (txtNoOfUnit.Text != "")
            {
                Int64 unitPrice = Int64.Parse(txtPricePerUnit.Text);
                Int64 noOfUnit = Int64.Parse(txtNoOfUnit.Text);
                Int64 totalAmount = unitPrice * noOfUnit;
                txtTotalPrice.Text = totalAmount.ToString();
            } else
            {
                txtTotalPrice.Clear();
            }
        }


        protected int n, totalAmount = 0;
        protected Int64 quantity, newQuantity;

        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            if (txtMedicineId.Text != "")
            {
                query = "select quantity from medic where mid = '" + txtMedicineId.Text + "'";
                DataSet ds = fn.getData(query);

                quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = Int64.Parse(txtNoOfUnit.Text);


                if (newQuantity >= 0)
                {
                    n = guna2DataGridView1.Rows.Add();
                    guna2DataGridView1.Rows[n].Cells[0].Value = txtMedicineId.Text;
                    guna2DataGridView1.Rows[n].Cells[1].Value = txtMedicineName.Text;
                    guna2DataGridView1.Rows[n].Cells[2].Value = txtExpriceDate.Text;
                    guna2DataGridView1.Rows[n].Cells[3].Value = txtPricePerUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[4].Value = txtNoOfUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[5].Value = txtTotalPrice.Text;

                    totalAmount = totalAmount + int.Parse(txtTotalPrice.Text);
                    lblTotal.Text = "Rs. " + totalAmount.ToString();

                    query = "update medic set quantity = '" + newQuantity + "' where mid = '" + txtMedicineId.Text + "'";
                    fn.setData(query, "Thuốc đã được thêm vào giỏ hàng.");

                } else
                {
                    MessageBox.Show("Thuốc hết hàng.\n Chỉ số " + quantity + " Sau ", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                clearAll();
                US_SellMedicine_Load(this, null);
            } 
            else
            {
                MessageBox.Show("Chọn thuốc trước tiên.", " Thông Tin ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        int valueAmount;
        String valueId;
        protected Int64 noOfUnit;

     

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueId = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfUnit = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }catch(Exception)
            {

            }
        }

       

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (valueId != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                } 
                catch
                {

                }
                finally
                {
                    query = "select quantity from medic where mid = '" + valueId + "'";
                    ds = fn.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfUnit;

                    query = "update medic set quantity = '" + newQuantity + "' where mid = '" + valueId + "'";
                    fn.setData(query, "Thuốc đã được loại bỏ khỏi giỏ hàng.");
                    totalAmount = totalAmount - valueAmount;
                    lblTotal.Text = "Rs. " + totalAmount.ToString(); 
                }
                US_SellMedicine_Load(this, null);
            }
        }

       

        private void btnPurChasePrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Hóa Đơn Thuốc";
            print.SubTitle = String.Format("Ngày: {0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Tổng số tiền phải trả : " + lblTotal.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);

            totalAmount = 0;
            lblTotal.Text = "Rs. 00";
            guna2DataGridView1.DataSource = 0;
        }


        private void btnSync_Click(object sender, EventArgs e)
        {
            US_SellMedicine_Load(this, null);
        }


        private void clearAll()
        {
            txtMedicineId.Clear();
            txtMedicineName.Clear();
            txtExpriceDate.ResetText();
            txtPricePerUnit.Clear();
            txtNoOfUnit.Clear();
        }

    }
}
