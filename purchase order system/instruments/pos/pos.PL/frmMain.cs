﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos.PL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tRANSACTIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void cUSTOMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pnl = new Registrations.frmCustomers();
            pnl.ShowDialog();
        }

        private void pRODUCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pnl = new Registrations.frmProducts();
            pnl.ShowDialog();
        }

        private void cATEGORIESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pnl = new Registrations.frmCategories();
            pnl.ShowDialog();
        }

       
    }
}
