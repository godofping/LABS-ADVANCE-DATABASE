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
    public partial class frmManagePurchaseOrders : Form
    {

        #region "Variables"

        EL.Registrations.Staffs staffEL;
        EL.Registrations.Suppliers supplierEL = new EL.Registrations.Suppliers();
        EL.Registrations.PaymentMethods paymentMethodEL = new EL.Registrations.PaymentMethods();
        EL.Registrations.ShippingMethods shippingMethodEL = new EL.Registrations.ShippingMethods();
        EL.Transactions.PurchaseOrders purchaseOrderEL = new EL.Transactions.PurchaseOrders();
        EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL = new EL.Transactions.PurchaseOrderDetails();
        BL.Registrations.Suppliers supplierBL = new BL.Registrations.Suppliers();
        BL.Registrations.PaymentMethods paymentMethodBL = new BL.Registrations.PaymentMethods();
        BL.Registrations.ShippingMethods shippingMethodBL = new BL.Registrations.ShippingMethods();
        BL.Transactions.PurchaseOrders purchaseOrderBL = new BL.Transactions.PurchaseOrders();
        BL.Transactions.PurchaseOrderDetails purchaseOrderDetailBL = new BL.Transactions.PurchaseOrderDetails();
        frmManagePurchaseOrderProducts frmManagePurchaseOrderProducts;
        public string current = "";

        #endregion

        public frmManagePurchaseOrders(EL.Registrations.Staffs _staffEL)
        {
            InitializeComponent();
            staffEL = _staffEL;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                DoubleBuffered = true;
            }
        }

        #region "Methods"
        private void ReadOnlyControls()
        {
            txtTotalAmount.ReadOnly = true;

        }

        private void HiddenColumns()
        {
            dgv.Columns["Staff First Name"].Visible = false;
            dgv.Columns["Staff Middle Name"].Visible = false;
            dgv.Columns["Staff Last Name"].Visible = false;
            dgv.Columns["Purchase Order Staff ID"].Visible = false;
            dgv.Columns["Purchase Order Supplier ID"].Visible = false;
            dgv.Columns["Purchase Order Payment Method ID"].Visible = false;
            dgv.Columns["Purchase Order Shipping Method ID"].Visible = false;
            dgv.Columns["Supplier Contact Detail ID"].Visible = false;
            dgv.Columns["Supplier Address ID"].Visible = false;
            dgv.Columns["Supplier Contact Number"].Visible = false;
            dgv.Columns["Supplier Email Address"].Visible = false;
            dgv.Columns["Supplier Address"].Visible = false;
            dgv.Columns["Supplier City"].Visible = false;
            dgv.Columns["Supplier Zip Code"].Visible = false;
            dgv.Columns["Supplier Province"].Visible = false;
            dgv.Columns["Payment Method"].Visible = false;
            dgv.Columns["Shipping Method"].Visible = false;
            dgv.Columns["Staff Username"].Visible = false;
            dgv.Columns["Staff Password"].Visible = false;
            dgv.Columns["Staff Contact Detail ID"].Visible = false;
            dgv.Columns["Staff Basic Information ID"].Visible = false;
            dgv.Columns["Staff Position ID"].Visible = false;
            dgv.Columns["Staff Position"].Visible = false;
            dgv.Columns["Staff Gender"].Visible = false;
            dgv.Columns["Staff Birth Date"].Visible = false;
            dgv.Columns["Staff Address ID"].Visible = false;
            dgv.Columns["Staff Contact Number"].Visible = false;
            dgv.Columns["Staff Email Address"].Visible = false;
            dgv.Columns["Staff Address"].Visible = false;
            dgv.Columns["Staff City"].Visible = false;
            dgv.Columns["Staff Zip Code"].Visible = false;
            dgv.Columns["Staff Province"].Visible = false;
            dgv.Columns["Comment"].Visible = false;
        }

        public void LoadData(string keywords)
        {
            dgv.DataSource = purchaseOrderBL.List(keywords);
        }

        public void ManageForm(bool status)
        {
            gbInformations.Enabled = status;
            gbControls.Enabled = !status;
            dgv.Enabled = !status;
            txtSearch.Enabled = !status;
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(txtPurchaseOrderName, "");
            errorProvider1.SetError(cbPaymentMethod, "");
            errorProvider1.SetError(cbShippingMethod, "");
            errorProvider1.SetError(txtComment, "");
            errorProvider1.SetError(btnManagePurchaseOrderProducts, "");
        }


        private void DisabledControls()
        {
            cbSupplierName.Enabled = false;
            txtTotalAmount.Enabled = false;
        }

        public void ClearFields()
        {
            dgv.ClearSelection();


            cbSupplierName.SelectedIndex = -1;
            cbSupplierName.Text = "";

            txtPurchaseOrderName.ResetText();

            cbPaymentMethod.SelectedIndex = -1;
            cbPaymentMethod.Text = "";

            cbShippingMethod.SelectedIndex = -1;
            cbShippingMethod.Text = "";

            txtComment.ResetText();

            txtTotalAmount.ResetText();


        }

        private bool CheckErrors()
        {
            bool status = true;

            if (txtPurchaseOrderName.Text.Equals(""))
            {
                errorProvider1.SetError(txtPurchaseOrderName, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtPurchaseOrderName, "");


            if (cbPaymentMethod.Text.Equals(""))
            {
                errorProvider1.SetError(cbPaymentMethod, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbPaymentMethod, "");


            if (cbShippingMethod.Text.Equals(""))
            {
                errorProvider1.SetError(cbShippingMethod, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(cbShippingMethod, "");

            if (txtComment.Text.Equals(""))
            {
                errorProvider1.SetError(txtComment, "This field is required.");
                status = false;
            }
            else
                errorProvider1.SetError(txtComment, "");


            if (frmManagePurchaseOrderProducts.dgv.Rows.Count == 0)
            {
                errorProvider1.SetError(btnManagePurchaseOrderProducts, "No selected products. Please add.");
                status = false;
            }
            else
                errorProvider1.SetError(btnManagePurchaseOrderProducts, "");

            return status;
        }

        private void GetDataFromForm()
        {
            purchaseOrderEL.Staffid = staffEL.Staffid;
            purchaseOrderEL.Purchaseordername = txtPurchaseOrderName.Text;
            purchaseOrderEL.Supplierid = Convert.ToInt32(cbSupplierName.SelectedValue);
            purchaseOrderEL.Paymentmethodid = Convert.ToInt32(cbPaymentMethod.SelectedValue);
            purchaseOrderEL.Shippingmethodid = Convert.ToInt32(cbShippingMethod.SelectedValue);
            purchaseOrderEL.Purchaseorderstatus = "PENDING";
            purchaseOrderEL.Purchaseorderamountpaid = 0;
            purchaseOrderEL.Purchasetotalorderamount = Convert.ToSingle(txtTotalAmount.Text);
            purchaseOrderEL.Purchaseorderdatereceived = "00-00-0000";
            purchaseOrderEL.Purchaseorderdaterequested = DateTime.Now.ToString("yyyy-MM-dd");
            purchaseOrderEL.Purchaseordercomment = txtComment.Text;

        }

        private void getDataFromDataGridView()
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                purchaseOrderEL.Purchaseorderid = Convert.ToInt32(row.Cells["Purchase Order ID"].Value);
                supplierEL.Supplier = row.Cells["Supplier"].Value.ToString();
                purchaseOrderEL.Purchaseordername = row.Cells["Purchase Order Name"].Value.ToString();
                paymentMethodEL.Paymentmethod = row.Cells["Payment Method"].Value.ToString();
                shippingMethodEL.Shippingmethod = row.Cells["Shipping Method"].Value.ToString();
                purchaseOrderEL.Purchaseorderdaterequested = row.Cells["Date Requested"].Value.ToString();
                purchaseOrderEL.Purchaseorderdatereceived = row.Cells["Date Received"].Value.ToString();
                purchaseOrderEL.Purchaseordercomment = row.Cells["Comment"].Value.ToString();
                purchaseOrderEL.Purchasetotalorderamount = Convert.ToSingle(row.Cells["Total Amount"].Value);
                purchaseOrderEL.Purchaseorderamountpaid = Convert.ToSingle(row.Cells["Amount Paid"].Value);
                purchaseOrderEL.Purchaseorderstatus = row.Cells["Purchase Order Status"].Value.ToString();
            }

           
            cbSupplierName.SelectedIndex = cbSupplierName.FindString(supplierEL.Supplier);
            txtPurchaseOrderName.Text = purchaseOrderEL.Purchaseordername.ToString();
            cbPaymentMethod.SelectedIndex = cbPaymentMethod.FindString(paymentMethodEL.Paymentmethod);
            cbShippingMethod.SelectedIndex = cbShippingMethod.FindString(shippingMethodEL.Shippingmethod);
            txtComment.Text = purchaseOrderEL.Purchaseordercomment.ToString();
            txtTotalAmount.Text = purchaseOrderEL.Purchasetotalorderamount.ToString();

        }

        private void ShowMessageBox(bool condition)
        {
            if (condition)
            {
                LoadData(txtSearch.Text);
                ClearFields();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void PopulateControls()
        {

            cbSupplierName.DisplayMember = "Supplier";
            cbSupplierName.ValueMember = "Supplier ID";
            cbSupplierName.DataSource = supplierBL.List("");

            cbPaymentMethod.DisplayMember = "Payment Method";
            cbPaymentMethod.ValueMember = "Payment Method ID";
            cbPaymentMethod.DataSource = paymentMethodBL.List();

            cbShippingMethod.DisplayMember = "Shipping Method";
            cbShippingMethod.ValueMember = "Shipping Method ID";
            cbShippingMethod.DataSource = shippingMethodBL.List();
        }
        #endregion









        #region "Events"
        private void btnManagePurchaseOrderProducts_Click(object sender, EventArgs e)
        {
            frmManagePurchaseOrderProducts.ShowDialog();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmManagePurchaseOrderProducts = new frmManagePurchaseOrderProducts(this);
            frmSelectSupplier frmSelectSupplier = new frmSelectSupplier(this, supplierEL);
            frmSelectSupplier.ShowDialog();
        }

        private void frmManagePurchaseOrders_Load(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            HiddenColumns();
            ManageForm(false);
            PopulateControls();
            ClearFields();
            ReadOnlyControls();
            cbSupplierName.Enabled = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                frmViewPurchaseOrder frmViewPurchaseOrder = new frmViewPurchaseOrder(this, purchaseOrderEL);
                frmViewPurchaseOrder.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected item. Please select first.");
            }
            else
            {
                switch (MessageBox.Show(this, "Are you sure to delete this?", "Confirming", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    default:
                        ShowMessageBox(purchaseOrderBL.Delete(purchaseOrderEL));
                        break;
                } 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckErrors())
            {
                GetDataFromForm();
                if (current.Equals("ADD"))
                {
                    if (frmManagePurchaseOrderProducts.dgv.Rows.Count == 0)
                    {
                        MessageBox.Show("Please add products.");
                    }
                    else
                    {
                        purchaseOrderEL.Purchaseorderid = Convert.ToInt32(purchaseOrderBL.Insert(purchaseOrderEL));

                        if (purchaseOrderEL.Purchaseorderid > 0)
                        {

                            bool stat = true;

                            foreach (DataGridViewRow row in frmManagePurchaseOrderProducts.dgv.Rows)
                            {
                                purchaseOrderDetailEL.Productid = Convert.ToInt32(row.Cells[0].Value);
                                purchaseOrderDetailEL.Purchaseorderdetailquantity = Convert.ToInt32(row.Cells[3].Value);
                                purchaseOrderDetailEL.Purchaseorderid = purchaseOrderEL.Purchaseorderid;
                                purchaseOrderDetailEL.Purchaseorderdetailprice = Convert.ToInt32(row.Cells[2].Value);

                                if (purchaseOrderDetailBL.Insert(purchaseOrderDetailEL) == 0)
                                {
                                    stat = false;
                                }
                            }

                            if (stat)
                            {
                                ShowMessageBox(true);
                            }
                            else
                            {
                                ShowMessageBox(false);
                            }

                        }
                        else
                        {
                            ShowMessageBox(false);
                        }


                    }
                }


                ManageForm(false);
                ClearFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageForm(false);
            ClearFields();
            ClearErrors();
            frmManagePurchaseOrderProducts.Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDataGridView();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            getDataFromDataGridView();
        }
        #endregion
    }
}
