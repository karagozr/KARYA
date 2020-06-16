using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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

namespace KARYA.HanelApp.UI.Win.Forms.Others.Report
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

            //if (File.Exists(layoutGrid))
            //{
            //    bandedGridView1.RestoreLayoutFromXml(layoutGrid);
            //}

            cmbAylar.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void btnSetFilter_Click(object sender, EventArgs e)
        {
            if (lookUpProje.EditValue == null)
            {
                MessageBox.Show("Proje Seçiniz");
                return;
            }
            try
            {
                this.pr_ButceRaporTableAdapter.Fill(this.demoDataSet.Pr_ButceRapor, Convert.ToInt16(cmbAylar.SelectedIndex + 1), cmbParaBirimi.Text, lookUpProje.EditValue.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            bandMonth1.Caption = cmbAylar.Text;
            bandMonthNow1.Caption = cmbAylar.Text + " - " + DateTime.Now.Year;
            bandMonthLast1.Caption = cmbAylar.Text + " - " + (DateTime.Now.Year-1);

            bandTotal.Caption = "Ocak - " + cmbAylar.Text;
            bandTotalNow.Caption = "Ocak - " + cmbAylar.Text + " - " + DateTime.Now.Year;
            bandTotalLast.Caption = "Ocak - " + cmbAylar.Text + " - " + (DateTime.Now.Year - 1);
        }

        private void HedefButceReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            bandedGridView1.SaveLayoutToXml(layoutGrid);
        }

        private void bandedGridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            BandedGridView view = sender as BandedGridView;
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            if (info.Column == colANA_GRUP)
            {
                var text = view.GetGroupSummaryText(e.RowHandle);
                text = Convert.ToDecimal(text.Substring(0, text.IndexOf(",")).Replace(" ", "")).ToString("N2");
                info.GroupText = "<color=Maroon>" + info.GroupValueText + "</color> " + " : ";
                info.GroupText += "<color=blue>" + text + "</color> ";
            }
            if (info.Column == colGRUP)
            {
                var text = view.GetGroupSummaryText(e.RowHandle);
                var firstIndex = text.IndexOf(",");
                var lastIndex = text.LastIndexOf(",");
                text = text.Substring(0, text.LastIndexOf(","));
                text = Convert.ToDecimal(text.Substring(text.IndexOf(",") + 1).Replace(" ", "")).ToString("N2");
                info.GroupText =  "<color=Maroon>" + info.GroupValueText + "</color> " + " : ";
                info.GroupText += "<color=green>" + text + "</color> ";
            }
            if (info.Column == colCARI_KODLAR)
            {
                var text = view.GetGroupSummaryText(e.RowHandle);
                var lst = text.LastIndexOf(",");
                text = Convert.ToDecimal(text.Substring(text.LastIndexOf(",")+1).Replace(" ", "")).ToString("N2");
                info.GroupText = "<color=Maroon>" + info.GroupValueText + "</color> " + " : ";
                info.GroupText += "<color=black>" + text + "</color> ";
            }
        }

    }
}
