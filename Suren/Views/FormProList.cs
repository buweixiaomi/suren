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
    public partial class FormProList : FormView
    {
        public FormProList()
        {
            InitializeComponent();
        }

        string lastsearchwords = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lastsearchwords = "";
            SearchShow(1, lastsearchwords);
        }

        private void FormProList_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("projectid", "序号");
            map.Add("projectname", "名称");
            map.Add("remark", "备注");
            Pub.InitGrid(grid1, map);
            grid1.ReadOnly = true;
            pager1.OnPage += Pager1_OnPage;
            btnSearch_Click(null, null);
        }

        private void Pager1_OnPage(int pageno)
        {
            SearchShow(pageno, lastsearchwords);
        }

        private void SearchShow(int pno, string keywords)
        {
            int pagesize = 50;
            using (var db = Pub.GetConn())
            {
                var pmodel = Dal.Instance.PageProject(pno, pagesize); 
                Pub.FillGrid(grid1, pager1, pmodel, (dr, item) =>
                {
                    dr.Cells["projectid"].Value = item.ProjectId;
                    dr.Cells["projectname"].Value = item.ProjectName;
                    dr.Cells["remark"].Value = item.Remark;

                });
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SurenApplication.SurenApp.OpenView<Views.FormProDetail>("opennew", null);
        }

        private void grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var projectid = Lib.ToInt(grid1.Rows[e.RowIndex].Cells["projectid"].Value);
            SurenApplication.SurenApp.OpenView<Views.FormProDetail>("openshow", new object[] { projectid });
        }
    }
}
