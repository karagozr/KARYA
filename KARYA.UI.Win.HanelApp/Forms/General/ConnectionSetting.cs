using KARYA.HanelApp.Common.Function.Connection;
using KARYA.HanelApp.Common.Models;
using KARYA.HanelApp.UI.Win.Functions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KARYA.HanelApp.UI.Win.Forms.General
{
    public partial class ConnectionSetting : Form
    {
        bool _changedValues = false;
        public ConnectionSetting()
        {
            InitializeComponent();
        }

        private void ConnectionSetting_Load(object sender, EventArgs e)
        {
            LoadSettingData();
            _changedValues = false;
        }

        private void LoadSettingData()
        {
            var result = FileFunctions.ReadConnectionData();
            if (result.Success)
            {
                txt_server.Text     = result.Data.Server;
                txt_database.Text   = result.Data.Database;
                txt_user.Text       = result.Data.User;
                txt_password.Text   = result.Data.Password;
            }
            else
            {
                lbl_Message.ForeColor = Color.Maroon;
                lbl_Message.Text = result.Message;
            }
            
        }

        private bool SaveSetting()
        {
            var connData = new ConnectionValuesModel
            {
                Server = txt_server.Text,
                Database = txt_database.Text,
                User = txt_user.Text,
                Password = txt_password.Text
            };

            var result = FileFunctions.WriteConnectionData(connData);

            if (result.Success)
            {
                lbl_Message.ForeColor = Color.Green;
                lbl_Message.Text = result.Message;
                return true;
            }
            else
            {
                lbl_Message.ForeColor = Color.Maroon;
                lbl_Message.Text = result.Message;
                return false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }


        private void btn_test_Click(object sender, EventArgs e)
        {
            var connData = new ConnectionValuesModel
            {
                Server      = txt_server.Text,
                Database    = txt_database.Text,
                User        = txt_user.Text,
                Password    = txt_password.Text
            };

            var result = DatabaseConnection.TestConnection(connData);

            if (result.Success)
            {
                lbl_Message.ForeColor   = Color.Green;
                lbl_Message.Text        = result.Message;
            }
            else
            {
                lbl_Message.ForeColor   = Color.Maroon;
                lbl_Message.Text        = result.Message;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            _changedValues=true;
        }

        private void ConnectionSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changedValues)
            {
                var message = MessageBox.Show("Değişiklikler kaydedilsin mi?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (message == DialogResult.Yes)
                {
                    if (SaveSetting())
                    {
                        e.Cancel = false;
                    }
                }
                else if (message == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
    }

    
}
