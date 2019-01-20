using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren.Views
{
    public partial class PagerControl : UserControl
    {
        public event Action<int> OnPage;
        public PagerControl()
        {
            InitializeComponent();
            SetPageInfo(0, 0, 0, 0);
        }

        int pno = 0;
        int totalpage = 0;
        public void SetPageInfo(int pno, int pagesize, int totalcount, int totalpage)
        {
            this.pno = pno;
            this.totalpage = totalpage;
            labInfo.Text = string.Format("当前 {0}/{1} 页 共{2}条记录", pno, totalpage, totalcount);
            btnPre.Enabled = pno > 1;
            btnNext.Enabled = pno < totalpage;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (pno > 1 && OnPage != null)
            {
                OnPage.Invoke(pno - 1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (pno < totalpage && OnPage != null)
            {
                OnPage.Invoke(pno + 1);
            }
        }
    }

}
