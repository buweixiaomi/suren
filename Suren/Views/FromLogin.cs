using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren.Views
{
    public partial class FromLogin : Form
    {
        public const string PWD = "113355";
        public FromLogin()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtpwd.Focus();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtpwd.Text.Trim() == PWD)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
                MsgHelper.ShowWarning("提示", "密码不正确！");
            }
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnok_Click(null, null);
            }
        }
    }
}
