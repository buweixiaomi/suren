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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            btnbuildtestdata.Visible = false;
        }

        private void btnProList_Click(object sender, EventArgs e)
        {
            SurenApplication.SurenApp.OpenView<Views.FormProList>("open", null);
        }

        private void btnSurList_Click(object sender, EventArgs e)
        {
            SurenApplication.SurenApp.OpenView<Views.FormSurList>("open", null);
        }

        private void btnAddSur_Click(object sender, EventArgs e)
        {
            SurenApplication.SurenApp.OpenView<Views.FormSurDetail>("opennew", null);
        }

        public Form[] GetMidChildren()
        {
            return this.MdiChildren;
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            SurenApplication.SurenApp.OpenView<Views.FormReport>("open", null);
        }

        public void ShowIn(FormView form)
        {
            form.MdiParent = this;
            form.Show(this.dockPanelMain);
        }
        public void SetChildCurrent(Form form)
        {
            this.ActivateMdiChild(form);
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.T)
            {
                btnbuildtestdata.Visible = !btnbuildtestdata.Visible;
            }
        }

        private void btnbuildtestdata_Click(object sender, EventArgs e)
        {

            TestDataBuilder builder = new TestDataBuilder();
            builder.Start();
            MsgHelper.ShowInfo("生成成功！");
        }
    }
}
