using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmViewOrder : Form
    {
        pos.BL.Transactions.orders orderBL = new pos.BL.Transactions.orders();
        pos.BL.Transactions.orderdetails orderdetailBL = new pos.BL.Transactions.orderdetails();

        DataTable dt;
        int orderid;

        public frmViewOrder(int _orderid)
        {
            InitializeComponent();
            orderid = _orderid;
        }

        private void DGVLoad()
        {
            dgv.DataSource = orderdetailBL.List(orderid);
            dgv.Columns["ORDER DETAIL ID"].Visible = false;
            dgv.Columns["ORDER ID"].Visible = false;
            dgv.Columns["PRODUCT ID"].Visible = false;
            dgv.Columns["DATE AND TIME"].Visible = false;
            dgv.Columns["PRICE"].Visible = false;
            dgv.Columns["STOCK"].Visible = false;
            dgv.Columns["TOTAL AMOUNT"].Visible = false;
        }

        private void LBLLoad()
        {
            dt = orderBL.Select(orderid);

            lblFullName.Text = dt.Rows[0]["FULL NAME"].ToString();
            lblAddress.Text = dt.Rows[0]["ADDRESS"].ToString();
            lblContactNumber.Text = dt.Rows[0]["CONTACT NUMBER"].ToString();
            lblDateAndtime.Text = dt.Rows[0]["DATE AND TIME"].ToString();
            lblTotalAmount.Text = dt.Rows[0]["TOTAL AMOUNT"].ToString();
        }


        private void frmViewOrder_Load(object sender, EventArgs e)
        {
           LBLLoad();
           DGVLoad();
           this.Text = "VIEW ORDER ID " + orderid;
        }

       
    }
}
