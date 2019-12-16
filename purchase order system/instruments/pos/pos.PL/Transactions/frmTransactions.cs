using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL.Transactions
{
    public partial class frmTransactions : Form
    {
        EL.Transactions.transactions transactionEL = new EL.Transactions.transactions();
        EL.Transactions.productsintransactions productsintransactionEL = new EL.Transactions.productsintransactions();
        EL.Registrations.customers customerEL = new EL.Registrations.customers();


        BL.Transactions.transactions transactionBL = new BL.Transactions.transactions();
        BL.Transactions.productsintransactions productsintransactionBL = new BL.Transactions.productsintransactions();
        BL.Registrations.customers customerBL = new BL.Registrations.customers();


        public frmTransactions()
        {
            InitializeComponent();
        }

        private void PopulateDGV()
        {
            dgv.DataSource = transactionBL.List(txtSearch.Text);
        }

        private void PopulateDGVCartDetails(string keywords)
        {
            dgvCartDetails.DataSource = productsintransactionBL.List(keywords);
        }

        private void ManageDGV()
        {
            methods.DGVBUTTONViewVoid(dgv);
            PopulateDGV();
            methods.DGVHiddenColumns(dgv, "CUSTOMER ID", "CONTACT NUMBER", "C");
            methods.DGVTheme(dgv);
            methods.DGVFillWeights(dgv, new string[] { "TRANSACTION ID", "TRANSACTION DATE AND TIME", "TOTAL AMOUNT", "AMOUNT TENDERED", "CHANGE AMOUNT", "IS VOID", "FULL NAME" }, new int[] { 15, 20, 10, 10, 10, 10, 25 });

            PopulateDGVCartDetails("");
            methods.DGVTheme(dgvCartDetails);
            methods.DGVFillWeights(dgvCartDetails, new string[] { "PRODUCT NAME", "QUANTITY", "PRICE" }, new int[] { 60,20,20 });

        }

        private void ShowView(bool bol)
        {
  
           pnlView.Visible = bol;
            pnlMain.Visible = !bol;
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("SUCCESS");
                PopulateDGV();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            PopulateDGV();
            ManageDGV();
            ShowView(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1)
            {
                transactionEL.Transactionid = Convert.ToInt32(dgv.SelectedRows[0].Cells["TRANSACTION ID"].Value);
                transactionEL = transactionBL.Select(transactionEL);
            }
                

            if (e.ColumnIndex == 0 )
            {
               
                
                customerEL.Customerid = transactionEL.Customerid;
                customerBL.Select(customerEL);


                lblCustomerNameAndContactNumber.Text = customerEL.Fullname + "\n" + customerEL.Contactnumber;
   
                lblTransactionDate.Text = transactionEL.Transactiondatetime.ToString();
                lblTotalAmount.Text = methods.ConvertToMoneyFormat(transactionEL.Totalamount);
                lblAmountTendered.Text = methods.ConvertToMoneyFormat(transactionEL.Amounttendered);
                lblChangeAmount.Text = methods.ConvertToMoneyFormat(transactionEL.ChangeAmount);

                if (transactionEL.Isvoid == 0)
                {
                    pnlVoid.Visible = false;
                }
                else
                {
                    pnlVoid.Visible = true;
                }

                PopulateDGVCartDetails(transactionEL.Transactionid.ToString());
                

                lblTitle.Text = "VIEW TRANSACTION DETAILS OF TRANSACTION ID " + transactionEL.Transactionid;
                
                ShowView(true);
            }

            if (e.ColumnIndex == 1)
            {
                if (transactionEL.Isvoid == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("ARE YOU SURE TO VOID THIS SELECTED TRANSACTION?", "VOIDING", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        transactionEL.Isvoid = 1;
                        ShowResult(transactionBL.Update(transactionEL));
                    }
                }
                else
                {
                    MessageBox.Show("THIS TRANSACTION IS ALREADY VOIDED");
                }
            }

        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            ShowView(false);
        }
    }
}
