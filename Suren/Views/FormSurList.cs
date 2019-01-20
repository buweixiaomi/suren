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
    public partial class FormSurList : FormView
    {
        public FormSurList()
        {
            InitializeComponent();
        }

        private void siproject_Searching(object sender, EventArgs e)
        {
            var tx = siproject.EditText;
            var project = new Views.FormSelect().SelectProject(tx);
            if (project != null)
            {
                siproject.DisplayValue = project.ProjectName;
                siproject.RealValue = project.ProjectId;
                siproject.Tag = project;
            }
            else
            {
                siproject.Clear();
            }
        }


        string lastsearchwords = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lastsearchwords = "";
            SearchShow(1, lastsearchwords);
        }


        private void Pager1_OnPage(int pageno)
        {
            SearchShow(pageno, lastsearchwords);
        }

        private void SearchShow(int pno, string keywords)
        {
            int projectid = Lib.ToInt(siproject.RealValue);
            int pagesize = 50;
            using (var db = Pub.GetConn())
            {
                var pmodel = Dal.Instance.SurveyingPage(projectid, pno, pagesize, keywords);
                Pub.FillGrid(grid1, pager1, pmodel, (dr, item) =>
                {
                    dr.Cells["surveyingid"].Value = item.SurveyingId;
                    dr.Cells["projectname"].Value = item.Project.ProjectName;
                    dr.Cells["targetname"].Value = item.Target.TargetName;
                    dr.Cells["surveyingname"].Value = item.SurveyingName;


                    dr.Cells["surveyingtime"].Value = item.SurveyingTime.ToString("yyyy-MM-dd HH:mm:ss");
                    dr.Cells["dayweather"].Value = item.DayWeather;
                    dr.Cells["surveyingman"].Value = item.SurveyingMan;

                    dr.Cells["remark"].Value = item.Remark;
                    dr.Tag = item;
                });
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SurenApplication.SurenApp.OpenView<Views.FormSurDetail>("opennew", null);
        }

        private void grid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var surveyingid = Lib.ToInt(grid1.Rows[e.RowIndex].Cells["surveyingid"].Value);
            SurenApplication.SurenApp.OpenView<Views.FormSurDetail>("openshow", new object[] { surveyingid });
        }

        private void FormSurList_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("surveyingid", "测量序号");
            map.Add("projectname", "项目名称");
            map.Add("targetname", "测量目标名称");
            map.Add("surveyingname", "测量名称");
            map.Add("surveyingtime", "测量时间");
            map.Add("dayweather", "天气");
            map.Add("surveyingman", "人员");
            map.Add("remark", "备注");
            Pub.InitGrid(grid1, map);
            grid1.ReadOnly = true;
            pager1.OnPage += Pager1_OnPage;
            btnSearch_Click(null, null);
        }

        private void grid1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var surveyingid = Lib.ToInt(grid1.Rows[e.RowIndex].Cells["surveyingid"].Value);
            SurenApplication.SurenApp.OpenView<Views.FormSurDetail>("openshow", new object[] { surveyingid });
        }
    }
}
