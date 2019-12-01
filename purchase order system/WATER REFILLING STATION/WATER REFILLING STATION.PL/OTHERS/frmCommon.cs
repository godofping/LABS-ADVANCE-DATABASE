using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WATER_REFILLING_STATION.PL.OTHERS
{
    public partial class frmCommon : Form
    {
        string s;
        Form frm;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;     
                return handleParam;
            }
        }

        public frmCommon(string _s, Form _frm)
        {
            InitializeComponent();
            s = _s;
            frm = _frm;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContainer_Load(object sender, EventArgs e)
        {
            lblHeader.Text = s;
            methods.ChangePanelDisplay(frm, pnlMain);
        }


    }
}
