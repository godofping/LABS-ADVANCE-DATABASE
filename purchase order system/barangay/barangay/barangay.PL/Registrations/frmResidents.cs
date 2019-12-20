using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangay.PL.Registrations
{
    public partial class frmResidents : Form
    {
        public frmResidents()
        {
            InitializeComponent();
        }

        private void PopulateDGV()
        { 
        
        }

        private void ManageDGV()
        {
            methods.DGVTheme(dgv);
        }

        private void frmResidents_Load(object sender, EventArgs e)
        {

        }
    }
}
