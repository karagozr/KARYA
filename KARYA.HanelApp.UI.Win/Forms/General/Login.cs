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
    public partial class Login : Form
    {
        public bool _LOGIN=false;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _LOGIN = true;
            this.Close();
        }

        private void btnConnectionSetting_Click(object sender, EventArgs e)
        {
            ConnectionSetting connectionSetting = new ConnectionSetting();
            connectionSetting.ShowDialog();
        }
    }
}
