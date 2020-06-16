using KARYA.HanelApp.UI.Win.Forms.Others.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KARYA.HanelApp.UI.Win.Forms.General
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            //Login login = new Login();
            //login.ShowDialog();
            //if(login._LOGIN)
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PivotGeneralReport frm = new PivotGeneralReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barBtnHedefButceReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HedefButceReport frm = new HedefButceReport();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
