using DevExpress.XtraEditors;
using KARYA.UI.Win.HanelApp.Forms.Base;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KARYA.UI.Win.HanelApp.Forms.Others.Report
{
    public partial class HedefButceReport : XtraForm
    {
        string layoutGrid = Environment.CurrentDirectory + "\\HedefButceBandGridReport.xml";
        public HedefButceReport()
        {
            InitializeComponent();
        }

        private void HedefButceReport_Load(object sender, EventArgs e)
        {
            this.vW_PROJELERTableAdapter.Fill(this.demoDataSet.VW_PROJELER);
            gridControl1.ForceInitialize();

            if (File.Exists(layoutGrid))
            {
                advBandedGridView1.RestoreLayoutFromXml(layoutGrid);
            }

            cmbAylar.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void btnSetFilter_Click(object sender, EventArgs e)
        {
            if (lookUpProje.EditValue == null)
            {
                MessageBox.Show("Proje Seçiniz");
                return;
            }
            this.pr_ButceRaporTableAdapter.Fill(this.demoDataSet.Pr_ButceRapor,Convert.ToInt16(cmbAylar.SelectedIndex+1),cmbParaBirimi.Text,lookUpProje.EditValue.ToString());

            bandMonth.Caption = cmbAylar.Text;
            bandMonthNow.Caption = cmbAylar.Text + " - " + DateTime.Now.Year;
            bandMonthLast.Caption = cmbAylar.Text + " - " + (DateTime.Now.Year-1);

            bandTotal.Caption = "Ocak - " + cmbAylar.Text;
            bandTotalNow.Caption = "Ocak - " + cmbAylar.Text + " - " + DateTime.Now.Year;
            bandTotalLast.Caption = "Ocak - " + cmbAylar.Text + " - " + (DateTime.Now.Year - 1);
        }

        private void HedefButceReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            advBandedGridView1.SaveLayoutToXml(layoutGrid);
        }
    }
}
