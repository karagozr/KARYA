using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KARYA.UI.Win.HanelApp.Forms.Others.Report
{
    public partial class PivotGeneralReport : Form
    {
        string layoutPivot = Environment.CurrentDirectory + "\\GeneralReportLayoud.xml";
        public PivotGeneralReport()
        {
            InitializeComponent();
        }

        private void PivotGeneralReport_Load(object sender, EventArgs e)
        {
            pivotGridControl1.ForceInitialize();

            if (File.Exists(layoutPivot))
            {
                pivotGridControl1.RestoreLayoutFromXml(layoutPivot);
            }

            this.vW_GENEL_RAPORTableAdapter.Fill(this.demoDataSet.VW_GENEL_RAPOR);
            
        }

        private void PivotGeneralReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            pivotGridControl1.SaveLayoutToXml(layoutPivot);
        }
    }
}
