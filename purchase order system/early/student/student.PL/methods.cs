using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace student.PL
{
    public class methods
    {
        public static void ChangePanelDisplay(Form frm, Panel pnl)
        {
            pnl.Controls.Clear();
            frm.TopLevel = false;
            pnl.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        public static bool CheckRequiredTXT(params TextBox[] i)
        {
            bool bol = true;

            foreach (TextBox d in i)
            {
                if (d.Text.Equals(""))
                    bol = false;
            }
            return bol;
        }

        public static bool CheckRequiredDTP(params DateTimePicker[] i)
        {
            bool bol = true;

            foreach (DateTimePicker d in i)
            {
                if (d.Text.Equals(""))
                    bol = false;
            }
            return bol;
        }

        public static bool CheckRequiredCB(params ComboBox[] i)
        {
            bool bol = true;

            foreach (ComboBox d in i)
            {
                if (d.Text.Equals(""))
                    bol = false;
            }
            return bol;
        }

        public static void ClearTXT(params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.ResetText();
        }

        public static void ClearDTP(params DateTimePicker[] i)
        {
            foreach (DateTimePicker d in i)
                d.ResetText();
        }

        public static void ClearCB(params ComboBox[] i)
        {
            foreach (ComboBox d in i)
            {
                d.ResetText();
                d.SelectedIndex = -1;
            }

        }

        public static void DGVAddButton(DataGridView dgv)
        {

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "ADD TO CART";
            btn1.Name = "btn1";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVAddButtons(DataGridView dgv)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "EDIT";
            btn.Name = "btn";
            btn.FillWeight = 20;
            btn.ReadOnly = false;
            btn.DividerWidth = 0;
            btn.FillWeight = 10;
            btn.Frozen = false;
            btn.MinimumWidth = 5;
            btn.Width = 100;
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "DELETE";
            btn1.Name = "btn1";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVFillWeights(DataGridView dgv, int[] x, int[] y)
        {
            int m = 0;
            foreach (int x1 in x)
            {
                dgv.Columns[x1].FillWeight = y[m];
                m++;
            }
        }

        public static void DGVFillWeights(DataGridView dgv, string[] x, int[] y)
        {
            int m = 0;
            foreach (string x1 in x)
            {
                dgv.Columns[x1].FillWeight = y[m];
                m++;
            }
        }

        public static void DGVHiddenColumns(DataGridView dgv, params string[] i)
        {
            foreach (string d in i)
                dgv.Columns[d].Visible = false;
        }

        public static void DGVHiddenColumns(DataGridView dgv, params int[] i)
        {
            foreach (int d in i)
                dgv.Columns[d].Visible = false;
        }

        public static void DGVTheme(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(228, 235, 250);
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);
        }


        public static void EnabledCB(bool bol, params ComboBox[] i)
        {
            foreach (ComboBox d in i)
                d.Enabled = bol;
        }

        public static void EnabledDGV(bool bol, params DataGridView[] i)
        {
            foreach (DataGridView d in i)
                d.Enabled = bol;
        }

        public static void EnabledDTP(bool bol, params DateTimePicker[] i)
        {
            foreach (DateTimePicker d in i)
                d.Enabled = bol;
        }

        public static void EnabledTXT(bool bol, params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.Enabled = bol;
        }

        public static void EnabledGB(bool bol, params GroupBox[] i)
        {
            foreach (GroupBox d in i)
                d.Enabled = bol;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();


            textBox.KeyPress += (sender, args) =>
            {
                OnlyNumTXT(sender, args);

            };

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 10, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 27);
            buttonCancel.SetBounds(309, 72, 75, 27);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            form.BackColor = Color.White;
            form.Font = new Font("Segoe UI", 10, FontStyle.Regular);



            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }


        public static void LoadCB(ComboBox cb, DataTable dt, string dm, string vm)
        {
            cb.DataSource = dt;
            cb.DisplayMember = dm;
            cb.ValueMember = vm;
        }

        public static void LoadDGV(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = dt;

        }

        public static void NullCB(params ComboBox[] i)
        {
            foreach (ComboBox d in i)
            {
                d.SelectedItem = null;
            }

        }

        public static void OnlyNumTXT(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void OnlyDecimalTXT(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        public static void OnlyIntTXT(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        public static void ReadOnlyTXT(bool bol, params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.ReadOnly = bol;
        }


        public static void VisibilityCB(bool bol, params ComboBox[] i)
        {
            foreach (ComboBox d in i)
                d.Visible = bol;
        }

        public static void VisibilityLBL(bool bol, params Label[] i)
        {
            foreach (Label d in i)
                d.Visible = bol;
        }

        public static void VisibilityTXT(bool bol, params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.Visible = bol;
        }





    }
}
